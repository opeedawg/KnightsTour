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
// Created          : January 13, 2023 7:25:01 AM
// File             : ConfigurationAssistant.cs
// ************************************************************************

using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;

namespace KnightsTour.CoreLibrary
{
    /// <summary>
    /// Assists in safely validating and retrieving configuration information.
    /// </summary>
    public static class ConfigurationAssistant
    {
        #region Methods
        /// <summary>
        /// Safely returns a particular application setting as a string.
        /// </summary>
        /// <param name="appSettingKey"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static string GetString(string appSettingKey, string defaultValue = null)
        {
            if (Values.ContainsKey(appSettingKey))
            {
                return Values[appSettingKey];
            }
            else
            {
                return defaultValue;
            }
        }
        /// <summary>
        /// Safely returns a particular application setting as an integer.
        /// </summary>
        /// <param name="appSettingKey"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static int GetInt(string appSettingKey, int? defaultValue = null)
        {
            if (Values.ContainsKey(appSettingKey))
            {
                int value = 0;
                if (int.TryParse(Values[appSettingKey], out value))
                    return value;
                else
                    throw new Exception($"Unable to parse Application Setting '{appSettingKey}' as integer.");
            }
            else
            {
                if (defaultValue.HasValue)
                    return defaultValue.Value;
                else
                    throw new Exception($"Missing expected integer Application Setting '{appSettingKey}' and no default value provided.");
            }
        }
        /// <summary>
        /// Safely returns a particular application setting as a decimal.
        /// </summary>
        /// <param name="appSettingKey"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static decimal GetDecimal(string appSettingKey, decimal? defaultValue = null)
        {
            if (Values.ContainsKey(appSettingKey))
            {
                decimal value = 0;
                if (decimal.TryParse(Values[appSettingKey], out value))
                    return value;
                else
                    throw new Exception($"Unable to parse Application Setting '{appSettingKey}' as decimal.");
            }
            else
            {
                if (defaultValue.HasValue)
                    return defaultValue.Value;
                else
                    throw new Exception($"Missing expected decimal Application Setting '{appSettingKey}' and no default value provided.");
            }
        }
        /// <summary>
        /// Safely returns a particular application setting as a boolean.
        /// </summary>
        /// <param name="appSettingKey"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static bool GetBoolean(string appSettingKey, bool? defaultValue = null)
        {
            if (Values.ContainsKey(appSettingKey))
            {
                string value = Values[appSettingKey];
                if (!string.IsNullOrEmpty(value))
                {
                    value = value.ToUpper();
                    return value == "YES" || value == "TRUE" || value == "1" || value == "ON";
                }
                    throw new Exception($"Unable to parse Application Setting '{appSettingKey}' as boolean.");
            }
            else
            {
                if (defaultValue.HasValue)
                    return defaultValue.Value;
                else
                    throw new Exception($"Missing expected boolean Application Setting '{appSettingKey}' and no default value provided.");
            }
        }
        /// <summary>
        /// Gets a connection string.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static string GetConnectionString(string key, string defaultValue = null)
        {
            object o = ConfigurationManager.ConnectionStrings[key];
            if (o != null)
                return o.ToString();
            else
            {
                if (!string.IsNullOrEmpty(defaultValue))
                    return defaultValue;
                else
                    throw new Exception($"Missing expected connection string '{key}' and no default value provided.");
            }
        }
        #endregion

        #region Configuration Support class and properties
        class SettingValues
        {
            public List<string> Values { get; set; }
        }
        static Dictionary<string, string> values = null;
        public static Dictionary<string, string> Values
        {
            get
            {
                if (values == null)
                {
                    values = ReadKVPSection("Values");
                }
                return values;
            }
        }
        static Dictionary<string, string> connectionStrings = null;
        public static Dictionary<string, string> ConnectionStrings
        {
            get
            {
                if (connectionStrings == null)
                {
                    connectionStrings = ReadKVPSection("ConnectionStrings");
                }
                return connectionStrings;
            }
        }
        static Dictionary<string, string> ReadKVPSection(string sectionName)
        {
            Dictionary<string, string> kvps = new Dictionary<string, string>();
            string json = File.ReadAllText("appsettings.json");
            SearchAssistant searchAssistant = new SearchAssistant(json);
            string valuesText = searchAssistant.GetStringBetween($"\"{sectionName}\":", "}").Replace("\r\n", "");
            if (!string.IsNullOrEmpty(valuesText))
            {
                if(valuesText.Trim().StartsWith("{"))
                    valuesText = valuesText.Trim().Substring(1);

                List<string> valuePairs = valuesText.Split("\",").ToList();
                foreach (string valuePair in valuePairs)
                {
                    if (!string.IsNullOrEmpty(valuePair))
                    {
                        string[] parts = valuePair.Replace("\": \"", "\":\"").Replace("\" : \"", "\":\"").Split("\":\"");
                        if (parts.Length == 2)
                            kvps.Add(parts[0].Replace("\"", "").Trim(), parts[1].Replace("\"", "").Replace("\\\\","\\").Trim());
                    }
                }
            }
            return kvps;
        }
        #endregion
    }
}