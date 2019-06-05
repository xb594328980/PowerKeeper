using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace PowerKeeper.Infra.Tool.Security.Encryptors
{
    /// <summary>
    /// MD5加密
    /// <remarks>
    /// create by xingbo 19/05/17
    /// </remarks>
    /// </summary>
    public class Md5Encryptor : IEncryptor
    {
        public string Encrypt(string data)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] t = md5.ComputeHash(Encoding.UTF8.GetBytes(data));
            StringBuilder sb = new StringBuilder(32);
            for (int i = 0; i < t.Length; i++)
                sb.Append(t[i].ToString("x").PadLeft(2, '0'));
            return sb.ToString();
        }

        public string Decrypt(string data)
        {
            throw new NotImplementedException();
        }
    }
}
