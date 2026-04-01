using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Servicios_842JF
{
    public class Encriptador_842JF
    {
        public static string Encriptar_842JF(string s)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytesTexto = Encoding.UTF8.GetBytes(s);
                byte[] hash = sha256.ComputeHash(bytesTexto);

                StringBuilder sb = new StringBuilder();
                foreach (byte b in hash)
                {
                    sb.Append(b.ToString("x2"));
                }

                return sb.ToString();
            }
        }
        public static string EncriptarReversible_842JF(string mail)
        {
            string clave = "ClaveSecreta842JF";
            byte[] keyBytes = Encoding.UTF8.GetBytes(clave.PadRight(32).Substring(0, 32));
            byte[] ivBytes = Encoding.UTF8.GetBytes("JoacoFelix842JFB"); 

            using (Aes aes = Aes.Create())
            {
                aes.Key = keyBytes;
                aes.IV = ivBytes;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                ICryptoTransform encryptor = aes.CreateEncryptor();
                byte[] mailBytes = Encoding.UTF8.GetBytes(mail);
                byte[] encryptedBytes = encryptor.TransformFinalBlock(mailBytes, 0, mailBytes.Length);

                return Convert.ToBase64String(encryptedBytes);
            }
        }
        public static string DesencriptarReversible_842JF(string mailEncriptado)
        {
            string clave = "ClaveSecreta842JF";
            byte[] keyBytes = Encoding.UTF8.GetBytes(clave.PadRight(32).Substring(0, 32));
            byte[] ivBytes = Encoding.UTF8.GetBytes("JoacoFelix842JFB");

            using (Aes aes = Aes.Create())
            {
                aes.Key = keyBytes;
                aes.IV = ivBytes;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                ICryptoTransform decryptor = aes.CreateDecryptor();
                byte[] encryptedBytes = Convert.FromBase64String(mailEncriptado);
                byte[] decryptedBytes = decryptor.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);

                return Encoding.UTF8.GetString(decryptedBytes);
            }
        }
    }
}
