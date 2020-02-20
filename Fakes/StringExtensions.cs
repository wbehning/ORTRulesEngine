using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace RulesFakes
{
    public static class StringExtensions
    {
        private static readonly Regex EmailExpression =
            new Regex(@"^([0-9a-zA-Z]+[-._+&])*[0-9a-zA-Z]+@([-0-9a-zA-Z]+[.])+[a-zA-Z]{2,6}$",
                RegexOptions.Singleline | RegexOptions.Compiled);

        public static bool EqualsOrdinalIgnoreCase(this string s, string other)
        {
            return string.Equals(s, other, StringComparison.OrdinalIgnoreCase);
        }

        public static bool MeetsValidEmailFormat(this string s)
        {
            return !String.IsNullOrWhiteSpace(s) && EmailExpression.IsMatch(s);
        }

        public static bool CanBeAValidPhoneNumber(this string s)
        {
            if (String.IsNullOrWhiteSpace(s))
            {
                return false;
            }

            return s.GetDigits().Length == 10;
        }

        public static bool MeetsZipCodeFormat(this string s)
        {
            if (String.IsNullOrWhiteSpace(s))
            {
                return false;
            }

            s = s.GetDigits();

            return (s.Length == 5) || (s.Length == 9);
        }

        /// <summary>
        /// Creates a new string containing digits from input or String.Empty
        /// </summary>
        /// <param name="s"></param>
        /// <returns>Digits from input; String.Empty if input is null, whitespace or does not contain digits</returns>
        public static string GetDigits(this string s)
        {
            return Regex.Replace((s ?? string.Empty), @"\D", string.Empty);
            //if (String.IsNullOrWhiteSpace(s))
            //    return String.Empty;

            //StringBuilder sb = new StringBuilder();

            //for (int i = 0; i < s.Length; i++)
            //{
            //    if (Char.IsDigit(s, i))
            //        sb.Append(s[i]);
            //}

            //return sb.ToString();
        }

        public static string ToUSPhoneNumber(this string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return s;

            s = s.GetDigits();

            if (String.IsNullOrWhiteSpace(s) || (s.Length != 10))
            {
                return s;
            }

            return string.Format("({0}) {1}-{2}", s.Substring(0, 3), s.Substring(3, 3), s.Substring(6));
        }

        public static bool ParseTrueOrFalse(this string value)
        {
            if (String.IsNullOrWhiteSpace(value))
            {
                return false;
            }

            bool val;

            return bool.TryParse(value, out val) && val;
        }

        public static string CapitalizeFirstLetters(this string value)
        {
            if (String.IsNullOrWhiteSpace(value))
            {
                return value;
            }

            var tokens = value.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            var newValue = string.Empty;

            foreach (var token in tokens)
            {
                newValue = newValue + Char.ToUpper(token[0]);

                if (token.Length > 1)
                {
                    newValue = newValue + token.Substring(1).ToLower();
                }

                newValue = newValue + " ";
            }

            return newValue.Trim();
        }

        //Copied from JSon.Net source code
        public static string ToCamelCase(this string s)
        {
            if (string.IsNullOrEmpty(s))
                return s;

            if (!char.IsUpper(s[0]))
                return s;

            char[] chars = s.ToCharArray();

            for (int i = 0; i < chars.Length; i++)
            {
                bool hasNext = (i + 1 < chars.Length);
                if (i > 0 && hasNext && !char.IsUpper(chars[i + 1]))
                    break;

#if !(NETFX_CORE || PORTABLE)
                chars[i] = char.ToLower(chars[i], CultureInfo.InvariantCulture);
#else
                chars[i] = char.ToLowerInvariant(chars[i]);
#endif
            }

            return new string(chars);
        }

        public static string TrimIfNotNull(this string value)
        {
            return value == null ? null : value.Trim();
        }

        public static string ToEmptyStringIfNull(this string value)
        {
            return value ?? string.Empty;
        }

        public static string ToUpperIfNotNull(this string value)
        {
            return string.IsNullOrWhiteSpace(value) ? value : value.ToUpper();
        }


        public static string ToLowerIfNotNull(this string value)
        {
            return string.IsNullOrWhiteSpace(value) ? value : value.ToLower();
        }
    }
}