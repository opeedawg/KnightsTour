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
// File             : DataException.cs
// ************************************************************************

namespace KnightsTour.CoreLibrary
{
    /// <summary>
    /// Class DataException.
    /// </summary>
    /// <seealso cref="CustomException" />
    public class DataException: CustomException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataException"/> class.
        /// </summary>
        /// <param name="exception">The exception.</param>
        public DataException(CustomException exception) : base(exception)
        {
            Context = exception.Context;
            Tier = exception.Tier;
        }
        /// <summary>
        /// Gets or sets the statement.
        /// </summary>
        /// <value>The statement.</value>
        public IStorageStatement Statement { get; set; }
    }
}