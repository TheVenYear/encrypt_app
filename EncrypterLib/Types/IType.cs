using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncrypterLib
{
    public interface IType
    {
        KeyValuePair<string, string> Encrypt(string message);

        string Decrypt(string message, string key);

        char[] Characters { get; set; }
    }
}
