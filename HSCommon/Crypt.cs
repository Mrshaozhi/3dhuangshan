using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace HSCommon
{
    //summary
    //加密解密类： 本类用于对字符串的加密解密
    //summary
    public class Crypt : MarshalByRefObject
    {

        //Exactement 8 caractères
        private static byte[] iv = System.Text.Encoding.UTF8.GetBytes("az#fTy12");
        //Exactement 24 caractères
        private static byte[] key = System.Text.Encoding.UTF8.GetBytes("Azx6TrdcTJruElLMZaSwTRa?");


        private static TripleDESCryptoServiceProvider encryptor = new TripleDESCryptoServiceProvider();

        #region "ICrypt Members"
        /// <summary>
        /// 本方法对字符串进行加密
        /// </summary>
        /// <param name="valeur"></param>
        /// <returns></returns>
        public string Encrypt(string valeur)
        {

            ICryptoTransform transform = null;
            //= null
            MemoryStream myStream = null;
            //= null
            CryptoStream cs = null;
            //= null
            byte[] data = null;

            transform = encryptor.CreateEncryptor(key, iv);
            data = Encoding.UTF8.GetBytes(valeur);

            myStream = new MemoryStream();
            cs = new CryptoStream(myStream, transform, CryptoStreamMode.Write);
            cs.Write(data, 0, data.Length);
            cs.FlushFinalBlock();
            cs.Close();
            return Convert.ToBase64String(myStream.ToArray());

        }


        /// <summary>
        /// 本方法可对加密信息进行解密
        /// </summary>
        /// <param name="valeur"></param>
        /// <returns></returns>
        public string Decrypt(string valeur)
        {

            if (valeur != null && valeur.Length > 0)
            {
                ICryptoTransform transform = null;
                MemoryStream myStream = null;
                CryptoStream cs = null;
                byte[] data = null;

                transform = encryptor.CreateDecryptor(key, iv);

                valeur = valeur.Replace(" ", "+");
                data = Convert.FromBase64String(valeur);

                myStream = new MemoryStream();
                cs = new CryptoStream(myStream, transform, CryptoStreamMode.Write);
                cs.Write(data, 0, data.Length);
                cs.FlushFinalBlock();

                cs.Close();

                return Encoding.UTF8.GetString(myStream.ToArray());
            }
            else
            {
                return string.Empty;
            }
        }

        #endregion

    }
}
