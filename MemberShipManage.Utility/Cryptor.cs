using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MemberShipManage.Utility
{

    public class Cryptor
    {
        /// <summary>
        /// 加密
        /// </summary>
        /// <returns></returns>
        public static string Encrypt(string inputStr)
        {
            return new CryptoAPI().Encrypt(inputStr.ToCharArray());
        }

        public static string Decrypt(string inputStr)
        {
            return new CryptoAPI().Decrypt(inputStr.ToCharArray());
        }
    }
}
