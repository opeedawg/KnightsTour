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
// File             : MethodAttributeAssistant.cs
// ************************************************************************

using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace KnightsTour.CoreLibrary
{
    /// <summary>
    /// Uses reflection to collect method attributes.
    /// </summary>
    public class MethodAttributeAssistant
    {
        #region Constructors
        /// <summary>
        /// Creates a newly populated method attribute class with the reflected values on the frame index.
        /// </summary>
        /// <param name="stackTrace"></param>
        /// <param name="frameIndex"></param>
        public MethodAttributeAssistant(StackTrace stackTrace, int frameIndex)
        {
            List<string> skipClasses = new List<string>() { "MethodWrappers", "ExceptionHandler" };
            MethodBase baseMethod = stackTrace.GetFrame(frameIndex).GetMethod();
            while (skipClasses.Contains(baseMethod.DeclaringType.Name))
            {
                frameIndex++;
                baseMethod = stackTrace.GetFrame(frameIndex).GetMethod();
            }
            if (baseMethod.DeclaringType.DeclaringType != null)
            {
                Method = CleanBaseName(baseMethod.DeclaringType.Name);
                Class = baseMethod.DeclaringType.DeclaringType.Name;
                Assembly = baseMethod.DeclaringType.DeclaringType.Module.FullyQualifiedName;
            }
            else
            {
                Method = CleanBaseName(baseMethod.Name);
                Class = baseMethod.DeclaringType.Name;
                Assembly = baseMethod.DeclaringType.Module.FullyQualifiedName;
            }
            NameSpace = baseMethod.DeclaringType.Namespace;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the assembly.
        /// </summary>
        /// <value>The assembly.</value>
        public string Assembly { get; set; }
        /// <summary>
        /// Gets or sets the name space.
        /// </summary>
        /// <value>The name space.</value>
        public string NameSpace { get; set; }
        /// <summary>
        /// Gets or sets the class.
        /// </summary>
        /// <value>The class.</value>
        public string Class { get; set; }
        /// <summary>
        /// Gets or sets the method.
        /// </summary>
        /// <value>The method.</value>
        public string Method { get; set; }
        #endregion

        #region Methods
        string CleanBaseName(string original)
        {
            if (!string.IsNullOrEmpty(original))
            {
                original = original.Trim();
                if (original.StartsWith("<") && original.Contains(">"))
                {
                    return original.Substring(1, original.IndexOf(">") - 1);
                }
            }
            return original;
        }
        #endregion
    }
}
