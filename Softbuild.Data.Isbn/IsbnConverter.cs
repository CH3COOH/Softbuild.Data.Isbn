using System;
using System.Collections.Generic;
using System.Linq;

namespace Softbuild.Data.Isbn
{
	public class IsbnConverter
	{
        public static string ConvertToISBN10(string isbn13)
        {
            if (string.IsNullOrWhiteSpace(isbn13) || isbn13.Length != 13)
            {
                throw new ArgumentException();
            }

            var list = new List<int>();
            for (int i = 3; i < 12; i++) 
            {
                var s = isbn13.Substring(i, 1);
                list.Add(int.Parse(s));
            }

            var sum = list
                .Select((e, index) => e * (10 - index))
                .Sum(e => e);

            var digit = string.Empty;
            var c = 11 - (sum % 11);
            if (c == 10)
            {
                digit = "X";
            }
            else if (c == 11)
            {
                digit = "0";
            }
            else
            {
                digit = c.ToString();
            }

            return string.Format("{0}{1}", isbn13.Substring(3, 9), digit);
        }

        public static string ConvertToISBN13(string isbn10)
        {
            if (string.IsNullOrWhiteSpace(isbn10) || isbn10.Length != 10)
            {
                throw new ArgumentException();
            }

            var list = new List<int>();
            for (int i = 0; i < 12; i++)
            {
                var s = isbn10.Insert(0, "978").Substring(i, 1);
                list.Add(int.Parse(s));
            }

            var sum = list
                .Select((e, index) => e * (((index + 1) % 2 == 1) ? 1 : 3))
                .Sum(e => e);

            var digit = string.Empty;
            var check = 10 - (sum % 10);
            if (check == 10)
            {
                digit = "0";
            }
            else
            {
                digit = check.ToString();
            }

            return string.Format("978{0}{1}", isbn10.Substring(0, 9), digit);
        }
	}
}

