using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using System.Windows.Forms;

namespace P2Pchat
{
    class AES256
    {
        byte[] salt = Encoding.UTF8.GetBytes("asdafsdfsgdgsdffdfsd");
        byte[] info = Encoding.UTF8.GetBytes("AES test");
        byte[] key;
        byte[] InitV;
        public AES256()
        {
            key = new byte[32];
            key = Encoding.UTF8.GetBytes("01234567890123456789012345678901");
            InitV = new byte[16];
        }

        // Encrypt a byte array into a byte array using a key and an IV 
        private byte[] Encrypt(byte[] clearData, byte[] Key, byte[] IV)
        {
            Hkdf hkdf = new Hkdf();
            byte[] output = hkdf.DeriveKey(salt, this.key, info, 48);
            
            Array.Copy(output, 0, this.key, 0, 32);
            Array.Copy(output, 32, InitV, 0, 16);
            // Create a MemoryStream that is going to accept the encrypted bytes 
            MemoryStream ms = new MemoryStream();

            Rijndael alg = Rijndael.Create();
            alg.Key = Key;
            alg.IV = InitV;
            alg.Padding = PaddingMode.None;
            CryptoStream cs = new CryptoStream(ms, alg.CreateEncryptor(), CryptoStreamMode.Write);

            cs.Write(clearData, 0, clearData.Length);
            cs.Close();
            byte[] encryptedData = ms.ToArray();

            return encryptedData;
        }



        /// <summary>
        /// Returns an encrypted string using Rijndael (128,192,256 Bits).
        /// </summary>
        public byte[] Encrypt(string Data, string Password, int Bits)
        {
            //string Password = aeskey192;

            byte[] clearBytes = System.Text.Encoding.UTF8.GetBytes(Data);


            PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password, 
                new byte[] { 0x00, 0x01, 0x02, 0x1C, 0x1D, 0x1E, 0x03, 0x04, 0x05, 0x0F, 0x20, 0x21, 0xAD, 0xAF, 0xA4 });


            if (Bits == 128)
            {
                byte[] encryptedData = Encrypt(clearBytes, pdb.GetBytes(16), pdb.GetBytes(16));
                return encryptedData;
            }
            else if (Bits == 192)
            {
                byte[] encryptedData = Encrypt(clearBytes, pdb.GetBytes(24), pdb.GetBytes(16));
                return encryptedData;
            }
            else if (Bits == 256)
            {
                byte[] encryptedData = Encrypt(clearBytes, pdb.GetBytes(32), pdb.GetBytes(16));
                return encryptedData;
            }
            else
            {

            }
            
                return null;
            
        }

        // Decrypt a byte array into a byte array using a key and an IV 
        private byte[] Decrypt(byte[] cipherData, byte[] Key, byte[] IV)
        {
            Hkdf hkdf = new Hkdf();
            byte[] output = hkdf.DeriveKey(salt, this.key, info, 48);
            Array.Copy(output, 0, this.key, 0, 32);
            Array.Copy(output, 32, InitV, 0, 16);
            MemoryStream ms = new MemoryStream();
            Rijndael alg = Rijndael.Create();
            alg.Key = Key;
            alg.IV = InitV;
            alg.Padding = PaddingMode.None;
            CryptoStream cs = new CryptoStream(ms, alg.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(cipherData, 0, cipherData.Length);
            cs.Close();
            byte[] decryptedData = ms.ToArray();
            return decryptedData;
        }


        /// <summary>
        /// Returns a decrypted string.
        /// </summary>
        // Decrypt a string into a string using a password 
        public string Decrypt(byte[] cipherBytes, string Password, int Bits)
        {
            //string Password = aeskey192;

            //byte[] cipherBytes = Convert.FromBase64String(Data);

            PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password,
                new byte[] { 0x00, 0x01, 0x02, 0x1C, 0x1D, 0x1E, 0x03, 0x04, 0x05, 0x0F, 0x20, 0x21, 0xAD, 0xAF, 0xA4 });

            if (Bits == 128)
            {
                byte[] decryptedData = Decrypt(cipherBytes, pdb.GetBytes(16), pdb.GetBytes(16));
                return System.Text.Encoding.Unicode.GetString(decryptedData);
            }
            else if (Bits == 192)
            {
                byte[] decryptedData = Decrypt(cipherBytes, pdb.GetBytes(24), pdb.GetBytes(16));
                return System.Text.Encoding.Unicode.GetString(decryptedData);
            }
            else if (Bits == 256)
            {
                byte[] decryptedData = Decrypt(cipherBytes, pdb.GetBytes(32), pdb.GetBytes(16));
                return System.Text.Encoding.UTF8.GetString(decryptedData);
            }
            else
            {
                return string.Concat(Bits);
            }

        }
    }
}
