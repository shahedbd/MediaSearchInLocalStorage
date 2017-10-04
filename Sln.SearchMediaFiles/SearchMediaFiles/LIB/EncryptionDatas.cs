using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace SearchMediaFiles.LIB
{

    public static class EncryptionDatas
    {
        internal const string passPhrase = "pass";
        internal const string saltValue = "salt";
        internal const string hashAlgorithm = "MD5";
        internal const int passwordIterations = 3;             // can be any number
        internal const string initVector = "0123456789abcdf"; // must be 16 bytes
        internal const int keySize = 64;                      // can be 192 or 256

        public static List<string> EncryptList(List<string> listData)
        {
            List<string> res = new List<string>();
            try
            {
                byte[] bytes = Encoding.ASCII.GetBytes(initVector);
                byte[] rgbSalt = Encoding.ASCII.GetBytes(saltValue);
                byte[] buffer = listData.SelectMany(s => Encoding.ASCII.GetBytes(s)).ToArray();
                byte[] rgbKey = new PasswordDeriveBytes(passPhrase, rgbSalt, hashAlgorithm, passwordIterations).GetBytes(keySize / 8);
                RijndaelManaged managed = new RijndaelManaged();
                managed.Mode = CipherMode.CBC;
                ICryptoTransform transform = managed.CreateEncryptor(rgbKey, bytes);

                byte[] inArray = null;
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, transform, CryptoStreamMode.Write))
                    {
                        csEncrypt.Write(buffer, 0, buffer.Length);
                        csEncrypt.FlushFinalBlock();
                        inArray = msEncrypt.ToArray();
                        res.Add(Convert.ToBase64String(inArray));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Encrypt " + ex);
            }

            return res;
        }

        public static string EncryptString(string data)
        {
            string res = string.Empty;
            try
            {
                byte[] bytes = Encoding.ASCII.GetBytes(initVector);
                byte[] rgbSalt = Encoding.ASCII.GetBytes(saltValue);
                byte[] buffer = Encoding.UTF8.GetBytes(data);
                byte[] rgbKey = new PasswordDeriveBytes(passPhrase, rgbSalt, hashAlgorithm, passwordIterations).GetBytes(keySize / 8);
                RijndaelManaged managed = new RijndaelManaged();
                managed.Mode = CipherMode.CBC;
                ICryptoTransform transform = managed.CreateEncryptor(rgbKey, bytes);

                byte[] inArray = null;
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, transform, CryptoStreamMode.Write))
                    {
                        csEncrypt.Write(buffer, 0, buffer.Length);
                        csEncrypt.FlushFinalBlock();
                        inArray = msEncrypt.ToArray();
                        res = Convert.ToBase64String(inArray);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Encrypt " + ex);
            }

            return res;
        }

        public static string Decrypt(string data)
        {
            string res = string.Empty;
            try
            {
                byte[] bytes = Encoding.ASCII.GetBytes(initVector);
                byte[] rgbSalt = Encoding.ASCII.GetBytes(saltValue);
                byte[] buffer = Convert.FromBase64String(data);
                byte[] rgbKey = new PasswordDeriveBytes(passPhrase, rgbSalt, hashAlgorithm, passwordIterations).GetBytes(keySize / 8);
                RijndaelManaged managed = new RijndaelManaged();
                managed.Mode = CipherMode.CBC;
                ICryptoTransform transform = managed.CreateDecryptor(rgbKey, bytes);

                using (MemoryStream msEncrypt = new MemoryStream(buffer))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msEncrypt, transform, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            res = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Decrypt " + ex);
            }

            return res;
        }


        public static List<string> EncodeTo64(List<string> toEncodeList)
        {
            //byte[] toEncodeAsBytes = ASCIIEncoding.ASCII.GetBytes(toEncode);
            byte[] buffer = toEncodeList.SelectMany(s => Encoding.ASCII.GetBytes(s)).ToArray();
            List<string> returnValue = new List<string>();
            returnValue.Add(Convert.ToBase64String(buffer));
            return returnValue;
        }

        public static List<string> DecodeFrom64(List<string> encodedDataList)
        {
            //byte[] encodedDataAsBytes = Convert.FromBase64String(encodedData);
            byte[] buffer = encodedDataList.SelectMany(s => Encoding.ASCII.GetBytes(s)).ToArray();
            List<string> returnValue = new List<string>();
            returnValue.Add(ASCIIEncoding.ASCII.GetString(buffer));
            return returnValue;
        }

        public static void EncryptFile(string inputFile, string outputFile)
        {
            try
            {
                string password = @"myKey123"; // Your Key Here
                UnicodeEncoding UE = new UnicodeEncoding();
                byte[] key = UE.GetBytes(password);

                string cryptFile = outputFile;
                FileStream fsCrypt = new FileStream(cryptFile, FileMode.Create);

                RijndaelManaged RMCrypto = new RijndaelManaged();

                CryptoStream cs = new CryptoStream(fsCrypt,
                    RMCrypto.CreateEncryptor(key, key),
                    CryptoStreamMode.Write);

                FileStream fsIn = new FileStream(inputFile, FileMode.Open);

                int data;
                while ((data = fsIn.ReadByte()) != -1)
                    cs.WriteByte((byte)data);


                fsIn.Close();
                cs.Close();
                fsCrypt.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void DecryptFile(string inputFile, string outputFile)
        {
            try
            {
                string password = @"myKey123"; // Your Key Here

                UnicodeEncoding UE = new UnicodeEncoding();
                byte[] key = UE.GetBytes(password);

                FileStream fsCrypt = new FileStream(inputFile, FileMode.Open);

                RijndaelManaged RMCrypto = new RijndaelManaged();

                CryptoStream cs = new CryptoStream(fsCrypt,
                    RMCrypto.CreateDecryptor(key, key),
                    CryptoStreamMode.Read);

                FileStream fsOut = new FileStream(outputFile, FileMode.Create);

                int data;
                while ((data = cs.ReadByte()) != -1)
                    fsOut.WriteByte((byte)data);

                fsOut.Close();
                cs.Close();
                fsCrypt.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


    }
}
