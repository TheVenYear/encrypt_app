using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EncrypterLib
{
    public class SimpleRearrangement : IType
    {
        public char[] Characters { get; set; } = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '.' };

        private int[] GenerateKey(int count)
        {
            var array = new int[count];
            for (int i = 0; i < count; i++)
            {
                array[i] = i + 1;
            }
            var random = new Random(DateTime.Now.Millisecond);
            return array.OrderBy(x => random.Next()).ToArray();
        }
        public KeyValuePair<string, string> Encrypt(string message)
        {
            var key = GenerateKey(message.Length);
            for (int i = 0; i < message.Length % key.Length; i++)
                message += message[i];

            string result = "";

            for (int i = 0; i < message.Length; i += key.Length)
            {
                char[] transposition = new char[key.Length];

                for (int j = 0; j < key.Length; j++)
                    transposition[key[j] - 1] = message[i + j];

                for (int j = 0; j < key.Length; j++)
                    result += transposition[j];
            }

            var keyLine = "";
            foreach (var item in key)
            {
                keyLine += $"{item}.";
            }


            return new KeyValuePair<string, string>(keyLine.Substring(0, keyLine.Length - 1), result);
        }

        public string Decrypt(string message, string key)
        {
            var keyNums = key.Split('.').Select(item => int.Parse(item)).ToArray();
            string result = "";

            for (int i = 0; i < message.Length; i += keyNums.Length)
            {
                char[] transposition = new char[keyNums.Length];

                for (int j = 0; j < keyNums.Length; j++)
                    transposition[j] = message[i + keyNums[j] - 1];

                for (int j = 0; j < keyNums.Length; j++)
                    result += transposition[j];
            }

            return result;
        }
    }
}
