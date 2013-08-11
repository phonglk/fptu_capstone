using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace DropIt.Common
{
    public static class Utils
    {
        public static string GetVariableName<T>(Expression<Func<T>> expr)
        {
            var body = (MemberExpression)expr.Body;

            return body.Member.Name;
        
        }
        public static string ConvertVN(string utf8text)
        {
            const string FindText = "áàảãạâấầẩẫậăắằẳẵặđéèẻẽẹêếềểễệíìỉĩịóòỏõọôốồổỗộơớờởỡợúùủũụưứừửữựýỳỷỹỵÁÀẢÃẠÂẤẦẨẪẬĂẮẰẲẴẶĐÉÈẺẼẸÊẾỀỂỄỆÍÌỈĨỊÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢÚÙỦŨỤƯỨỪỬỮỰÝỲỶỸỴ";
            const string ReplText = "aaaaaaaaaaaaaaaaadeeeeeeeeeeeiiiiiooooooooooooooooouuuuuuuuuuuyyyyyAAAAAAAAAAAAAAAAADEEEEEEEEEEEIIIIIOOOOOOOOOOOOOOOOOUUUUUUUUUUUYYYYY";
            int index = -1;
            char[] arrChar = FindText.ToCharArray();
            while ((index = utf8text.IndexOfAny(arrChar)) != -1)
            {
                int index2 = FindText.IndexOf(utf8text[index]);
                utf8text = utf8text.Replace(utf8text[index], ReplText[index2]);
            }
            return utf8text;
        }
        public static List<string> ReduceRedundancy(List<string> strings)
        {
            List<string> result = new List<string>();

            foreach (string str in strings)
            {
                var str_c1 = str.ToLower().Trim();
                bool IsSame = false;
                foreach (string str2 in result)
                {
                    var str_c2 = str2.ToLower().Trim();
                    if (str_c1.Equals(str_c2))
                    {
                        IsSame = true;
                    }
                    if (str_c1.IndexOf(str_c2) > -1)
                    {
                        IsSame = true;
                    }
                    if (str_c2.IndexOf(str_c1) > -1)
                    {
                        IsSame = true;
                    }
                }
                if (IsSame == false)
                {
                    result.Add(str);
                }
            }

            return result;
        }
        public static class LevenshteinDistance
        {
            /// <summary>
            /// Compute the distance between two strings.
            /// </summary>
            public static int Compute(string s, string t)
            {
                int n = s.Length;
                int m = t.Length;
                int[,] d = new int[n + 1, m + 1];

                // Step 1
                if (n == 0)
                {
                    return m;
                }

                if (m == 0)
                {
                    return n;
                }

                // Step 2
                for (int i = 0; i <= n; d[i, 0] = i++)
                {
                }

                for (int j = 0; j <= m; d[0, j] = j++)
                {
                }

                // Step 3
                for (int i = 1; i <= n; i++)
                {
                    //Step 4
                    for (int j = 1; j <= m; j++)
                    {
                        // Step 5
                        int cost = (t[j - 1] == s[i - 1]) ? 0 : 1;

                        // Step 6
                        d[i, j] = Math.Min(
                            Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                            d[i - 1, j - 1] + cost);
                    }
                }
                // Step 7
                return d[n, m];
            }
        }
    }
}