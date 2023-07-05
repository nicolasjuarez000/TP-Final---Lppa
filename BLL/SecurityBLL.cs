using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace BLL
{
    public static class SecurityBLL
    {
        public static string Hash(string plaintext)
        {
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] plainBytes = System.Text.Encoding.UTF8.GetBytes(plaintext);
            byte[] hash = md5.ComputeHash(plainBytes);

            string b64data = Convert.ToBase64String(hash);
            return b64data;


        }
    }
}
