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
// Created          : March 19, 2023 7:56:06 AM
// File             : ListDataReader.cs
// ************************************************************************

using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Reflection;

namespace KnightsTourUnitTests
{
    /// <summary>
    /// Taken directly from: http://andreyzavadskiy.com/2017/07/03/converting-list-to-idatareader/ with minor modifications.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ListDataReader<T> : IDataReader
            where T : class
    {
        #region Declarations
        private IEnumerator<T> _iterator;
        private List<PropertyInfo> _properties = new List<PropertyInfo>();
        #endregion

        #region Constructors
        public ListDataReader(IEnumerable<T> list)
        {
            this._iterator = list.GetEnumerator();

            _properties.AddRange(typeof(T).GetProperties());
        }
        #endregion

        #region IDataReader implementation
        public int Depth { get; }
        public bool IsClosed { get; }
        public int RecordsAffected { get; }

        public void Close()
        {
            _iterator.Dispose();
        }

        public DataTable GetSchemaTable()
        {
            throw new NotImplementedException();
        }

        public bool NextResult()
        {
            throw new NotImplementedException();
        }

        public bool Read()
        {
            return _iterator.MoveNext();
        }
        #endregion

        #region IDisposable implementation
        public void Dispose()
        {
            Close();
        }
        #endregion

        #region IDataRecord
        public string GetName(int i)
        {
            return _properties[i].Name;
        }

        public string GetDataTypeName(int i)
        {
            throw new NotImplementedException();
        }

        public Type GetFieldType(int i)
        {
            return _properties[i].PropertyType;
        }

        public object GetValue(int i)
        {
            return _properties[i].GetValue(_iterator.Current, null);
        }

        public int GetValues(object[] values)
        {
            int numberOfCopiedValues = Math.Max(_properties.Count, values.Length);

            for (int i = 0; i < numberOfCopiedValues; i++)
            {
                values[i] = GetValue(i);
            }

            return numberOfCopiedValues;
        }

        public int GetOrdinal(string name)
        {
            var index = _properties.FindIndex(p => p.Name == name);

            return index;
        }

        public bool GetBoolean(int i)
        {
            return (bool)GetValue(i);
        }

        public byte GetByte(int i)
        {
            return (byte)GetValue(i);
        }

        public long GetBytes(int i, long fieldOffset, byte[] buffer, int bufferoffset, int length)
        {
            throw new NotImplementedException();
        }

        public char GetChar(int i)
        {
            return (char)GetValue(i);
        }

        public long GetChars(int i, long fieldoffset, char[] buffer, int bufferoffset, int length)
        {
            throw new NotImplementedException();
        }

        public Guid GetGuid(int i)
        {
            return (Guid)GetValue(i);
        }

        public short GetInt16(int i)
        {
            return (short)GetValue(i);
        }

        public int GetInt32(int i)
        {
            return (int)GetValue(i);
        }

        public long GetInt64(int i)
        {
            return (long)GetValue(i);
        }

        public float GetFloat(int i)
        {
            return (float)GetValue(i);
        }

        public double GetDouble(int i)
        {
            return (double)GetValue(i);
        }

        public string GetString(int i)
        {
            return (string)GetValue(i);
        }

        public decimal GetDecimal(int i)
        {
            return (decimal)GetValue(i);
        }

        public DateTime GetDateTime(int i)
        {
            return (DateTime)GetValue(i);
        }

        public IDataReader GetData(int i)
        {
            throw new NotImplementedException();
        }

        public bool IsDBNull(int i)
        {
            return GetValue(i) == null;
        }

        public int FieldCount
        {
            get { return _properties.Count; }
        }

        object IDataRecord.this[int i]
        {
            get { return GetValue(i); }
        }

        object IDataRecord.this[string name]
        {
            
            get {
                return GetValue(GetOrdinal(name));
            }
        }
        #endregion
    }
}