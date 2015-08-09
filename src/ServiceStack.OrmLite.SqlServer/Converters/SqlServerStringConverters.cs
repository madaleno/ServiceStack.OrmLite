﻿using System;
using ServiceStack.OrmLite.Converters;

namespace ServiceStack.OrmLite.SqlServer.Converters
{
    public class SqlServerStringConverter : StringConverter
    {
        public override string MaxColumnDefinition
        {
            get { return UseUnicode ? "NVARCHAR(MAX)" : "VARCHAR(MAX)"; }
        }

        public override string GetColumnDefinition(int? stringLength)
        {
            var safeLength = Math.Min(
                stringLength.GetValueOrDefault(StringLength), 
                UseUnicode ? 4000 : 8000);

            return UseUnicode
                ? "NVARCHAR({0})".Fmt(safeLength)
                : "VARCHAR({0})".Fmt(safeLength);
        }
    }
}