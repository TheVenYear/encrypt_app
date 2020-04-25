using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncrypterLib
{
    public class Gronsfeld : IType
    {
        private string alphabet;
        public Gronsfeld()
        {
            var alphabet = "АБВГДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЬЫЪЭЮЯ";
            this.alphabet = $"{alphabet}{alphabet.ToLower()} ";
        }

        public char[] Characters { get; set; } = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        public KeyValuePair<string, string> Encrypt(string s)
        {
            var rnd = new Random();
            var key = rnd.Next(1, 10000000).ToString();
            int[] keys = key.Select(ch => (int)Char.GetNumericValue(ch)).ToArray();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                sb.Append(alphabet[(alphabet.IndexOf(s[i]) + keys[i % keys.Length]) % alphabet.Length]);
            }
            return new KeyValuePair<string, string>(key, sb.ToString());
        }

        public string Decrypt(string s, string key)
        {
            int[] keys = key.Select(ch => (int)Char.GetNumericValue(ch)).ToArray();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                sb.Append(alphabet[(alphabet.IndexOf(s[i]) - keys[i % keys.Length]) % alphabet.Length]);
            }
            return sb.ToString();
        }

    }
}
