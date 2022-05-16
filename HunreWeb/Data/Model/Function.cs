using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace HunreWeb.Data.Model
{
    public class Function
    {
        private static readonly string[] VietNamChar = new string[]
{
    "aAeEoOuUiIdDyY",
    "áàạảãâấầậẩẫăắằặẳẵ",
    "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",
    "éèẹẻẽêếềệểễ",
    "ÉÈẸẺẼÊẾỀỆỂỄ",
    "óòọỏõôốồộổỗơớờợởỡ",
    "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",
    "úùụủũưứừựửữ",
    "ÚÙỤỦŨƯỨỪỰỬỮ",
    "íìịỉĩ",
    "ÍÌỊỈĨ",
    "đ",
    "Đ",
    "ýỳỵỷỹ",
    "ÝỲỴỶỸ"
};
        public static string utf8Convert1(string str)
        {
            Regex reg = new Regex("[*'\":,_&#^@]");
            str = reg.Replace(str, string.Empty);
            //Thay thế và lọc dấu từng char
            str = str.ToLower().Insert(0, "/");
            for (int i = 1; i < VietNamChar.Length; i++)
            {
                for (int j = 0; j < VietNamChar[i].Length; j++)
                {
                    str = str.Replace(VietNamChar[i][j], VietNamChar[0][i - 1]);
                    str = str.Replace(" ", "-");
                }
            }
            return str;
        }
    }
}