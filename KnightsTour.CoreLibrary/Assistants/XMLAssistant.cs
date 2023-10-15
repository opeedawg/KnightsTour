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
// File             : XMLAssistant.cs
// ************************************************************************

using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace KnightsTour.CoreLibrary
{
    /// <summary>
    /// Extension methods for the dynamic object.
    /// </summary>
    public static class XMLAssistant
    {
        #region Declarations
        /// <summary>
        /// Defines the simple types that is directly writeable to XML.
        /// </summary>
        private static readonly Type[] _writeTypes = new[] { typeof(string), typeof(DateTime), typeof(Enum), typeof(decimal), typeof(Guid) };
        #endregion

        #region Methods
        /// <summary>
        /// Serializes the object to XML.
        /// </summary>
        /// <param name="entity">The p object.</param>
        /// <returns></returns>
        public static string Serialize(object entity)
        {
            String XmlizedString = null;
            MemoryStream memoryStream = new MemoryStream();
            XmlSerializer serializer = new XmlSerializer(entity.GetType());
            XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);

            serializer.Serialize(xmlTextWriter, entity);
            memoryStream = (MemoryStream)xmlTextWriter.BaseStream;
            XmlizedString = UTF8ByteArrayToString(memoryStream.ToArray());
            return XmlizedString;
        }
        /// <summary>
        /// Loads the object from XML.
        /// </summary>
        /// <param name="xmlString">The XML string.</param>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public static T Deserialize<T>(string xmlString)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                MemoryStream memoryStream = new MemoryStream(StringToUTF8ByteArray(xmlString));
                XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);

                return (T)serializer.Deserialize(memoryStream);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// Converts an object into an XmlDocument.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static XmlDocument ToXML(object entity)
        {
            return ToXML(Serialize(entity));
        }
        /// <summary>
        /// Returns an XML Document from valid XML text.
        /// </summary>
        /// <param name="xmlText"></param>
        /// <returns></returns>
        public static XmlDocument ToXML(string xmlText)
        {
            byte[] encodedString = Encoding.UTF8.GetBytes(xmlText);
            // Put the byte array into a stream and rewind it to the beginning
            MemoryStream ms = new MemoryStream(encodedString);
            ms.Flush();
            ms.Position = 0;
            XmlDocument document = new XmlDocument();
            document.Load(ms);
            return document;
        }
        /// <summary>
        /// Determines whether [is simple type] [the specified type].
        /// </summary>
        /// <param name="type">The type to check.</param>
        /// <returns>
        /// 	<c>true</c> if [is simple type] [the specified type]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsSimpleType(this Type type)
        {
            return type.IsPrimitive || _writeTypes.Contains(type);
        }
        /// <summary>
        /// Gets the node text.
        /// If the node does not exist, then a blank string is returned
        /// </summary>
        /// <param name="fullNode">The node.</param>
        /// <param name="xPath">The X path.</param>
        /// <returns>System.String.</returns>
        public static string GetNodeText(XmlNode fullNode, string xPath)
        {
            XmlNode node = fullNode.SelectSingleNode(xPath);
            return node == null ? string.Empty : node.InnerText;
        }
        /// <summary>
        /// Gets the nodes inner Xml.
        /// If the node does not exist, then a blank string is returned
        /// </summary>
        /// <param name="fullNode">The node.</param>
        /// <param name="xPath">The X path.</param>
        /// <returns>System.String.</returns>
        public static string GetNodeXml(XmlNode fullNode, string xPath)
        {
            XmlNode node = fullNode.SelectSingleNode(xPath);
            return node == null ? string.Empty : node.InnerXml;
        }
        #endregion

        #region Private support Methods
        /// <summary>
        /// To convert a Byte Array of Unicode values (UTF-8 encoded) to a complete String.
        /// </summary>
        /// <param name="characters">Unicode Byte Array to be converted to String</param>
        /// <returns>String converted from Unicode Byte Array</returns>
        private static String UTF8ByteArrayToString(Byte[] characters)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            String constructedString = encoding.GetString(characters);
            return (constructedString);
        }
        /// <summary>
        /// Converts the String to UTF8 Byte array and is used in De serialization
        /// </summary>
        /// <param name="pXmlString"></param>
        /// <returns></returns>
        private static Byte[] StringToUTF8ByteArray(String pXmlString)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            Byte[] byteArray = encoding.GetBytes(pXmlString);
            return byteArray;
        }
        #endregion
    }
}
