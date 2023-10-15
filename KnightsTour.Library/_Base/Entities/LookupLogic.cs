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
// Created          : October 14, 2023 11:18:11 AM
// File             : LookupLogic.cs
// ************************************************************************

using Dropbox.Api.Team;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KnightsTour.CoreLibrary;

namespace KnightsTour
{
    public static class LookupLogic
    {
        #region Declarations
        static Dictionary<string, List<SelectOption>> selectOptions = null;
        #endregion

        #region Properties
        static Dictionary<string, List<SelectOption>> SelectOptions
        {
            get
            {
                if (selectOptions == null)
                {
                    selectOptions = new Dictionary<string, List<SelectOption>>();
                }

                return selectOptions;
            }
        }
        #endregion

        #region Methods
        public static ActionResponse GetSelectOption(string selectionFilter, string value, bool forceRefresh = false)
        {
            ActionResponse response = new ActionResponse("Generic select option retrieval");
            try
            {
                if (forceRefresh || (!forceRefresh && !SelectOptions.ContainsKey(selectionFilter)))
                {
                    // Execute option population
                    List<SelectOption> options = GetOptions(selectionFilter);

                    if (SelectOptions.ContainsKey(selectionFilter))
                        SelectOptions[selectionFilter] = options;
                    else
                        SelectOptions.Add(selectionFilter, options);
                }

                response.DataObject = SelectOptions[selectionFilter].Where(s => s.Value == value);
                response.Append(new Message($"{SelectOptions[selectionFilter].Count} select options retrieved."));
            }
            catch (Exception exception)
            {
                response.Append(exception);
            }

            return response;
        }
        public static ActionResponse GetSelectOptions(string selectionFilter, bool forceRefresh = false)
        {
            ActionResponse response = new ActionResponse("Generic select option retrieval");
            try
            {
                if (forceRefresh || (!forceRefresh && !SelectOptions.ContainsKey(selectionFilter)))
                {
                    // Execute option population
                    List<SelectOption> options = GetOptions(selectionFilter);

                    if (SelectOptions.ContainsKey(selectionFilter))
                        SelectOptions[selectionFilter] = options;
                    else
                        SelectOptions.Add(selectionFilter, options);
                }

                response.DataObject = SelectOptions[selectionFilter];
                response.Append(new Message($"{SelectOptions[selectionFilter].Count} select options retrieved."));
            }
            catch (Exception exception)
            {
                response.Append(exception);
            }

            return response;
        }
        static List<SelectOption> GetOptions(string lookupData)
        {
            List<SelectOption> selectOptions = new List<SelectOption>();

            if (!string.IsNullOrEmpty(lookupData))
            {
                if (lookupData.StartsWith("VALUES|"))
                {
                    List<string> elements = lookupData.Split('|').ToList();
                    for (int i = 1; i < elements.Count; i++)
                    {
                        selectOptions.Add(new SelectOption(elements[i].Trim()));
                    }
                }
                else if (lookupData.StartsWith("JSON|"))
                {
                    // Expecting an exact format like: [{"Key":"1","Value":"Red"},{"Key":"2","Value":"Blue"},{"Key":"3","Value":"Green"}]
                    List<string> elements = lookupData.Split('|').ToList();
                    if (elements.Count > 0 && !string.IsNullOrEmpty(elements[1]))
                    {
                        List<SelectOption> options = JsonConvert.DeserializeObject<List<SelectOption>>(elements[1]);

                        foreach (SelectOption option in options)
                        {
                            selectOptions.Add(option);
                        }
                    }
                }
                else if (lookupData.StartsWith("SQL|"))
                {
                    // Expecting a return statement with 2 columns, key then value (both strings)
                    List<string> elements = lookupData.Split('|').ToList();
                    if (elements.Count > 0 && !string.IsNullOrEmpty(elements[1]))
                    {

                        StorageStatement statement = new StorageStatement()
                        {
                            Statement = elements[1],
                        };

                        IStorageHandler handler = StorageProvider.GetHandler();
                        foreach (IDataRecord record in handler.GetRecords(statement))
                        {
                            if (record.FieldCount == 1)
                            {
                                selectOptions.Add(new SelectOption(record.GetString(0), record.GetString(0)));
                            }
                            else if (record.FieldCount > 1)
                            {
                                selectOptions.Add(new SelectOption(record.GetString(0), record.GetString(1)));
                            }
                        }
                    }
                }
            }

            return selectOptions;
        }
        #endregion
    }
}
