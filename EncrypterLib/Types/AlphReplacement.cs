using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncrypterLib
{
    public class AlphReplacement : IType
    {
        private Dictionary<char, string> alphArray;

        public char[] Characters { get; set; } = {'А','Б','В','Г','Д','Е',
                                                  'Ё','Ж','З','И','Й','К','Л','М','Н','О','П','Р','С','Т',
                                                  'У','Ф','Х','Ц','Ч','Ш','Щ','Ъ','Ы','Ь','Э','Ю', 'Я'};
        public AlphReplacement()
        {
            alphArray = new Dictionary<char, string>();
            alphArray.Add('А', "абвгдеёжзийклмнопрстуфхцчшщъыьэюя " + "абвгдеёжзийклмнопрстуфхцчшщъыьэюя ".ToUpper());
            alphArray.Add('Б', "йцуквап ролджэячсмиенгшщзхъфытьбюё" + "йцуквап ролджэячсмиенгшщзхъфытьбюё".ToUpper());
            alphArray.Add('В', "йъцхэыжвдалпоряючбёузкще шнгфсьмти" + "йъцхэыжвдалпоряючбёузкще шнгфсьмти".ToUpper());
            alphArray.Add('Г', "ъйхцфжыдзущкшегн эбсьвлиаорёпяючмт" + "ъйхцфжыдзущкшегн эбсьвлиаорёпяючмт".ToUpper());
            alphArray.Add('Д', "юбьторпаимс чяэждлкуцвыфъхзщшгнейё" + "юбьторпаимс чяэждлкуцвыфъхзщшгнейё".ToUpper());
            alphArray.Add('Е', "йцуквапренгшщзхъфытьболдж эячсмиюё" + "йцуквапренгшщзхъфытьболдж эячсмиюё".ToUpper());
            alphArray.Add('Ё', "кджэ гйцячсмитьбенёшщуъфывапролюзх" + "кджэ гйцячсмитьбенёшщуъфывапролюзх".ToUpper());
            alphArray.Add('Ж', "знопеёжфрстуабвгидьэюхцчшщъйклмыя " + "знопеёжфрстуабвгидьэюхцчшщъйклмыя ".ToUpper());
            alphArray.Add('З', "й ролджэщзхъфывапитьбячсмцукенгшюё" + "й ролджэщзхъфывапитьбячсмцукенгшюё".ToUpper());
            alphArray.Add('И', "йвдалпоре шнгфэыжёсьмяючбъцхузкщти" + "йвдалпоре шнгфэыжёсьмяючбъцхузкщти".ToUpper());
            alphArray.Add('Й', "ъдвлиаоршегн эфжычбсьёпяюйхцзущкмт" + "ъдвлиаоршегн эфжычбсьёпяюйхцзущкмт".ToUpper());
            alphArray.Add('К', "юавыфъхзчяэждлорпекуцщшгнбьтимс йё" + "юавыфъхзчяэждлорпекуцщшгнбьтимс йё".ToUpper());
            alphArray.Add('Л', "йролдж эщзхъфывапитьбячсмцукенгшюё" + "йролдж эщзхъфывапитьбячсмцукенгшюё".ToUpper());
            alphArray.Add('М', "кджэячсмъфывапролюёшщитьбен гйцузх" + "кджэячсмъфывапролюёшщитьбен гйцузх".ToUpper());
            alphArray.Add('Н', "арстуфхцзийклмнопыьэючшщъбвгдеёжя " + "арстуфхцзийклмнопыьэючшщъбвгдеёжя ".ToUpper());
            alphArray.Add('О', "й ролджэщзхъфывапитьбячсмцукенгшюё" + "й ролджэщзхъфывапитьбячсмцукенгшюё".ToUpper());
            alphArray.Add('П', "йвдалпоре шнгфэыжёсьмяючбъцхузкщти" + "йвдалпоре шнгфэыжёсьмяючбъцхузкщти".ToUpper());
            alphArray.Add('Р', "ъдвлиаоршегн эфжычбсьёпяюйхцзущкмт" + "ъдвлиаоршегн эфжычбсьёпяюйхцзущкмт".ToUpper());
            alphArray.Add('С', "юавыфъхзчяэждлорпекуцщшгнбьтимс йё" + "юавыфъхзчяэждлорпекуцщшгнбьтимс йё".ToUpper());
            alphArray.Add('Т', "йролдж эщзхъфывапитьбячсмцукенгшюё" + "йролдж эщзхъфывапитьбячсмцукенгшюё".ToUpper());
            alphArray.Add('У', "кен гйцуэячсмитьбюёшщъфывапролджзх" + "кен гйцуэячсмитьбюёшщъфывапролджзх".ToUpper());
            alphArray.Add('Ф', "юавыфъхзчяэждлорпекуцщшгнбьтимс йё" + "юавыфъхзчяэждлорпекуцщшгнбьтимс йё".ToUpper());
            alphArray.Add('Х', "йролдж эщзхъфывапитьбячсмцукенгшюё" + "йролдж эщзхъфывапитьбячсмцукенгшюё".ToUpper());
            alphArray.Add('Ц', "кджэячсмъфывапролюёшщитьбен гйцузх" + "кджэячсмъфывапролюёшщитьбен гйцузх".ToUpper());
            alphArray.Add('Ч', "арстуфхцзийклмнопыьэючшщъбвгдеёжя " + "арстуфхцзийклмнопыьэючшщъбвгдеёжя ".ToUpper());
            alphArray.Add('Ш', "й ролджэщзхъфывапитьбячсмцукенгшюё" + "й ролджэщзхъфывапитьбячсмцукенгшюё".ToUpper());
            alphArray.Add('Щ', "йвдалпоре шнгфэыжёсьмяючбъцхузкщти" + "йвдалпоре шнгфэыжёсьмяючбъцхузкщти".ToUpper());
            alphArray.Add('Ъ', "ъдвлиаоршегн эфжычбсьёпяюйхцзущкмт" + "ъдвлиаоршегн эфжычбсьёпяюйхцзущкмт".ToUpper());
            alphArray.Add('Ы', "юавыфъхзчяэждлорпекуцщшгнбьтимс йё" + "юавыфъхзчяэждлорпекуцщшгнбьтимс йё".ToUpper());
            alphArray.Add('Ь', "йролдж эщзхъфывапитьбячсмцукенгшюё" + "йролдж эщзхъфывапитьбячсмцукенгшюё".ToUpper());
            alphArray.Add('Э', "кен гйцуэячсмитьбюёшщъфывапролджзх" + "кен гйцуэячсмитьбюёшщъфывапролджзх".ToUpper());
            alphArray.Add('Ю', "йролдж эщзхъфывапитьбячсмцукенгшюё" + "йролдж эщзхъфывапитьбячсмцукенгшюё".ToUpper());
            alphArray.Add('Я', "кен гйцуэячсмитьбюёшщъфывапролджзх" + "кен гйцуэячсмитьбюёшщъфывапролджзх".ToUpper());
        }

        private IEnumerable<TKey> RandomValues<TKey, TValue>(Dictionary<TKey, TValue> dict)
        {
            Random rnd = new Random();
            List<TKey> values = Enumerable.ToList(dict.Keys);
            int size = dict.Count;
            while (true)
            {
                yield return values[rnd.Next(size)];
            }
        }

        private string GenerateKey(int value)
        {
            string line = "";
            foreach (var key in RandomValues(alphArray).Take(value))
            {
                line += key;
            }
            return line;
        }

        private int FindChar(char array1, char key)
        {
            string line;
            alphArray.TryGetValue(key, out line);
            for (int i = 0; i < line.Length; i++)
            {
                if (array1 == line[i])
                {
                    return i;
                }
            }
            return 228;
        }

        public KeyValuePair<string, string> Encrypt(string message)
        {
            string alf;
            string shifr = "";
            var b = GenerateKey(message.Length);
            for (int i = 0; i < b.Length; i++)
            {
                var simvol = FindChar(message[i], 'А');
                if (simvol == 228)
                {
                    shifr += message[i];
                }
                else
                {
                    alphArray.TryGetValue(b[i], out alf);
                    shifr += alf[simvol];
                }

            }
            return new KeyValuePair<string, string>(b, shifr);
        }

        public string Decrypt(string message, string key)
        {
            var result = "";
            for (int i = 0; i < message.Length; i++)
            {
                string line;
                if (FindChar(message[i], key[i]) != 228)
                {
                    alphArray.TryGetValue('А', out line);
                    result += line[FindChar(message[i], key[i])];
                }
                else
                {
                    result += message[i];
                }
            }

            return result;
        }
    }
}
