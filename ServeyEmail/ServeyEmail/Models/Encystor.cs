using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace ServeyEmail.Models
{
    public static class Encystor
    {
        public static string MD5Hash(string text)
        {
            //tạo kiểu md5
            MD5 md5 = new MD5CryptoServiceProvider();

            //Chuyển kiểu chuổi thành kiểu byte
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));

            //mã hóa chuỗi đã chuyển
            byte[] result = md5.Hash;

            //tạo đối tượng StringBuilder (làm việc với kiểu dữ liệu lớn)
            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //đổi thành kiểu hexa
                //change it into 2 hexadecimal digits
                //for each byte
                strBuilder.Append(result[i].ToString("X2"));
            }

            return strBuilder.ToString();
        }
    }
}