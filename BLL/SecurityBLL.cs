using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DAL;


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

        public static string CalculateMD5Hash(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    builder.Append(hashBytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }

        public static byte[] GenerateHash(string st)
        {
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] plainText = Convert.FromBase64String(st);
            return md5.ComputeHash(plainText);
        }
        public static byte[] GenerateHash(byte[] bt)
        {
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            return md5.ComputeHash(bt);

        }

        public static string Gettabledvs(string table)
        {
            DVS mdvs = new DVS();
            return mdvs.Gettabledvs(table);

        }
        
    }
}
