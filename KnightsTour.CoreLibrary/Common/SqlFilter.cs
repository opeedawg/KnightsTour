// © 2023 DXterity Solutions
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//    https://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// ************************************************************************
// Author           : DXterity8 Version 8.6
// Created          : October 14, 2023 11:07:03 AM
// File             : SqlFilter.cs
// ************************************************************************

using Dropbox.Api.TeamLog;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace KnightsTour.CoreLibrary
{
    public enum FilterComparer
    {
        Equals = 1,
        Like = 2,
        StartsWith = 3,
        EndsWith = 4,
        NotEqual = 5,
        GreaterThan = 6, 
        GreaterThanOrEqual = 7,
        LessThan = 8, 
        LaterThanOrEqual = 9,
        IsNull = 10,
        IsNotNull = 11,
        HasLength = 12,
        HasZeroLength = 13,
    }
    public enum FilterDataType
    {
        String = 1,
        Integer = 2,
        Decimal = 3,
        Date = 4,
    }
    public class SqlFilter
    {
        public SqlFilter()
        {

        }
        public SqlFilter(string column, string value) : this(column, value, FilterDataType.String, FilterComparer.Equals)
        {
        }
        public SqlFilter(string column, string value, FilterDataType dataType) : this(column, value, FilterDataType.String, FilterComparer.Equals)
        {
        }
        public SqlFilter(string column, string value, FilterComparer comparer): this(column, value, FilterDataType.String, comparer)
        {
        }
        public SqlFilter(string column, string value, FilterDataType dataType, FilterComparer comparer)
        {
            Column = column;
            Value = value;
            DataType = dataType;
            Comparer = comparer;
        }
        public string Column { get; set; }
        public string Value { get; set; }
        public FilterDataType DataType { get; set; }
        public FilterComparer Comparer { get; set; }

        [JsonIgnore]
        [XmlIgnore]
        public string GetSql
        {
            get
            {
                StringBuilder sql = new StringBuilder();
                if(!(Comparer == FilterComparer.HasLength || Comparer == FilterComparer.HasZeroLength))
                    sql.Append($"{Column} ");
                switch (Comparer)
                {
                    case FilterComparer.Equals:
                        sql.Append($"= {(DataType == FilterDataType.String ? "'" : "")}{ParameterName}{(DataType == FilterDataType.String ? "'" : "")}");
                        break;
                    case FilterComparer.Like:
                        sql.Append($"LIKE CONCAT('%', {ParameterName}, '%')");
                        break;
                    case FilterComparer.StartsWith:
                        sql.Append($"LIKE CONCAT({ParameterName}, '%')");
                        break;
                    case FilterComparer.EndsWith:
                        sql.Append($"LIKE CONCAT('%', {ParameterName})");
                        break;
                    case FilterComparer.NotEqual:
                        sql.Append($"<> {(DataType == FilterDataType.String ? "'" : "")}{ParameterName}{(DataType == FilterDataType.String ? "'" : "")}");
                        break;
                    case FilterComparer.GreaterThan:
                        sql.Append($"> {(DataType == FilterDataType.String ? "'" : "")}{ParameterName}{(DataType == FilterDataType.String ? "'" : "")}");
                        break;
                    case FilterComparer.GreaterThanOrEqual:
                        sql.Append($">= {(DataType == FilterDataType.String ? "'" : "")}{ParameterName}{(DataType == FilterDataType.String ? "'" : "")}");
                        break;
                    case FilterComparer.LessThan:
                        sql.Append($"< {(DataType == FilterDataType.String ? "'" : "")}{ParameterName}{(DataType == FilterDataType.String ? "'" : "")}");
                        break;
                    case FilterComparer.LaterThanOrEqual:
                        sql.Append($"<= {(DataType == FilterDataType.String ? "'" : "")}{ParameterName}{(DataType == FilterDataType.String ? "'" : "")}");
                        break;
                    case FilterComparer.IsNull:
                        sql.Append($"IS NULL");
                        break;
                    case FilterComparer.IsNotNull:
                        sql.Append($"IS NOT NULL");
                        break;
                    case FilterComparer.HasLength:
                        sql.Append($"LENGTH({Column}) > 0");
                        break;
                    case FilterComparer.HasZeroLength:
                        sql.Append($"LENGTH({Column}) = 0");
                        break;                    
                    default:
                        break;
                }

                return sql.ToString();
            }
        }
        [JsonIgnore]
        [XmlIgnore]
        public KnightsTour.CoreLibrary.IParameter GetParameter
        {
            get
            {
                try
                {
                    switch (DataType)
                    {
                        case FilterDataType.String:
                            return new GenericParameter(ParameterName, Value);
                        case FilterDataType.Integer:
                            return new GenericParameter(ParameterName, int.Parse(Value));
                        case FilterDataType.Decimal:
                            return new GenericParameter(ParameterName, decimal.Parse(Value));
                        case FilterDataType.Date:
                            return new GenericParameter(ParameterName, DateTime.Parse(Value));
                        default:
                            throw new Exception("Unable to create filter parameter.");
                    }
                }
                catch (Exception exception)
                {
                    throw new Exception($"Unable to parse filter parameter '{Value}' as a {DataType.ToString()}", exception);
                }
            }
        }
        [JsonIgnore]
        [XmlIgnore]
        public string ParameterName
        {
            get
            {
                return $"@{Column.Replace("[", "").Replace("]", "").Replace("'", "").Replace("_", " ").Replace(" ", "").Trim()}";
            }
        }
    }
}
