// <copyright file="DataEncryptionService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;

namespace Iss.Service
{
    public class DataEncryptionService : IDataEncryptionService
    {
        private static readonly string StandardAlphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";  // SPELL

        public Dictionary<string, string> Encrypt(string data)
        {
            string key = ShuffleAlphabet();
            string encryptedData = string.Empty;
            for (int i = 0; i < data.Length; i++)
            {
                if (char.IsLower(data[i]))
                {
                    encryptedData += key[data[i] - 'a'];
                }
                else if (char.IsUpper(data[i]))
                {
                    encryptedData += key[data[i] - 'A' + 26];
                }
                else
                {
                    encryptedData += data[i];
                }
            }

            Dictionary<string, string> result = new ()
            {
                { "data", encryptedData },
                { "key", key },
            };
            return result;
        }

        public string Decrypt(string data, string key)
        {
            string decryptedData = string.Empty;
            for (int i = 0; i < data.Length; i++)
            {
                if (char.IsLetter(data[i]))
                {
                    int index = key.IndexOf(data[i]);
                    decryptedData += StandardAlphabet[index];
                }
                else
                {
                    decryptedData += data[i];
                }
            }

            return decryptedData;
        }

        private static string ShuffleAlphabet()
        {
            string shuffled = string.Empty;
            int lengthOfAlphabet = StandardAlphabet.Length;
            Random random = new ();
            char randomCharacter;
            string copyOfAlphabet = StandardAlphabet;
            while (shuffled.Length < lengthOfAlphabet)
            {
                if (copyOfAlphabet.Length > 1)
                {
                    randomCharacter = copyOfAlphabet[random.Next(copyOfAlphabet.Length)];
                }
                else
                {
                    randomCharacter = copyOfAlphabet[0];
                }

                shuffled += randomCharacter;
                copyOfAlphabet = copyOfAlphabet.Replace(randomCharacter.ToString(), string.Empty);
            }

            return shuffled;
        }
    }
}
