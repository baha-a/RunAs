using System;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace runner
{
    public static class StringCipher
    {
        private const int Keysize = 256;

        private const int DerivationIterations = 1000;

        public static string Encrypt(string plainText, string passPhrase)
        {
            var saltStringBytes = Generate256BitsOfRandomEntropy();
            var ivStringBytes = Generate256BitsOfRandomEntropy();
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            var password = new Rfc2898DeriveBytes(passPhrase, saltStringBytes, DerivationIterations);
            var keyBytes = password.GetBytes(Keysize / 8);
            using (var symmetricKey = new RijndaelManaged())
            {
                symmetricKey.BlockSize = 256;
                symmetricKey.Mode = CipherMode.CBC;
                symmetricKey.Padding = PaddingMode.PKCS7;
                using (var encryptor = symmetricKey.CreateEncryptor(keyBytes, ivStringBytes))
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                        {
                            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                            cryptoStream.FlushFinalBlock();

                            var cipherTextBytes = saltStringBytes;
                            cipherTextBytes = Concat(cipherTextBytes,ivStringBytes);
                            cipherTextBytes = Concat(cipherTextBytes,memoryStream.ToArray());
                            memoryStream.Close();
                            cryptoStream.Close();
                            return Convert.ToBase64String(cipherTextBytes);
                        }
                    }
                }
            }
        }



        public static string Decrypt(string cipherText, string passPhrase)
        {
            var cipherTextBytesWithSaltAndIv = Convert.FromBase64String(cipherText);
            var saltStringBytes = Take(cipherTextBytesWithSaltAndIv, Keysize / 8);
            var ivStringBytes = Take(Skip(cipherTextBytesWithSaltAndIv, Keysize / 8), Keysize / 8);
            var cipherTextBytes = Take(Skip(cipherTextBytesWithSaltAndIv,Keysize / 8 * 2),cipherTextBytesWithSaltAndIv.Length - (Keysize / 8 * 2));

            var password = new Rfc2898DeriveBytes(passPhrase, saltStringBytes, DerivationIterations);
            var keyBytes = password.GetBytes(Keysize / 8);
            using (var symmetricKey = new RijndaelManaged())
            {
                symmetricKey.BlockSize = 256;
                symmetricKey.Mode = CipherMode.CBC;
                symmetricKey.Padding = PaddingMode.PKCS7;
                using (var decryptor = symmetricKey.CreateDecryptor(keyBytes, ivStringBytes))
                {
                    using (var memoryStream = new MemoryStream(cipherTextBytes))
                    {
                        using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                        {
                            var plainTextBytes = new byte[cipherTextBytes.Length];
                            var decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                            memoryStream.Close();
                            cryptoStream.Close();
                            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
                        }
                    }
                }
            }
        }

        private static byte[] Concat(byte[] data, byte[] data2)
        {
            byte[] res = new byte[data.Length + data2.Length];
            
            int j = 0;
            for (int i = 0; i < data.Length; i++ ,j++)
                res[j] = data[i];


            for (int i = 0; i < data2.Length; i++, j++)
                res[j] = data2[i];

            return res;
        }

        private static byte[] Skip(byte[] data, int p)
        {
            int length = data.Length - p;
            byte[] res = new byte[length];

            for (int i = 0; i < length; i++)
                res[i] = data[i + p];
            return res;
        }

        private static byte[] Take(byte[] data, int p)
        {
            byte[] res = new byte[p];
            for (int i = 0; i < res.Length; i++)
                res[i] = data[i];
            return res;
        }

        private static byte[] Generate256BitsOfRandomEntropy()
        {
            var randomBytes = new byte[32]; // 32 Bytes will give us 256 bits.
            var rngCsp = new RNGCryptoServiceProvider();
            rngCsp.GetBytes(randomBytes);
            return randomBytes;
        }
    }
}