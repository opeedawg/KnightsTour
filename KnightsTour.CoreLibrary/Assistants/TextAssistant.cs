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
// Created          : January 21, 2023 4:54:44 AM
// File             : TextAssistant.cs
// ************************************************************************

using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace KnightsTour.CoreLibrary
{
    /// <summary>
    /// Assists in any alpha functions
    /// </summary>
    public class TextAssistant
    {
        #region Declarations
        private static Random random = new Random();
        #endregion

        #region Methods
        public static string FormatHumanTimeSpan(decimal totalSeconds)
        {
            if (totalSeconds == 0)
                return totalSeconds.ToString();
            else
            {
                TimeSpan ts = new TimeSpan(0, 0, 0, int.Parse(Math.Floor(totalSeconds).ToString()), int.Parse((Math.Round((totalSeconds - Math.Floor(totalSeconds)) * 100, 0)).ToString()));

                if (totalSeconds < 60)
                    return $"{totalSeconds} seconds";
                else if (totalSeconds < 60 * 60)
                    return $"{ts.Minutes} minutes {ts.Seconds}.{ts.Milliseconds} seconds";
                else if (ts.Hours == 1)
                    return $"{ts.Hours} hour, {ts.Minutes} minutes and {ts.Seconds}.{ts.Milliseconds} seconds";
                else
                    return $"{ts.Hours} hours, {ts.Minutes} minutes and {ts.Seconds}.{ts.Milliseconds} seconds";
            }
        }
        /// <summary>
        /// Determines if the word begins with a vowel.
        /// </summary>
        /// <param name="word">The word.</param>
        /// <returns>A static string.</returns>
        public static bool BeginsWithAVowel(string word)
        {
            if (!string.IsNullOrEmpty(word))
            {
                word = word.ToUpper();
                return word.StartsWith("A") || word.StartsWith("E") || word.StartsWith("I") || word.StartsWith("O") || word.StartsWith("U");
            }
            return false;
        }
        /// <summary>
        /// Splits the on capitals.
        /// </summary>
        /// <param name="phrase">The original string.</param>
        /// <returns>System.String.</returns>
        public static string SplitOnCapitals(string phrase)
        {
            if (!string.IsNullOrEmpty(phrase))
            {
                string newString = string.Empty;
                foreach (char character in phrase.ToCharArray())
                {
                    if ((int)character >= 65 && (int)character <= 90)
                        newString += " " + character.ToString();
                    else
                        newString += character.ToString();
                }
                return newString.Trim();
            }
            return string.Empty;
        }
        /// <summary>
        /// Splits the on underscore.
        /// </summary>
        /// <param name="phrase">The original string.</param>
        /// <returns>System.String.</returns>
        public static string SplitOnUnderscore(string phrase)
        {
            if (!string.IsNullOrEmpty(phrase))
            {
                return phrase.Replace('_', ' ').Trim();
            }
            return string.Empty;
        }
        /// <summary>
        /// Determines whether the specified word is capitalized.
        /// </summary>
        /// <param name="word">The word.</param>
        /// <returns><c>true</c> if the specified word is capitalized; otherwise, <c>false</c>.</returns>
        public static bool IsCapitalized(string word)
        {
            if (!string.IsNullOrEmpty(word))
            {
                char[] wordCharacters = word.ToCharArray();

                return (int)wordCharacters[0] >= 65 && (int)wordCharacters[0] <= 90;
            }
            return false;
        }
        /// <summary>
        /// Capitalizes the first letter.
        /// </summary>
        /// <param name="word">The word.</param>
        /// <param name="lowerCaseEverythingElse">Should the rest of the characters be made lower case?</param>
        /// <returns>System.String.</returns>
        public static string CapitalizeFirstLetter(string word, bool lowerCaseEverythingElse = false)
        {
            if (!string.IsNullOrEmpty(word))
            {
                if(lowerCaseEverythingElse)
                    return word[0].ToString().ToUpper() + word.Substring(1, word.Length - 1).ToLower();
                else
                    return word[0].ToString().ToUpper() + word.Substring(1, word.Length - 1);
            }
            return string.Empty;
        }
        /// <summary>
        /// Capitalizes the each word.
        /// </summary>
        /// <param name="phrase">The phrase.</param>
        /// <returns>System.String.</returns>
        public static string CapitalizeEachWord(string phrase)
        {
            string correctedPhrase = string.Empty;
            if (!string.IsNullOrEmpty(phrase))
            {
                string[] words = phrase.ToLower().Trim().Replace('_', ' ').Split(' ');
                foreach (string word in words)
                    correctedPhrase += CapitalizeFirstLetter(word) + " ";
            }

            return correctedPhrase.Trim();
        }
        /// <summary>
        /// Decapitalizes the first letter.
        /// </summary>
        /// <param name="word">The word.</param>
        /// <returns>System.String.</returns>
        public static string DecapitalizeFirstLetter(string word, bool lowerCaseEverythingElse = false)
        {
            if (!string.IsNullOrEmpty(word))
            {
                if(lowerCaseEverythingElse)
                    return word[0].ToString().ToLower() + word.Substring(1, word.Length - 1).ToLower();
                else
                    return word[0].ToString().ToLower() + word.Substring(1, word.Length - 1);
            }
            return string.Empty;
        }
        /// <summary>
        /// Pluralizes the word.
        /// </summary>
        /// <param name="word">The word.</param>
        /// <returns>System.String.</returns>
        public static string PluralizeWord(string word)
        {
            //ch, sh, s, x, or z
            if (!string.IsNullOrEmpty(word))
            {
                if (word.EndsWith("ss", StringComparison.OrdinalIgnoreCase) || word.EndsWith("ies", StringComparison.OrdinalIgnoreCase))
                    return word;
                else if (word.EndsWith("y", StringComparison.OrdinalIgnoreCase) && word.Length > 1 && "aeiouAEIOU".IndexOf(word.ToLower()[word.Length - 2]) < 0)
                    return word.Substring(0, word.Length - 1) + "ies";
                else if (
                    word.EndsWith("ch", StringComparison.OrdinalIgnoreCase) || 
                    word.EndsWith("sh", StringComparison.OrdinalIgnoreCase) ||
                    word.EndsWith("s", StringComparison.OrdinalIgnoreCase) ||
                    word.EndsWith("x", StringComparison.OrdinalIgnoreCase) ||
                    word.EndsWith("z", StringComparison.OrdinalIgnoreCase))
                    return word + "es";
                else
                    return word + "s";
            }
            return string.Empty;
        }
        /// <summary>
        /// Pasts the tense word.
        /// </summary>
        /// <param name="word">The word.</param>
        /// <returns>System.String.</returns>
        public static string PastTenseWord(string word)
        {
            if (!string.IsNullOrEmpty(word))
            {
                if (word.Length > 2)
                {
                    if (word.EndsWith("ied", StringComparison.OrdinalIgnoreCase) || word.EndsWith("ed", StringComparison.OrdinalIgnoreCase))
                        return word;
                    else if (word.EndsWith("y", StringComparison.OrdinalIgnoreCase) && word.Length > 1 && "aeiouAEIOU".IndexOf(word.ToLower()[word.Length - 2]) < 0)
                        return word.Substring(0, word.Length - 1) + "ied";
                    else if (word.EndsWith("e", StringComparison.OrdinalIgnoreCase))
                        return word + "d";
                }
                //Nothing can be done
                return word;
            }
            return string.Empty;
        }
        /// <summary>
        /// Determines whether the specified word is alpha.
        /// </summary>
        /// <param name="word">The word.</param>
        /// <param name="allowWhiteSpace">Should a blank space be treated as OK or not.</param>
        /// <returns><c>true</c> if the specified word is alpha; otherwise, <c>false</c>.</returns>
        public static bool IsAlpha(string word, bool allowWhiteSpace = true)
        {
            if (!string.IsNullOrEmpty(word))
            {
                Regex rg = new Regex(@"^[A-Za-z\s]*$");
                if (!allowWhiteSpace)
                    rg = new Regex(@"^[a-zA-Z]*$");
                return rg.IsMatch(word);
            }
            return false;
        }
        /// <summary>
        /// Determines whether the specified word is numeric.
        /// </summary>
        /// <param name="word">The word.</param>
        /// <param name="allowForDecimal">Should decimals be allowed</param>
        /// <returns><c>true</c> if the specified word is numeric; otherwise, <c>false</c>.</returns>
        public static bool IsNumeric(string word, bool allowForDecimal = true)
        {
            if (!string.IsNullOrEmpty(word))
            {
                Regex rg = new Regex(@"^(\d*\.)?\d+$");
                if (!allowForDecimal)
                    rg = new Regex(@"^[0-9]+$");
                return rg.IsMatch(word);
            }
            return false;
        }
        /// <summary>
        /// Returns the only numbers.
        /// </summary>
        /// <param name="word">The word.</param>
        /// <returns>System.String.</returns>
        public static string ReturnOnlyNumbers(string word)
        {
            if (!string.IsNullOrEmpty(word))
            {
                string newWord = string.Empty;
                if (word.Length > 0)
                {
                    char[] wordCharacters = word.ToCharArray();
                    foreach (char character in wordCharacters)
                    {
                        if ((int)character >= 48 && (int)character <= 57)
                            newWord += character.ToString();
                    }
                }
                return newWord;
            }
            return string.Empty;
        }
        /// <summary>
        /// Determines whether [is alpha numeric] [the specified word].
        /// </summary>
        /// <param name="word">The word.</param>
        /// <param name="allowWhiteSpace">Should a blank space be treated as OK or not.</param>
        /// <param name="allowForDecimal">Should decimals be allowed</param>
        /// <returns><c>true</c> if [is alpha numeric] [the specified word]; otherwise, <c>false</c>.</returns>
        public static bool IsAlphaNumeric(string word, bool allowWhiteSpace = true, bool allowForDecimal = true)
        {
            if (!string.IsNullOrEmpty(word))
            {
                Regex rg = new Regex(@"^[A-Za-z0-9\s\.]*$");
                if (!allowWhiteSpace && allowForDecimal)
                    rg = new Regex(@"^[A-Za-z0-9\.]*$");
                else if (allowWhiteSpace && !allowForDecimal)
                    rg = new Regex(@"^[A-Za-z0-9\s]*$");
                else if (!allowWhiteSpace && !allowForDecimal)
                    rg = new Regex(@"^[A-Za-z0-9]*$");
                return rg.IsMatch(word);
            }
            return false;
        }
        /// <summary>
        /// Des the pluralize word.
        /// </summary>
        /// <param name="word">The word.</param>
        /// <returns>System.String.</returns>
        public static string DePluralizeWord(string word)
        {
            if (!string.IsNullOrEmpty(word))
            {
                word = word.Trim();
                if (word.EndsWith("ies", StringComparison.OrdinalIgnoreCase))
                    return word.Substring(0, word.Length - 3) + "y";
                else if (word.EndsWith("ses", StringComparison.OrdinalIgnoreCase))
                    return word.Substring(0, word.Length - 2);
                else if (word.EndsWith("ss", StringComparison.OrdinalIgnoreCase) || word.EndsWith("ous", StringComparison.OrdinalIgnoreCase) || word.EndsWith("us", StringComparison.OrdinalIgnoreCase) || word.EndsWith("is", StringComparison.OrdinalIgnoreCase))
                    return word;
                else if (word.EndsWith("s", StringComparison.OrdinalIgnoreCase))
                    return word.Substring(0, word.Length - 1);
                else
                    return word;
            }
            return string.Empty;
        }
        /// <summary>Splits the text on words, includes logic to handle acronyms.</summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        public static string SplitOnWords(string text)
        {
            //Rule is: When there is a CAPITAL followed by a lower_case then split
            if (string.IsNullOrEmpty(text)) return text;
            if (text.Length == 1) return text.ToUpper();

            //text exists and is at least 2 characters long
            string label = string.Empty;
            bool currentCapital = false;
            bool nextCapital = false;
            bool previousCapital = false;
            bool justAddedSpace = false;
            //ABC
            for (int i = 0; i < text.Length; i++)
            {
                if (i > 0) previousCapital = char.IsUpper(text[i - 1]);
                currentCapital = char.IsUpper(text[i]); //A

                if (i == 0)
                    label += text[0].ToString().ToUpper();
                else if (i == text.Length - 1) //Final letter
                {
                    if (!currentCapital || (currentCapital && previousCapital))
                        label += text[i];
                    else //it is not a capital OR it is a capital and the previous is a small case
                        label += $" {text[i].ToString().ToLower()}";
                }
                else
                {
                    nextCapital = char.IsUpper(text[i + 1]);
                    if (!previousCapital && currentCapital && !nextCapital)
                    {
                        label += " " + text[i].ToString().ToLower();
                        justAddedSpace = true;
                    }
                    else if (!previousCapital && currentCapital && nextCapital)
                    {
                        label += " " + text[i].ToString();
                        justAddedSpace = true;
                    }
                    else if (previousCapital && currentCapital && !nextCapital)
                    {
                        if (!justAddedSpace)
                            label += " " + text[i];
                        else
                            label += text[i];
                    }
                    else
                    {
                        label += text[i];
                        justAddedSpace = false;
                    }
                }
            }
            return label;
        }
        /// <summary>Pascals the case.</summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        public static string PascalCase(string text)
        {
            text = text.Replace("_", " ");
            return CapitalizeEachWord(SplitOnWords(text).ToLower()).Replace(" ", "");
        }
        /// <summary>Camels the case.</summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        public static string CamelCase(string text)
        {
            return DecapitalizeFirstLetter(PascalCase(text));
        }
        /// <summary>
        /// Returns the only numbers.
        /// </summary>
        /// <param name="word">The word.</param>
        /// <returns>System.String.</returns>
        public static string OnlyDigits(string word)
        {
            if (!string.IsNullOrEmpty(word))
            {
                return new string(word.Where(Char.IsNumber).ToArray());
            }
            return string.Empty;
        }
        /// <summary>Called when [letters].</summary>
        /// <param name="word">The word.</param>
        /// <returns></returns>
        public static string OnlyLetters(string word)
        {
            if (!string.IsNullOrEmpty(word))
            {
                return new string(word.Where(Char.IsLetter).ToArray());
            }
            return string.Empty;
        }
        /// <summary>Called when [digits or letters].</summary>
        /// <param name="word">The word.</param>
        /// <returns></returns>
        public static string OnlyDigitsOrLetters(string word, bool stripStartingDigits = false)
        {
            if (!string.IsNullOrEmpty(word))
            {
                string cleanWord = new string(word.Where(Char.IsLetterOrDigit).ToArray());
                if (stripStartingDigits)
                {
                    string cleanWord2 = string.Empty;
                    bool foundLetter = false;
                    foreach (char c in cleanWord.ToCharArray())
                    {
                        if (foundLetter)
                            cleanWord2 += c;
                        else if (char.IsLetter(c))
                        {
                            foundLetter = true;
                            cleanWord2 += c;
                        }
                    }
                    return cleanWord2;
                }
                else
                    return cleanWord;
            }
            return string.Empty;
        }
        /// <summary>
        /// Generates a random string of text with no spaces of the given length.
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        #endregion
    }
}
