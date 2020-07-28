using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace CapstoneBGSConsole
{
    public class Hash
    {
        public static string HashPassword(string Password) //for hashing password
        {
            SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();

            byte[] Password_bytes = Encoding.ASCII.GetBytes(Password);
            byte[] encrypted_bytes = sha1.ComputeHash(Password_bytes);
            return Convert.ToBase64String(encrypted_bytes);
        }
    }
}
