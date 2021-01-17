﻿#pragma warning disable IDE1006, IDE0017, CS0162, IDE0060, IDE0079 // Naming Styles, Simplify declaration (FQCN used), break after return, Remove unused (string[] args, Remove unnecessary suppression)

/// <summary>
/// Author: Cornelius J. van Dyk blog.cjvandyk.com @cjvandyk
/// This code is provided under GNU GPL 3.0 and is a copyrighted work of the
/// author and contributors.  Please see:
/// https://github.com/cjvandyk/Quix/blob/master/LICENSE
/// </summary>

using System;
using System.Collections.Generic;
using System.Linq;

namespace Extensions
{
    /// <summary>
    /// Extensions for the System.String class.
    /// </summary>
    public static class String
    {
        /// <summary>
        /// Get the URL root for the given string object containing a URL.
        /// For example:
        ///   "https://blog.cjvandyk.com".GetUrlRoot() 
        ///   will return "https://blog.cjvandyk.com" whereas
        ///   "https://blog.cjvandyk.com/sites/Approval".GetUrlRoot()
        ///   will also return "https://blog.cjvandyk.com".
        /// </summary>
        /// <param name="url">The System.String object containing the URL
        /// from which the root is to be extracted.</param>
        /// <returns>The root of the URL given the URL string.</returns>
        public static string GetUrlRoot(this System.String url)
        {
            string root = url.ToLower().Replace("https://", "");
            return ("https://" + root.Substring(0, root.IndexOf('/')));
        }

        /// <summary>
        /// Get the URL root for the given string builder object containing a
        /// URL.  For example:
        ///   "https://blog.cjvandyk.com".GetUrlRoot() 
        ///   will return "https://blog.cjvandyk.com" whereas
        ///   "https://blog.cjvandyk.com/sites/Approval".GetUrlRoot()
        ///   will also return "https://blog.cjvandyk.com".
        /// </summary>
        /// <param name="url">The System.Text.StringBuilder object containing
        /// the URL from which the root is to be extracted.</param>
        /// <returns>The root of the URL given the URL string.</returns>
        public static System.Text.StringBuilder GetUrlRoot(this System.Text.StringBuilder url)
        {
            url.Clear();
            url.Append(GetUrlRoot(url.ToString()));
            return url;
        }

        /// <summary>
        /// Checks if the given string contains all alphabetic characters.
        /// </summary>
        /// <param name="str">The given string object to check.</param>
        /// <param name="Classic">Switch to force RegEx comparison instead of
        /// Linq.</param>
        /// <returns>True if all characters in the given string are alphabetic,
        /// else False.</returns>
        public static bool IsAlphabetic(this System.String str, 
                                        bool Classic = false)
        {
            if (Classic)  //No LINQ available e.g. .NET 2.0
            {
                return System.Text.RegularExpressions.Regex.IsMatch(str, @"^[a-zA-Z]+$");
            }
            else  //This method is on average 670% faster than RegEx method.
            {
                return str.ToCharArray().All(Char.IsLetter);
            }
        }

        /// <summary>
        /// Checks if the given string contains all alphabetic characters.
        /// </summary>
        /// <param name="str">The given string builder object to check.</param>
        /// <param name="Classic">Switch to force RegEx comparison instead
        /// of Linq.</param>
        /// <returns>True if all characters in the given string are alphabetic,
        /// else False.</returns>
        public static bool IsAlphabetic(this System.Text.StringBuilder str, 
                                        bool Classic = false)
        {
            return IsAlphabetic(str.ToString(), Classic);
        }

        /// <summary>
        /// Checks if the given string contains only alphabetic and numeric 
        /// characters.
        /// </summary>
        /// <param name="str">The given string object to check.</param>
        /// <param name="Classic">Switch to force RegEx comparison instead of 
        /// Linq.</param>
        /// <returns>True if all characters in the given string are either 
        /// alphabetic or numeric, else False.</returns>
        public static bool IsAlphaNumeric(this System.String str,
                                          bool Classic = false)
        {
            if (Classic)  //No LINQ available e.g. .NET 2.0
            {
                return System.Text.RegularExpressions.Regex.IsMatch(str, @"^[a-zA-Z0-9]+$");
            }
            else  //This method is on average 670% faster than RegEx method.
            {
                return str.ToCharArray().All(Char.IsLetterOrDigit);
            }
        }

