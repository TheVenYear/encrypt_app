using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncrypterLib
{
    public class MagicSquare : IType
    {
        private readonly char separator = '.';
        public char[] Characters { get; set; } = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '.' };

        public KeyValuePair<string, string> Encrypt(string message)
        {
            var charDict = new Dictionary<int, char>();
            var randomArray = new List<int>();

            for (int i = 0; i < message.Length; i++)
            {
                charDict.Add(i, message[i]);
                randomArray.Add(i);
            }
            var random = new Random(DateTime.Now.Millisecond);
            randomArray = randomArray.OrderBy(x => random.Next()).ToList();

            List<char> chars = Enumerable.ToList(charDict.Values);
            List<int> vals = Enumerable.ToList(charDict.Keys);

            var result = "";
            var key = "";
            for (int i = 0; i < charDict.Count; i++)
            {
                result += chars[randomArray[i]];
                key += $"{vals[randomArray[i]] + 1}{separator}";
            }
            return new KeyValuePair<string, string>(key.Remove(key.Length - 1), result);
        }

        public string Decrypt(string message, string key)
        {
            var charDict = new Dictionary<int, char>();
            var arrChars = message.ToCharArray();
            var arrNums = key.Split(separator).Select(num => int.Parse(num)).ToArray();

            for (int i = 0; i < arrNums.Length; i++)
            {
                charDict.Add(arrNums[i], arrChars[i]);
            }
            var sorted = new SortedDictionary<int, char>(charDict);

            var result = "";
            foreach (var item in sorted.Values)
            {
                result += $"{item}";
            }
            return result;
        }
    }
}
