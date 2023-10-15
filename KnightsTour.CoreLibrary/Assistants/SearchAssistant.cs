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
// File             : SearchAssistant.cs
// ************************************************************************

using System.Collections.Generic;

namespace KnightsTour.CoreLibrary
{
    /// <summary>
    /// Assists with text searches
    /// </summary>
    public class SearchAssistant
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="SearchAssistant"/> class.
        /// </summary>
        /// <param name="textToSearch">The source file.</param>
        public SearchAssistant(string textToSearch)
        {
            SearchText = textToSearch;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        /// <value>The source.</value>
        public string SearchText { get; set; }
        /// <summary>
        /// Gets or sets the start search string.
        /// </summary>
        /// <value>The start search string.</value>
        public string StartSearchString { get; set; }
        /// <summary>
        /// Gets or sets the end search string.
        /// </summary>
        /// <value>The end search string.</value>
        public string EndSearchString { get; set; }
        /// <summary>
        /// Gets or sets the index of the current.
        /// </summary>
        /// <value>The index of the current.</value>
        public int CurrentIndex { get; set; }
        /// <summary>
        /// Gets the start index of the beginning of.
        /// </summary>
        /// <value>The start index of the beginning of.</value>
        public int BeginningOfStartIndex
        {
            get
            {
                return SearchText.IndexOf(StartSearchString, CurrentIndex);
            }
        }
        /// <summary>
        /// Gets the start index of the ending of.
        /// </summary>
        /// <value>The start index of the ending of.</value>
        public int EndingOfStartIndex
        {
            get
            {
                if (BeginningOfStartIndex != -1)
                    return SearchText.IndexOf(StartSearchString, CurrentIndex) + StartSearchString.Length;
                else
                    return -1;
            }
        }
        /// <summary>
        /// Gets the end index of the beginning of.
        /// </summary>
        /// <value>The end index of the beginning of.</value>
        public int BeginningOfEndIndex
        {
            get
            {
                return SearchText.IndexOf(EndSearchString, EndingOfStartIndex);
            }
        }
        /// <summary>
        /// Gets the end index of the ending of.
        /// </summary>
        /// <value>The end index of the ending of.</value>
        public int EndingOfEndIndex
        {
            get
            {
                if (BeginningOfEndIndex != -1)
                    return SearchText.IndexOf(EndSearchString, EndingOfStartIndex) + EndSearchString.Length;
                else
                    return -1;
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Gets the next characters.
        /// </summary>
        /// <param name="length">The length.</param>
        /// <returns>System.String.</returns>
        public string GetNextCharacters(int length)
        {
            return GetNextCharacters(StartSearchString, length);
        }
        /// <summary>
        /// Gets the next characters.
        /// </summary>
        /// <param name="subString">The sub string.</param>
        /// <param name="length">The length.</param>
        /// <param name="currentIndex">Index of the current.</param>
        /// <returns>System.String.</returns>
        public string GetNextCharacters(string subString, int length, int currentIndex = 0)
        {
            StartSearchString = subString;
            this.CurrentIndex = currentIndex;
            if (EndingOfStartIndex >= 0 && length > 0)
                return SearchText.Substring(EndingOfStartIndex, length);
            else
                return string.Empty;
        }
        /// <summary>
        /// Gets the previous characters.
        /// </summary>
        /// <param name="subString">The sub string.</param>
        /// <param name="length">The length.</param>
        /// <returns>System.String.</returns>
        public string GetPreviousCharacters(string subString, int length)
        {
            StartSearchString = subString;
            return SearchText.Substring(BeginningOfStartIndex - length, length);
        }
        /// <summary>
        /// Gets the sub string.
        /// </summary>
        /// <returns>System.String.</returns>
        public string GetStringBetween()
        {
            return GetStringBetween(StartSearchString, EndSearchString);
        }
        /// <summary>
        /// Gets the sub string.
        /// </summary>
        /// <param name="startString">The start string.</param>
        /// <param name="endString">The end string.</param>
        /// <param name="startIndex">The start index.</param>
        /// <returns>System.String.</returns>
        public string GetStringBetween(string startString, string endString, int startIndex = 0)
        {
            StartSearchString = startString;
            EndSearchString = endString;
            CurrentIndex = startIndex;

            if (EndingOfStartIndex > -1 && BeginningOfEndIndex - EndingOfStartIndex > 0)
                return SearchText.Substring(EndingOfStartIndex, BeginningOfEndIndex - EndingOfStartIndex).Trim();
            else if (EndingOfStartIndex > -1 && BeginningOfEndIndex == -1)
                return SearchText.Substring(EndingOfStartIndex).Trim();
            else
                return string.Empty;
        }
        /// <summary>
        /// Gets the sub strings.
        /// </summary>
        /// <param name="startString">The start string.</param>
        /// <param name="endString">The end string.</param>
        /// <param name="startIndex">The start index.</param>
        /// <returns>List&lt;System.String&gt;.</returns>
        public List<string> GetStringsBetween(string startString, string endString, int startIndex = 0)
        {
            List<string> stringCollection = new List<string>();

            if (startIndex < SearchText.Length)
            {
                int currentIndex = SearchText.IndexOf(startString, startIndex);
                while (currentIndex >= 0)
                {
                    //This means we have found an instance, grab it.
                    stringCollection.Add(GetStringBetween(startString, endString, currentIndex));
                    currentIndex = SearchText.IndexOf(startString, currentIndex + 1);
                }
            }
            return stringCollection;
        }
        /// <summary>
        ///  Gets a new search assistant from the search criteria.
        /// </summary>
        /// <returns></returns>
        public SearchAssistant GetAssistantBetween()
        {
            return GetAssistantBetween(StartSearchString, EndSearchString);
        }
        /// <summary>
        /// Gets the sub string.
        /// </summary>
        /// <param name="startString">The start string.</param>
        /// <param name="endString">The end string.</param>
        /// <param name="startIndex">The start index.</param>
        /// <returns>System.String.</returns>
        public SearchAssistant GetAssistantBetween(string startString, string endString, int startIndex = 0)
        {
            return new SearchAssistant(GetStringBetween(startString, endString, startIndex));
        }
        /// <summary>
        /// Gets the sub strings.
        /// </summary>
        /// <param name="startString">The start string.</param>
        /// <param name="endString">The end string.</param>
        /// <param name="startIndex">The start index.</param>
        /// <returns>List&lt;System.String&gt;.</returns>
        public List<SearchAssistant> GetAssistantsBetween(string startString, string endString, int startIndex = 0)
        {
            List<SearchAssistant> assistantCollection = new List<SearchAssistant>();

            foreach (string s in GetStringsBetween(startString, endString, startIndex))
                assistantCollection.Add(new SearchAssistant(s));

            return assistantCollection;
        }
        #endregion
    }
}