        /// <summary>
        /// Checks if the given string contains only alphabetic and numeric 
        /// characters.
        /// </summary>
        /// <param name="str">The given string builder object to check.</param>
        /// <param name="Classic">Switch to force RegEx comparison instead of 
        /// Linq.</param>
        /// <returns>True if all characters in the given string are either 
        /// alphabetic or numeric, else False.</returns>
        public static bool IsAlphaNumeric(this System.Text.StringBuilder str,
                                          bool Classic = false)
        {
            return IsAlphaNumeric(str.ToString(), Classic);
        }

        /// <summary>
        /// Checks if a given System.String object is an email address.
        /// </summary>
        /// <param name="str">The System.String to validate as email.</param>
        /// <returns>True if email, false if not.</returns>
        public static bool IsEmail(this System.String str)
        {
            try
            {
                var email = new System.Net.Mail.MailAddress(str);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Checks if a given System.Text.StringBuilder object is an email
        /// address.
        /// </summary>
        /// <param name="str">The System.Text.StringBuilder to validate as
        /// email.</param>
        /// <returns>True if email, false if not.</returns>
        public static bool IsEmail(this System.Text.StringBuilder str)
        {
            return IsEmail(str.ToString());
        }

        /// <summary>
        /// Checks if the given string contains all numeric characters.
        /// </summary>
        /// <param name="str">The given string object to check.</param>
        /// <param name="Classic">Switch to force RegEx comparison instead
        /// of Linq.</param>
        /// <returns>True if all characters in the given string are numeric,
        /// else False.</returns>
        public static bool IsNumeric(this System.String str, 
                                     bool Classic = false)
        {
            if (Classic)  //No LINQ available e.g. .NET 2.0
            {
                return System.Text.RegularExpressions.Regex.IsMatch(str, @"^[0-9]+$");
            }
            else  //This method is on average 670% faster than RegEx method.
            {
                return str.ToCharArray().All(Char.IsDigit);
            }
        }

        /// <summary>
        /// Checks if the given string contains all numeric characters.
        /// </summary>
        /// <param name="str">The given string builder object to check.</param>
        /// <param name="Classic">Switch to force RegEx comparison instead of 
        /// Linq.</param>
        /// <returns>True if all characters in the given string are numeric,
        /// else False.</returns>
        public static bool IsNumeric(this System.Text.StringBuilder str, 
                                     bool Classic = false)
        {
            return IsNumeric(str.ToString(), Classic);
        }

        /// <summary>
        /// Check if the given string contains only the characters in the 
        /// Chars array being passed.
        /// </summary>
        /// <param name="str">The given string object to check.</param>
        /// <param name="Chars">The array of valid characters that are checked
        /// in the string.</param>
        /// <param name="Classic">Switch to force RegEx comparison instead of
        /// Linq.</param>
        /// <returns>True if the given string contains only characters in the 
        /// Chars array, else False.</returns>
        public static bool IsChar(this System.String str, 
                                  char[] Chars, 
                                  bool Classic = false)
        {
            if (Classic)  //No LINQ available e.g. .NET 2.0
            {
                string comparor = @"^[";
                foreach (char c in Chars)
                {
                    comparor += c;
                }
                comparor += "]+$";
                return System.Text.RegularExpressions.Regex.IsMatch(str, 
                                                                    comparor);
            }
            else
            {
                foreach (char c in str.ToCharArray())
                {
                    if (!Chars.Contains(c))
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        /// <summary>
        /// Check if the given string contains only the characters in the
        /// Chars array being passed.
        /// </summary>
        /// <param name="str">The given string builder object to check.</param>
        /// <param name="Chars">The array of valid characters that are checked
        /// in the string.</param>
        /// <param name="Classic">Switch to force RegEx comparison instead of
        /// Linq.</param>
        /// <returns>True if the given string contains only characters in the
        /// Chars array, else False.</returns>
        public static bool IsChar(this System.Text.StringBuilder str, 
                                  char[] Chars, 
                                  bool Classic = false)
        {
            return IsChar(str.ToString(), Chars, Classic);
        }

        /// <summary>
        /// Check if the given string object containing a URL, is that of the
        /// URL root only.  Returns True if so, False if not.  For example:
        ///   "https://blog.cjvandyk.com".IsUrlRootOnly() 
        ///   will return True whereas
        ///   "https://blog.cjvandyk.com/sites/Approval".IsUrlRootOnly()
        ///   will return False.
        /// </summary>
        /// <param name="url">The System.String object containing the URL to 
        /// be checked.</param>
        /// <returns>True if the URL is a root, False if not.</returns>
        public static bool IsUrlRoot(this System.String url)
        {
            if (url.ToLower().Replace("https://", "").IndexOf('/') == -1)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Check if the given string builder object containing a URL, is that
        ///  of the URL root only.  Returns True if so, False if not.  
        ///  For example:
        ///   "https://blog.cjvandyk.com".IsUrlRootOnly() 
        ///   will return True whereas
        ///   "https://blog.cjvandyk.com/sites/Approval".IsUrlRootOnly()
        ///   will return False.
        /// </summary>
        /// <param name="url">The System.Text.StringBuilder object containing 
        /// the URL to be checked.</param>
        /// <returns>True if the URL is a root, False if not.</returns>
        public static bool IsUrlRoot(this System.Text.StringBuilder url)
        {
            return IsUrlRoot(url.ToString());
        }

        /// <summary>
        /// Returns the number of sentences in the given string object.
        /// </summary>
        /// <param name="str">A System.String object.</param>
        /// <returns>The number of sentences in the given object.</returns>
        public static int Lines(this System.String str)
        {
            return str.Split(new char[] { '\n' },
                             StringSplitOptions.RemoveEmptyEntries)
                      .Length;
        }

        /// <summary>
        /// Returns the number of sentences in the given string builder object.
        /// </summary>
        /// <param name="str">A System.Text.StringBuilder object.</param>
        /// <returns>The number of sentences in the given object.</returns>
        public static int Lines(this System.Text.StringBuilder str)
        {
            return Lines(str.ToString());
        }

        /// <summary>
        /// Returns a string containing 1 - 10 paragraphs of dummy text
        /// in lorem ipsum style.
        /// </summary>
        /// <param name="str">The System.String object to be populated with
        /// the dummy text.</param>
        /// <param name="Paragraphs">An integer with the number of paragraphs
        /// to be returned.  Presently supports 1-10</param>
        /// <returns>The string containing the generated dummy text.</returns>
        public static string LoremIpsum(this System.String str, 
                                        int Paragraphs)
        {
            str = null;
            for (int i = 0; i < Paragraphs; i++)
            {
                str += Extensions.Constants.LoremIpsum[i] + '\n' + '\n';
            }
            return str;
        }

        /// <summary>
        /// Returns a string containing 1 - 10 paragraphs of dummy text
        /// in lorem ipsum style.
        /// </summary>
        /// <param name="str">The System.String object to be populated with
        /// the dummy text.</param>
        /// <param name="Paragraphs">An integer with the number of paragraphs
        /// to be returned.  Presently supports 1-10</param>
        /// <returns>The string containing the generated dummy text.</returns>
        public static System.Text.StringBuilder LoremIpsum(this System.Text.StringBuilder str, 
                                                           int Paragraphs)
        {
            str.Clear();
            str.Append(LoremIpsum(str.ToString(), Paragraphs));
            return str;
        }

        /// <summary>
        /// Takes a given System.String representing Morse code and audiblize
        /// it according to standards.
        /// https://www.infoplease.com/encyclopedia/science/engineering/electrical/morse-code
        /// Assumes the input value to be in Morse code format already.
        /// Use .ToMorseCode() to pre-convert text if needed.
        /// </summary>
        /// <param name="str">The System.String text in Morse code format.</param>
        /// <param name="frequency">The beep frequency.</param>
        /// <param name="duration">The duration of a dot beep in ms.</param>
        public static void MorseCodeBeep(this System.String str, 
                                         int frequency = 999, 
                                         int duration = 200)
        {
            foreach (char c in str)
            {
                switch (c)
                {
                    case '.':
                        Console.Beep(frequency, duration);
                        break;

                    case '-':
                        Console.Beep(frequency, duration * 3);
                        break;

                    case ' ':
                        Console.Beep(frequency, duration * 6);
                        break;
                }
                System.Threading.Thread.Sleep(duration * 3);
            }
        }

        /// <summary>
        /// Takes a given System.Text.StringBuilder representing Morse code
        /// and audiblize it according to standards.
        /// https://www.infoplease.com/encyclopedia/science/engineering/electrical/morse-code
        /// Assumes the input value to be in Morse code format already.
        /// Use .ToMorseCode() to pre-convert text if needed.
        /// </summary>
        /// <param name="str">The System.Text.StringBuilder text in Morse
        /// code format.</param>
        /// <param name="frequency">The beep frequency.</param>
        /// <param name="duration">The duration of a dot beep in ms.</param>
        public static void MorseCodeBeep(this System.Text.StringBuilder str, 
                                         int frequency = 999, 
                                         int duration = 200)
        {
            MorseCodeBeep(str.ToString(), frequency, duration);
        }

        /// <summary>
        /// Takes a given string and replaces 1 to n tokens in the string
        /// with replacement tokens as defined in the given Dictionary
        /// of strings.
        /// </summary>
        /// <param name="str">The System.String object upon which token
        /// replacement is to be done.</param>
        /// <param name="tokens">A Dictionary of tokens and replacement
        /// strings to be used for replacement.</param>
        /// <returns>A System.String value with tokens replaced.</returns>
        public static string ReplaceTokens(this System.String str, 
                                           Dictionary<string, string> tokens)
        {
            string returnValue = str;
            foreach (string key in tokens.Keys)
            {
                returnValue = returnValue.Replace(key, tokens[key]);
            }
            return returnValue;
        }

        /// <summary>
        /// Takes a given string and replaces 1 to n tokens in the string
        /// with replacement tokens as defined in the given Dictionary
        /// of strings.
        /// </summary>
        /// <param name="str">The System.Text.StringBuilder upon which
        /// token replacement is to be one.</param>
        /// <param name="tokens">A Dictionary of tokens and replacement
        /// strings to be used for replacement.</param>
        /// <returns>A System.Text.StringBuilder value with tokens replaced.</returns>
        public static System.Text.StringBuilder ReplaceTokens(this System.Text.StringBuilder str, 
                                                              Dictionary<string, string> tokens)
        {
            str.Clear();
            str.Append(ReplaceTokens(str.ToString(), tokens));
            return str;
        }

        /// <summary>
        /// Returns the binary representation of a given string object.
        /// </summary>
        /// <param name="str">The System.String object to convert to binary.</param>
        /// <returns></returns>
        public static string ToBinary(this System.String str)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach (byte b in System.Text.ASCIIEncoding.UTF8.GetBytes(
                str.ToCharArray()))
            {
                sb.Append(Convert.ToString(b, 2) + " ");
            }
            return sb.ToString();
        }

        /// <summary>
        /// Returns the binary representation of a given StringBuilder object.
        /// </summary>
        /// <param name="str">The System.Text.StringBuilder object to convert
        /// to binary.</param>
        /// <returns></returns>
        public static string ToBinary(this System.Text.StringBuilder str)
        {
            return ToBinary(str.ToString());
        }

        /// <summary>
        /// Convert a System.String to its Enum value.
        /// </summary>
        /// <typeparam name="T">The enum type.</typeparam>
        /// <param name="str">The string to match to an enum.</param>
        /// <returns>The enum value.</returns>
        public static T ToEnum<T>(this System.String str)
        {
            return (T)Enum.Parse(typeof(T), str);
        }

        /// <summary>
        /// Convert a System.String to its Enum value.
        /// </summary>
        /// <typeparam name="T">The enum type.</typeparam>
        /// <param name="str">The string to match to an enum.</param>
        /// <returns>The enum value.</returns>
        public static T ToEnum<T>(this System.Text.StringBuilder str)
        {
            return (str.ToString().ToEnum<T>());
        }

        /// <summary>
        /// Convert given System.String to its Morse code representation.
        /// Undefined characters will return in the format:
        /// <Undefined:[char]>
        /// For example:
        /// "sos@".ToMorseCode()
        /// will return
        /// "...---...<Undefined:[@]>"
        /// </summary>
        /// <param name="str">The given string to convert to Morse code.</param>
        /// <param name="includeSpaces">Are spaces included in translation.</param>
        /// <returns>The Morse code represenation of the given string.</returns>
        public static string ToMorseCode(this System.String str, 
                                         bool includeSpaces = true)
        {
            System.Text.StringBuilder returnValue = 
                new System.Text.StringBuilder();
            string tempStr = "";
            foreach (char c in str.ToLower())
            {
                if (Constants.MorseCode.TryGetValue(c, out tempStr))
                {
                    returnValue.Append(c != ' ' ? tempStr : 
                        (includeSpaces ? tempStr : ""));
                }
                else
                {
                    returnValue.Append("<Undefined:[" + c + "]>");
                }
            }
            return returnValue.ToString();
        }

        /// <summary>
        /// Convert given System.Text.Stringbuilder object to its Morse code
        /// representation.
        /// Undefined characters will return in the format:
        /// <Undefined:[char]>
        /// For example:
        /// "sos@".ToMorseCode()
        /// will return
        /// "...---...<Undefined:[@]>"
        /// </summary>
        /// <param name="str">The given string to convert to Morse code.</param>
        /// <param name="includeSpaces">Are spaces included in translation.</param>
        /// <returns>The Morse code represenation of the given string.</returns>
        public static string ToMorseCode(this System.Text.StringBuilder str, 
                                         bool includeSpaces = true)
        {
            return (str.ToString());
        }

        /// <summary>
        /// Returns the number of words in the given string object.
        /// </summary>
        /// <param name="str">A System.String object for which to count 
        /// words.</param>
        /// <returns>The number of words in the given object.</returns>
        public static int Words(this System.String str)
        {
            return str.Split(new char[] { ' ',
                                          '.',
                                          '?',
                                          '!',
                                          ';' },
                             StringSplitOptions.RemoveEmptyEntries)
                      .Length;
        }

        /// <summary>
        /// Returns the number of words in the given string builder object.
        /// </summary>
        /// <param name="str">A System.Text.StringBuilder object for which
        /// to count words.</param>
        /// <returns>The number of words in the given object.</returns>
        public static int Words(this System.Text.StringBuilder str)
        {
            return Words(str.ToString());
        }

        //public static bool ToEmailSafeTextFile(this System.String filePath)
        //{
        //    if (System.IO.File.Exists(filePath))
        //    {
        //        System.IO.File.WriteAllText(
        //            filePath + ".txt",
        //            Convert.ToBase64String(
        //                System.IO.File.ReadAllBytes(filePath)));
        //        return true;
        //    }
        //    return false;
        //}

        //public static bool FromEmailSafeTextFile(this System.String filePath)
        //{
        //    if (System.IO.File.Exists(filePath))
        //    {
        //        System.IO.File.WriteAllBytes(
        //            filePath.ToLower()
        //                    .TrimEnd(new char[] { 
        //                        '.', 
        //                        't', 
        //                        'x', 
        //                        't'}),
        //            Convert.FromBase64String(
        //                System.IO.File.ReadAllText(filePath)));
        //        return true;
        //    }
        //    return false;
        //}
    }
}
