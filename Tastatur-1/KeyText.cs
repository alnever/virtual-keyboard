using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tastatur_1
{
    class KeyText
    {
        public string keyName;
        public List<KeyValue> keyValues;
        public byte keyDown;
        public byte keyUp;
        public byte keyCode;

        public KeyText(string aKeyName, List<KeyValue> aKeyValues, byte aDown, byte aUp, byte aCode)
        {
            keyName = aKeyName;
            keyValues = aKeyValues;
            keyDown = aDown;
            keyUp = aUp;
            keyCode = aCode;
        }

    }
}
