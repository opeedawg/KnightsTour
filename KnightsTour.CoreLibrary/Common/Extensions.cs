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
// File             : Extensions.cs
// ************************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace KnightsTour.CoreLibrary
{
    /// <summary>
    /// Class Extensions.
    /// </summary>
    public static class Extensions
    {
        #region Data Converters
        /// <summary>
        /// Columns the exists.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="columnName">Name of the column.</param>
        /// <param name="ignoreCase">Should the case of the property be respected or ignored?</param>
        /// <returns><c>true</c> if the column (by name) exists, <c>false</c> otherwise.</returns>
        public static bool ColumnExists(this IDataRecord reader, string columnName, bool ignoreCase = false)
        {
            if (!string.IsNullOrEmpty(columnName) && reader != null)
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    if (ignoreCase && reader.GetName(i).ToUpper() == columnName.ToUpper())
                        return true;
                    else if (!ignoreCase && reader.GetName(i) == columnName)
                        return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Columns the exists.
        /// </summary>
        /// <param name="dataRow">The data row.</param>
        /// <param name="columnName">Name of the column.</param>
        /// <param name="ignoreCase">Should the case of the property be respected or ignored?</param>
        /// <returns><c>true</c> if the column (by name) exists, <c>false</c> otherwise.</returns>
        public static bool ColumnExists(this DataRow dataRow, string columnName, bool ignoreCase = false)
        {
            if (!string.IsNullOrEmpty(columnName) && dataRow != null)
            {
                for (int i = 0; i < dataRow.Table.Columns.Count; i++)
                {
                    if (ignoreCase && dataRow.Table.Columns[i].ColumnName.ToUpper() == columnName.ToUpper())
                        return true;
                    else if (!ignoreCase && dataRow.Table.Columns[i].ColumnName == columnName)
                        return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Checks if the expando object contains the property.  This comparison is case sensitive by default.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="columnName"></param>
        /// <param name="ignoreCase">Should the case of the property be respected or ignored?</param>
        /// <returns><c>true</c> if the expando object contains this property (case sensitive), <c>false</c> otherwise.</returns>
        public static bool ColumnExists(this ExpandoObject entity, string columnName, bool ignoreCase = false)
        {
            if (!string.IsNullOrEmpty(columnName) && entity != null)
            {
                if (ignoreCase)
                    return ((IDictionary<string, object>)entity).Any(d => d.Key.ToUpper() == columnName.ToUpper());
                else
                    return ((IDictionary<string, object>)entity).ContainsKey(columnName);
            }
            return false;
        }
        /// <summary>
        /// Converts a DataRow column value to a strong typed object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataRow"></param>
        /// <param name="parameterName"></param>
        /// <returns></returns>
        public static T ValueAs<T>(this DataRow dataRow, string parameterName)
        {
            if(dataRow == null)
                throw new Exception($"DataRow is null.");

            if (string.IsNullOrEmpty(parameterName))
                throw new Exception($"Missing expected parameter: 'parameterName'");

            //Verify the column exists
            if (dataRow.ColumnExists(parameterName))
            {
                if (dataRow[parameterName] != DBNull.Value)
                {
                    if (typeof(T).Name == "Byte[]")
                        return (T)dataRow[parameterName];
                    else
                    {
                        TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));
                        if (converter != null)
                        {
                            return (T)converter.ConvertFromString(dataRow[parameterName].ToString());
                        }
                        else
                            throw new Exception($"Unable to convert parameter '{parameterName}' to type '{typeof(T).FullName}'.");
                    }
                }
                return default(T);
            }
            else
                throw new Exception($"Parameter '{parameterName}' does not exist in the data row.  This often indicates the model out of sync with the database.");
        }
        /// <summary>
        /// Converts a IDataRecord column value to a strong typed object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataRecord"></param>
        /// <param name="parameterName"></param>
        /// <returns></returns>
        public static T ValueAs<T>(this IDataRecord dataRecord, string parameterName)
        {
            if (dataRecord == null)
                throw new Exception($"IDataRecord is null.");

            if (string.IsNullOrEmpty(parameterName))
                throw new Exception($"Missing expected parameter: 'parameterName'");

            //Verify the column exists
            if (dataRecord.ColumnExists(parameterName))
            {
                if (dataRecord[parameterName] != DBNull.Value && dataRecord[parameterName] != null)
                {
                    if (typeof(T).Name == "Byte[]")
                        return (T)dataRecord[parameterName];
                    else
                    {
                        TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));
                        if (converter != null)
                        {
                            return (T)converter.ConvertFromString(dataRecord[parameterName].ToString());
                        }
                        else
                            throw new Exception($"Unable to convert parameter '{parameterName}' to type '{typeof(T).FullName}'.");
                        }
                }
                return default(T);
            }
            else
                throw new Exception($"Parameter '{parameterName}' does not exist in the data record.  This often indicates the model out of sync with the database.");
        }
        /// <summary>
        /// Converts a Dictionary of values to a strong typed object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="parameterName"></param>
        /// <returns></returns>
        public static T ValueAs<T>(this IDictionary<string, object> dictionary, string parameterName)
        {
            if (dictionary == null)
                throw new Exception($"IDictionary is null.");

            if (string.IsNullOrEmpty(parameterName))
                throw new Exception($"Missing expected parameter: 'parameterName'");

            //Verify the column exists
            if (dictionary.ContainsKey(parameterName))
            {
                if (dictionary[parameterName] != null)
                {
                    if (typeof(T).Name == "Byte[]")
                        return (T)dictionary[parameterName];
                    else
                    {
                        TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));
                        if (converter != null)
                        {
                            return (T)converter.ConvertFromString(dictionary[parameterName].ToString());
                        }
                        else
                            throw new Exception($"Unable to convert parameter '{parameterName}' to type '{typeof(T).FullName}'.");
                    }
                }
                return default(T);
            }
            else
                throw new Exception($"Parameter '{parameterName}' does not exist in the dictionary.  This often indicates the model out of sync with the database.");
        }
        #endregion

        #region SQL safe helpers
        /// <summary>
        /// Converts the value to a SQL safe value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string SafeSQL(this string value)
        {
            if(value != null)
                return value.Replace("'", "''");
            else
                return "NULL";
        }
        /// <summary>
        /// Converts the value to a SQL safe value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string SafeSQL(this DateTime value)
        {
            return value.ToString("yyyy-MM-dd HH:mm:ss");
        }
        /// <summary>
        /// Converts the value to a SQL safe value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string SafeSQL(this DateTime? value)
        {
            if (value.HasValue)
                return value.Value.ToString("yyyy-MM-dd HH:mm:ss");
            else
                return "NULL";
        }
        /// <summary>
        /// Converts the value to a SQL safe value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string SafeSQL(this bool value)
        {
            return value ? "1" : "0";
        }
        /// <summary>
        /// Converts the value to a SQL safe value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string SafeSQL(this bool? value)
        {
            if (value.HasValue)
                return value.Value ? "1" : "0";
            else
                return "NULL";
        }
        /// <summary>
        /// Converts the decimal value to a SQL safe value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string SafeSQL(this decimal value)
        {
            return value.ToString();
        }
        /// <summary>
        /// Converts the value to a SQL safe value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string SafeSQL(this int value)
        {
            return value.ToString();
        }
        /// <summary>
        /// Converts the value to a SQL safe value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string SafeSQL(this int? value)
        {
            if (value.HasValue)
                return value.Value.ToString();
            else
                return "NULL";
        }
        /// <summary>
        /// Converts the value to a SQL safe value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string SafeSQL(this decimal? value)
        {
            if (value.HasValue)
                return value.Value.ToString();
            else
                return "NULL";
        }
        /// <summary>
        /// To the SQL list.
        /// </summary>
        /// <param name="ids">The ids.</param>
        /// <returns>System.String.</returns>
        public static string ToSQLList(this List<int> ids)
        {
            StringBuilder inList = new StringBuilder("(");
            if (ids != null && ids.Count > 0)
            {
                for (int i = 0; i < ids.Count; i++)
                {
                    if (i == (ids.Count - 1))
                        inList.Append(ids[i]);  //No comma on the final value
                    else
                        inList.Append($"{ids[i]},");
                }
            }
            inList.Append(")");

            return inList.ToString();
        }
        /// <summary>
        /// To the SQL list.
        /// </summary>
        /// <param name="ids">The ids.</param>
        /// <returns>System.String.</returns>
        public static string ToSQLList(this IEnumerable<int> ids)
        {
            return ids.ToList().ToSQLList();
        }
        /// <summary>
        /// Converts the value to a SQL safe value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string SafeSQL(this long value)
        {
            return value.ToString();
        }
        /// <summary>
        /// Converts the value to a SQL safe value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string SafeSQL(this long? value)
        {
            if (value.HasValue)
                return value.Value.ToString();
            else
                return "NULL";
        }
        #endregion

        #region Storage Statement helpers
        /// <summary>
        /// Determines if the retrival condition is defined.
        /// </summary>
        /// <param name="condition"></param>
        /// <returns><c>true</c> if the retrival condition exists, <c>false</c> otherwise.</returns>
        public static bool Exists(this IRetrievalCondition condition)
        {
            return 
                condition != null && 
                (!string.IsNullOrEmpty(condition.Columns) || 
                !string.IsNullOrEmpty(condition.SQLOrderBy) || 
                !string.IsNullOrEmpty(condition.SQLWhere) ||
                !string.IsNullOrEmpty(condition.SQLGroupBy) ||
                !string.IsNullOrEmpty(condition.SQLHaving) ||
                condition.Skip.HasValue || 
                condition.Take.HasValue || 
                condition.NonSQLWhere.Exists() || 
                condition.NonSQLOrderBy.Count > 0);
        }
        /// <summary>
        /// Determines if the retrival set is defined.
        /// </summary>
        /// <param name="whereCondition"></param>
        /// <returns><c>true</c> if the retrival set exists, <c>false</c> otherwise.</returns>
        public static bool Exists(this IWhereSet whereCondition)
        {
            return whereCondition.Clauses.Count > 0 || whereCondition.Sets.Count > 0;
        }
        /// <summary>
        /// https://stackoverflow.com/questions/44302697/compare-types-if-one-is-nullable
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <returns><c>true</c> if the two types are convertable, <c>false</c> otherwise.</returns>
        public static bool IsSameType<T1, T2>(this T1 o1, T2 o2)
        {
            // get the types as best we can determine
            var t1 = o1?.GetType() ?? typeof(T1);
            var t2 = o2?.GetType() ?? typeof(T2);

            // Nullable<T> => T
            t1 = Nullable.GetUnderlyingType(t1) ?? t1;
            t2 = Nullable.GetUnderlyingType(t2) ?? t2;

            // compare
            return t1 == t2;
        }
        #endregion
    }
}