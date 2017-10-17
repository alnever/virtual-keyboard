using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tastatur_1
{
    class KeyValue
    {
        public string Locale;
        public char DefValue;
        public char CapsValue;
        public char ShiftValue;
        public int KeyType;

        public KeyValue(string aLocale, char aDefValue, char aCapsValue, char aShiftValue, int aKeyType)
        {
            Locale = aLocale;
            DefValue = aDefValue;
            CapsValue = aCapsValue;
            ShiftValue = aShiftValue;
            KeyType = aKeyType;
        }
    }
}
