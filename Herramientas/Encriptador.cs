﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Herramientas
{
    public class Encriptador
    {
        public string Cifrar(string textoCifrar, string palabraPaso, string valorRGBSalt, string algoritmoEncriptacionHASH, int iteraciones, string vectorInicial, int tamanoClave)
        {
            try
            {
                byte[] InitialVectorBytes = Encoding.ASCII.GetBytes(vectorInicial);
                byte[] saltValueBytes = Encoding.ASCII.GetBytes(valorRGBSalt);
                byte[] plainTextBytes = Encoding.UTF8.GetBytes(textoCifrar);
                PasswordDeriveBytes password = new PasswordDeriveBytes(palabraPaso, saltValueBytes, algoritmoEncriptacionHASH, iteraciones);
                byte[] keyBytes = password.GetBytes(tamanoClave / 8);
                RijndaelManaged symmetricKey = new RijndaelManaged();
                symmetricKey.Mode = CipherMode.CBC;
                ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, InitialVectorBytes);
                MemoryStream memoryStream = new MemoryStream();
                CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                cryptoStream.FlushFinalBlock();
                byte[] cipherTextBytes = memoryStream.ToArray();
                memoryStream.Close();
                cryptoStream.Close();
                string textoCifradoFinal = Convert.ToBase64String(cipherTextBytes);
                return textoCifradoFinal;
            }
            catch
            {
                return null;
            }
        }


        public string Descifrar(string textoCifrado, string palabraPaso, string valorRGBSalt, string algoritmoEncriptacionHASH, int iteraciones, string vectorInicial, int tamanoClave)
        {
            try
            {
                byte[] InitialVectorBytes = Encoding.ASCII.GetBytes(vectorInicial);
                byte[] saltValueBytes = Encoding.ASCII.GetBytes(valorRGBSalt);
                byte[] cipherTextBytes = Convert.FromBase64String(textoCifrado);
                PasswordDeriveBytes password = new PasswordDeriveBytes(palabraPaso, saltValueBytes, algoritmoEncriptacionHASH, iteraciones);
                byte[] keyBytes = password.GetBytes(tamanoClave / 8);
                RijndaelManaged symmetricKey = new RijndaelManaged();
                symmetricKey.Mode = CipherMode.CBC;
                ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, InitialVectorBytes);
                MemoryStream memoryStream = new MemoryStream(cipherTextBytes);
                CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
                byte[] plainTextBytes = new byte[cipherTextBytes.Length];
                int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                memoryStream.Close();
                cryptoStream.Close();
                string textoDescifradoFinal = Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
                return textoDescifradoFinal;
            }
            catch
            {
                return null;
            }
        }
    }
}
