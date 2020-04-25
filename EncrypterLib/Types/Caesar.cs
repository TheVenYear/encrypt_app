using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncrypterLib
{
    public class Caesar : IType
    {
        const string alfabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";

        public char[] Characters { get; set; } = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        private string CodeEncode(string text, int k)
        {
            var fullAlfabet = alfabet + alfabet.ToLower();
            var letterQty = fullAlfabet.Length;
            var retVal = "";
            for (int i = 0; i < text.Length; i++)
            {
                var index = fullAlfabet.IndexOf(text[i]);
                if (index < 0)
                {
                    retVal += text[i].ToString();
                }
                else
                {
                    var codeIndex = (letterQty + index + k) % letterQty;
                    retVal += fullAlfabet[codeIndex];
                }
            }

            return retVal;
        }

        public KeyValuePair<string, string> Encrypt(string message)
        {
            var rnd = new Random();
            var key = rnd.Next(1, alfabet.Length - 1);
            return new KeyValuePair<string, string>(key.ToString(), CodeEncode(message, key));
        }


        public string Decrypt(string message, string key)
        {
            var _key = int.Parse(key);
            return CodeEncode(message, -_key);
        }
    }
}
