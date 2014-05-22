namespace Telerik.ILS.Common
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;

    ///<summary> 
    ///Static class containing extension methods of the System.String class.
    ///</summary> 
    public static class StringExtensions
    {
        static string asd = new String('5',3);

        ///<summary> 
        ///Converts string  in the hexadecimal representation of its seqence of byte values.
        ///</summary> 
        public static string ToMd5Hash(this string input)
        {
            var md5Hash = MD5.Create();
            
            // Convert the input string to a byte array and compute the hash.
            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new StringBuilder to collect the bytes
            // and create a string.
            var builder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                builder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return builder.ToString();
        }

        ///<summary> 
        ///Converts an instance of the System.String class to a boolean variable 
        ///if it is a valid one such as: "true", "ok", "yes", "1" or "да".
        ///</summary>
        public static bool ToBoolean(this string input)
        {
            var stringTrueValues = new[] { "true", "ok", "yes", "1", "да" };
            return stringTrueValues.Contains(input.ToLower());
        }
        
        ///<summary> 
        ///Parses an instance of the System.String class to a signed 16-bit integer value
        ///(instance of struct System.Int16) representation. If not possible, returns false.
        ///</summary>
        public static short ToShort(this string input)
        {
            short shortValue;
            short.TryParse(input, out shortValue);
            return shortValue;
        }

        ///<summary> 
        ///Parses an instance of the System.String class  to a signed 32-bit integer value
        ///(instance of struct System.Int32) representation. If not possible, returns false.
        ///</summary>
        public static int ToInteger(this string input)
        {
            int integerValue;
            int.TryParse(input, out integerValue);
            return integerValue;
        }

        ///<summary> 
        ///Parses an instance of the System.String class  to a signed 64-bit integer 
        ///value(instance of System.Int64) representation. If not possible, returns false.
        ///</summary>
        public static long ToLong(this string input)
        {
            long longValue;
            long.TryParse(input, out longValue);
            return longValue;
        }

        ///<summary> 
        ///Parses an instance of the System.String class to an instance of time
        ///(instance of struct System.DateTime) representation. If not possible, returns false.
        ///</summary>
        public static DateTime ToDateTime(this string input)
        {
            DateTime dateTimeValue;
            DateTime.TryParse(input, out dateTimeValue);
            return dateTimeValue;
        }

        ///<summary> 
        ///Makes the first letter capitalized in an instance of the System.String class .
        ///</summary>
        public static string CapitalizeFirstLetter(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            return input.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture) + input.Substring(1, input.Length - 1);
        }

        ///<summary> 
        ///Gets the string between two substring in an instance of the System.String class, from a predefined starting position.
        ///If one of the substrings is not contained in the intial string, retunrs an empty string.
        ///</summary>
        public static string GetStringBetween(this string input, string startString, string endString, int startFrom = 0)
        {
            input = input.Substring(startFrom);
            startFrom = 0;

            //Check if the both passed string parameters are contained in the initial one.
            if (!input.Contains(startString) || !input.Contains(endString))
            {
                return string.Empty;
            }

            //Check if the starting position precedes the position of the first substring and if so returns an empty string.
            var startPosition = input.IndexOf(startString, startFrom, StringComparison.Ordinal) + startString.Length;
            if (startPosition == -1)
            {
                return string.Empty;
            }

            var endPosition = input.IndexOf(endString, startPosition, StringComparison.Ordinal);
            if (endPosition == -1)
            {
                return string.Empty;
            }

            return input.Substring(startPosition, endPosition - startPosition);
        }

        ///<summary> 
        ///Converts all cyrillic letters to latin in an instace of the System.String class.
        ///</summary>
        public static string ConvertCyrillicToLatinLetters(this string input)
        {
            var bulgarianLetters = new[]
            {
                "а", "б", "в", "г", "д", "е", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п",
                "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ь", "ю", "я"
            };
            var latinRepresentationsOfBulgarianLetters = new[]
            {
                "a", "b", "v", "g", "d", "e", "j", "z", "i", "y", "k",
                "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "h",
                "c", "ch", "sh", "sht", "u", "i", "yu", "ya"
            };
            for (var i = 0; i < bulgarianLetters.Length; i++)
            {
                input = input.Replace(bulgarianLetters[i], latinRepresentationsOfBulgarianLetters[i]);
                input = input.Replace(bulgarianLetters[i].ToUpper(), latinRepresentationsOfBulgarianLetters[i].CapitalizeFirstLetter());
            }

            return input;
        }

        ///<summary> 
        ///Converts all latin letters to cyrillic in an instace of the System.String class.
        ///</summary>
        public static string ConvertLatinToCyrillicKeyboard(this string input)
        {
            var latinLetters = new[]
            {
                "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p",
                "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
            };

            var bulgarianRepresentationOfLatinKeyboard = new[]
            {
                "а", "б", "ц", "д", "е", "ф", "г", "х", "и", "й", "к",
                "л", "м", "н", "о", "п", "я", "р", "с", "т", "у", "ж",
                "в", "ь", "ъ", "з"
            };

            for (int i = 0; i < latinLetters.Length; i++)
            {
                input = input.Replace(latinLetters[i], bulgarianRepresentationOfLatinKeyboard[i]);
                input = input.Replace(latinLetters[i].ToUpper(), bulgarianRepresentationOfLatinKeyboard[i].ToUpper());
            }

            return input;
        }

        ///<summary> 
        ///Converts an instance of the System.String class to a valid user name.
        ///</summary>
        public static string ToValidUsername(this string input)
        {
            input = input.ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.]+", string.Empty);
        }

        ///<summary> 
        ///Converts an instance of the System.String class to a valid file name.
        ///</summary>
        public static string ToValidLatinFileName(this string input)
        {
            input = input.Replace(" ", "-").ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.\-]+", string.Empty);
        }

        ///<summary> 
        ///Gets a specified number characters in the begining in an instace of the System.String class
        ///</summary>
        public static string GetFirstCharacters(this string input, int charsCount)
        {
            return input.Substring(0, Math.Min(input.Length, charsCount));
        }

        ///<summary> 
        ///Checks if an instance of the System.String class is a valid file name and gets its extension type.
        ///Returns an empty string if the string is an invalid file name.
        ///</summary>
        public static string GetFileExtension(this string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return string.Empty;
            }

            string[] fileParts = fileName.Split(new[] { "." }, StringSplitOptions.None);
            if (fileParts.Count() == 1 || string.IsNullOrEmpty(fileParts.Last()))
            {
                return string.Empty;
            }

            return fileParts.Last().Trim().ToLower();
        }
        ///<summary> 
        ///Gets the content type of the System.String class instance.
        ///</summary>
        public static string ToContentType(this string fileExtension)
        {
            var fileExtensionToContentType = new Dictionary<string, string>
            {
                { "jpg", "image/jpeg" },
                { "jpeg", "image/jpeg" },
                { "png", "image/x-png" },
                {
                        "docx",
                        "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
                },
                { "doc", "application/msword" },
                { "pdf", "application/pdf" },
                { "txt", "text/plain" },
                { "rtf", "application/rtf" }
            };
            if (fileExtensionToContentType.ContainsKey(fileExtension.Trim()))
            {
                return fileExtensionToContentType[fileExtension.Trim()];
            }

            return "application/octet-stream";
        }

        ///<summary> 
        ///Converts an instance of the System.String class to an array of bytes.
        ///</summary>
        public static byte[] ToByteArray(this string input)
        {
            var bytesArray = new byte[input.Length * sizeof(char)];
            Buffer.BlockCopy(input.ToCharArray(), 0, bytesArray, 0, bytesArray.Length);
            return bytesArray;
        }
    }
}