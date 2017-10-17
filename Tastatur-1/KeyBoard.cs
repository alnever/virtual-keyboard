using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace Tastatur_1
{
    public class KeyBoard: INotifyPropertyChanged
    {
        public string ru = "ru-RU";
        public string lat = "en-US";

        private string _Locale;
        public string Locale
        {
            get { return _Locale;  }
            set {
                _Locale = value;
                OnPropertyChanged("Locale");
            }
        }

        bool _Caps = false;
        public bool Caps
        {
            get { return _Caps;  }
            set {
                _Caps = value;
                OnPropertyChanged("Caps");
            }
        }

        bool _Shift = false;
        public bool Shift
        {
            get { return _Shift;  }
            set {
                _Shift = value;
                OnPropertyChanged("Shift");
            }
        }

        public int KeyBoardStatus
        {
            get
            {
                return Convert.ToInt32(Caps) * 4 +
                    Convert.ToInt32(Shift) * 2 +
                    (Locale == lat? 1 : 0);
            }
        }

        List<KeyText> keys = new List<KeyText>();

        public KeyBoard()
        {
            Caps = false;
            Locale = ru;
            Shift = false;
            Init();
            changeKeyboard();
        }

        public void Init()
        {
            if (keys.Count > 0)
                keys.Clear();

            List<KeyValue> keyValues = new List<KeyValue>();
            keyValues.Add(new KeyValue(lat, 'q', 'Q', (char)0, 1));
            keyValues.Add(new KeyValue(ru, 'й', 'Й', (char)0, 1));
            keys.Add(new KeyText("vk_q", keyValues, 0x10, 0x90, 0x51));

            keyValues = new List<KeyValue>();
            keyValues.Add(new KeyValue(lat, 'w', 'W', (char)0, 1));
            keyValues.Add(new KeyValue(ru, 'ц', 'Ц', (char)0, 1));
            keys.Add(new KeyText("vk_w", keyValues, 0x11, 0x91, 0x57));

            keyValues = new List<KeyValue>();
            keyValues.Add(new KeyValue(lat, 'e', 'E', (char)0, 1));
            keyValues.Add(new KeyValue(ru, 'у', 'У', (char)0, 1));
            keys.Add(new KeyText("vk_e", keyValues, 0x12, 0x92, 0x45));

            keyValues = new List<KeyValue>();
            keyValues.Add(new KeyValue(lat, 'r', 'R', (char)0, 1));
            keyValues.Add(new KeyValue(ru, 'к', 'К', (char)0, 1));
            keys.Add(new KeyText("vk_r", keyValues, 0x13, 0x93, 0x52));

            keyValues = new List<KeyValue>();
            keyValues.Add(new KeyValue(lat, 't', 'T', (char)0, 1));
            keyValues.Add(new KeyValue(ru, 'е', 'Е', (char)0, 1));
            keys.Add(new KeyText("vk_t", keyValues, 0x14, 0x94, 0x54));

            keyValues = new List<KeyValue>();
            keyValues.Add(new KeyValue(lat, 'y', 'Y', (char)0, 1));
            keyValues.Add(new KeyValue(ru, 'н', 'Н', (char)0, 1));
            keys.Add(new KeyText("vk_y", keyValues, 0x15, 0x95, 0x59));

            keyValues = new List<KeyValue>();
            keyValues.Add(new KeyValue(lat, 'u', 'U', (char)0, 1));
            keyValues.Add(new KeyValue(ru, 'г', 'Г', (char)0, 1));
            keys.Add(new KeyText("vk_u", keyValues, 0x16, 0x96, 0x55));

            keyValues = new List<KeyValue>();
            keyValues.Add(new KeyValue(lat, 'i', 'I', (char)0, 1));
            keyValues.Add(new KeyValue(ru, 'ш', 'Ш', (char)0, 1));
            keys.Add(new KeyText("vk_i", keyValues, 0x17, 0x97, 0x49));

            keyValues = new List<KeyValue>();
            keyValues.Add(new KeyValue(lat, 'o', 'O', (char)0, 1));
            keyValues.Add(new KeyValue(ru, 'щ', 'Щ', (char)0, 1));
            keys.Add(new KeyText("vk_o", keyValues, 0x18, 0x98, 0x4F));

            keyValues = new List<KeyValue>();
            keyValues.Add(new KeyValue(lat, 'p', 'P', (char)0, 1));
            keyValues.Add(new KeyValue(ru, 'з', 'З', (char)0, 1));
            keys.Add(new KeyText("vk_p", keyValues, 0x19, 0x99, 0x50));

            keyValues = new List<KeyValue>();
            keyValues.Add(new KeyValue(lat, '[', '[', '{', 2));
            keyValues.Add(new KeyValue(ru, 'х', 'Х', (char)0, 1));
            keys.Add(new KeyText("vk_leftbr", keyValues, 0x1a, 0x9a, 0xDB));

            keyValues = new List<KeyValue>();
            keyValues.Add(new KeyValue(lat, ']', ']', '}', 2));
            keyValues.Add(new KeyValue(ru, 'ъ', 'Ъ', (char)0, 1));
            keys.Add(new KeyText("vk_rightbr", keyValues, 0x1b, 0x9b, 0xDD));

            keyValues = new List<KeyValue>();
            keyValues.Add(new KeyValue(lat, 'a', 'A', (char)0, 1));
            keyValues.Add(new KeyValue(ru, 'ф', 'Ф', (char)0, 1));
            keys.Add(new KeyText("vk_a", keyValues, 0x1e, 0x9e, 0x41));

            keyValues = new List<KeyValue>();
            keyValues.Add(new KeyValue(lat, 's', 'S', (char)0, 1));
            keyValues.Add(new KeyValue(ru, 'ы', 'Ы', (char)0, 1));
            keys.Add(new KeyText("vk_s", keyValues, 0x1f, 0x9f, 0x53));

            keyValues = new List<KeyValue>();
            keyValues.Add(new KeyValue(lat, 'd', 'D', (char)0, 1));
            keyValues.Add(new KeyValue(ru, 'в', 'В', (char)0, 1));
            keys.Add(new KeyText("vk_d", keyValues, 0x20, 0xA0, 0x44));

            keyValues = new List<KeyValue>();
            keyValues.Add(new KeyValue(lat, 'f', 'F', (char)0, 1));
            keyValues.Add(new KeyValue(ru, 'а', 'А', (char)0, 1));
            keys.Add(new KeyText("vk_f", keyValues, 0x21, 0xA1, 0x46));

            keyValues = new List<KeyValue>();
            keyValues.Add(new KeyValue(lat, 'g', 'G', (char)0, 1));
            keyValues.Add(new KeyValue(ru, 'п', 'П', (char)0, 1));
            keys.Add(new KeyText("vk_g", keyValues, 0x22, 0xA2, 0x47));

            keyValues = new List<KeyValue>();
            keyValues.Add(new KeyValue(lat, 'h', 'H', (char)0, 1));
            keyValues.Add(new KeyValue(ru, 'р', 'Р', (char)0, 1));
            keys.Add(new KeyText("vk_h", keyValues, 0x23, 0xA3, 0x48));

            keyValues = new List<KeyValue>();
            keyValues.Add(new KeyValue(lat, 'j', 'J', (char)0, 1));
            keyValues.Add(new KeyValue(ru, 'о', 'О', (char)0, 1));
            keys.Add(new KeyText("vk_j", keyValues, 0x24, 0xA4, 0x4A));

            keyValues = new List<KeyValue>();
            keyValues.Add(new KeyValue(lat, 'k', 'K', (char)0, 1));
            keyValues.Add(new KeyValue(ru, 'л', 'Л', (char)0, 1));
            keys.Add(new KeyText("vk_k", keyValues, 0x25, 0xA5, 0x4B));

            keyValues = new List<KeyValue>();
            keyValues.Add(new KeyValue(lat, 'l', 'L', (char)0, 1));
            keyValues.Add(new KeyValue(ru, 'д', 'Д', (char)0, 1));
            keys.Add(new KeyText("vk_l", keyValues, 0x26, 0xA6, 0x4C));

            keyValues = new List<KeyValue>();
            keyValues.Add(new KeyValue(lat, ';', ';', ':', 2));
            keyValues.Add(new KeyValue(ru, 'ж', 'Ж', (char)0, 1));
            keys.Add(new KeyText("vk_column", keyValues, 0x27, 0xA7, 0xBA));

            keyValues = new List<KeyValue>();
            keyValues.Add(new KeyValue(lat, (char)0x27, (char)0x27, '"', 2));
            keyValues.Add(new KeyValue(ru, 'э', 'Э', (char)0, 1));
            keys.Add(new KeyText("vk_aps", keyValues, 0x2B, 0xAB, 0xDC));

            keyValues = new List<KeyValue>();
            keyValues.Add(new KeyValue(lat, 'z', 'Z', (char)0, 1));
            keyValues.Add(new KeyValue(ru, 'я', 'Я', (char)0, 1));
            keys.Add(new KeyText("vk_z", keyValues, 0x2C, 0xAC, 0x5A));

            keyValues = new List<KeyValue>();
            keyValues.Add(new KeyValue(lat, 'x', 'X', (char)0, 1));
            keyValues.Add(new KeyValue(ru, 'ч', 'Ч', (char)0, 1));
            keys.Add(new KeyText("vk_x", keyValues, 0x2D, 0xAD, 0x58));

            keyValues = new List<KeyValue>();
            keyValues.Add(new KeyValue(lat, 'c', 'C', (char)0, 1));
            keyValues.Add(new KeyValue(ru, 'с', 'С', (char)0, 1));
            keys.Add(new KeyText("vk_c", keyValues, 0x2E, 0xAE, 0x43));

            keyValues = new List<KeyValue>();
            keyValues.Add(new KeyValue(lat, 'v', 'V', (char)0, 1));
            keyValues.Add(new KeyValue(ru, 'м', 'М', (char)0, 1));
            keys.Add(new KeyText("vk_v", keyValues, 0x2F, 0xAF, 0x56));

            keyValues = new List<KeyValue>();
            keyValues.Add(new KeyValue(lat, 'b', 'B', (char)0, 1));
            keyValues.Add(new KeyValue(ru, 'и', 'И', (char)0, 1));
            keys.Add(new KeyText("vk_b", keyValues, 0x30, 0xB0, 0x42));

            keyValues = new List<KeyValue>();
            keyValues.Add(new KeyValue(lat, 'n', 'N', (char)0, 1));
            keyValues.Add(new KeyValue(ru, 'т', 'Т', (char)0, 1));
            keys.Add(new KeyText("vk_n", keyValues, 0x31, 0xB1, 0x4E));

            keyValues = new List<KeyValue>();
            keyValues.Add(new KeyValue(lat, 'm', 'M', (char)0, 1));
            keyValues.Add(new KeyValue(ru, 'ь', 'Ь', (char)0, 1));
            keys.Add(new KeyText("vk_m", keyValues, 0x32, 0xB2, 0x4D));

            keyValues = new List<KeyValue>();
            keyValues.Add(new KeyValue(lat, ',', ',', '<', 2));
            keyValues.Add(new KeyValue(ru, 'б', 'Б', (char)0, 1));
            keys.Add(new KeyText("vk_comma", keyValues, 0x33, 0xB3, 0xBC));

            keyValues = new List<KeyValue>();
            keyValues.Add(new KeyValue(lat, '.', '.', '>', 2));
            keyValues.Add(new KeyValue(ru, 'ю', 'Ю', (char)0, 1));
            keys.Add(new KeyText("vk_dot", keyValues, 0x34, 0xB4, 0xBE));


            keyValues = new List<KeyValue>();
            keyValues.Add(new KeyValue(lat, '/', '/', '?', 2));
            keyValues.Add(new KeyValue(ru, '.', '.', ',', 2));
            keys.Add(new KeyText("vk_slash", keyValues, 0x35, 0xB5, 0xBF));

            keyValues = new List<KeyValue>();
            keyValues.Add(new KeyValue(lat, '\\', '\\', '|', 2));
            keyValues.Add(new KeyValue(ru, '\\', '\\', '/', 2));
            keys.Add(new KeyText("vk_bslash", keyValues, 0x2B, 0xAB, 0xDC));

            keyValues = new List<KeyValue>();
            keyValues.Add(new KeyValue(lat, '`', '`', '~', 2));
            keyValues.Add(new KeyValue(ru, 'ё', 'Ё', (char)0, 1));
            keys.Add(new KeyText("vk_baps", keyValues, 0x29, 0xA9, 0xC0));

            keyValues = new List<KeyValue>();
            keyValues.Add(new KeyValue(lat, '1', '1', '!', 2));
            keyValues.Add(new KeyValue(ru, '1', '1', '!', 2));
            keys.Add(new KeyText("vk_1", keyValues, 0x02, 0x82, 0x31));

            keyValues = new List<KeyValue>();
            keyValues.Add(new KeyValue(lat, '2', '2', '@', 2));
            keyValues.Add(new KeyValue(ru, '2', '2', '"', 2));
            keys.Add(new KeyText("vk_2", keyValues, 0x03, 0x83, 0x32));

            keyValues = new List<KeyValue>();
            keyValues.Add(new KeyValue(lat, '3', '3', '#', 2));
            keyValues.Add(new KeyValue(ru, '3', '3', '№', 2));
            keys.Add(new KeyText("vk_3", keyValues, 0x04, 0x84, 0x33));

            keyValues = new List<KeyValue>();
            keyValues.Add(new KeyValue(lat, '4', '4', '$', 2));
            keyValues.Add(new KeyValue(ru, '4', '4', ';', 2));
            keys.Add(new KeyText("vk_4", keyValues, 0x05, 0x85, 0x34));

            keyValues = new List<KeyValue>();
            keyValues.Add(new KeyValue(lat, '5', '5', '%', 2));
            keyValues.Add(new KeyValue(ru, '5', '5', '%', 2));
            keys.Add(new KeyText("vk_5", keyValues, 0x06, 0x86, 0x35));

            keyValues = new List<KeyValue>();
            keyValues.Add(new KeyValue(lat, '6', '6', '^', 2));
            keyValues.Add(new KeyValue(ru, '6', '6', ':', 2));
            keys.Add(new KeyText("vk_6", keyValues, 0x07, 0x87, 0x36));

            keyValues = new List<KeyValue>();
            keyValues.Add(new KeyValue(lat, '7', '7', '/', 2));
            keyValues.Add(new KeyValue(ru, '7', '7', '?', 2));
            keys.Add(new KeyText("vk_7", keyValues, 0x08, 0x88, 0x37));

            keyValues = new List<KeyValue>();
            keyValues.Add(new KeyValue(lat, '8', '8', '*', 2));
            keyValues.Add(new KeyValue(ru, '8', '8', '*', 2));
            keys.Add(new KeyText("vk_8", keyValues, 0x09, 0x89, 0x38));

            keyValues = new List<KeyValue>();
            keyValues.Add(new KeyValue(lat, '9', '9', '(', 2));
            keyValues.Add(new KeyValue(ru, '9', '9', '(', 2));
            keys.Add(new KeyText("vk_9", keyValues, 0x0a, 0x8a, 0x39));

            keyValues = new List<KeyValue>();
            keyValues.Add(new KeyValue(lat, '0', '0', ')', 2));
            keyValues.Add(new KeyValue(ru, '0', '0', ')', 2));
            keys.Add(new KeyText("vk_0", keyValues, 0x0b, 0x8b, 0x30));

            keyValues = new List<KeyValue>();
            keyValues.Add(new KeyValue(lat, '-', '-', '_', 2));
            keyValues.Add(new KeyValue(ru, '-', '-', '_', 2));
            keys.Add(new KeyText("vk_minus", keyValues, 0x0c, 0x8c, 0xBD));

            keyValues = new List<KeyValue>();
            keyValues.Add(new KeyValue(lat, '=', '=', '+', 2));
            keyValues.Add(new KeyValue(ru, '=', '=', '+', 2));
            keys.Add(new KeyText("vk_plus", keyValues, 0x0d, 0x8d, 0xBB));

            keyValues = new List<KeyValue>();
            keyValues.Add(new KeyValue(lat, ' ', ' ', ' ', 1));
            keyValues.Add(new KeyValue(ru, ' ', ' ', ' ', 1));
            keys.Add(new KeyText("vk_space", keyValues, 0x39, 0xb9, 0x20));

            keyValues = new List<KeyValue>();
            keyValues.Add(new KeyValue(lat, ' ', ' ', ' ', 3));
            keyValues.Add(new KeyValue(ru, ' ', ' ', ' ', 3));
            keys.Add(new KeyText("vk_esc", keyValues, 0, 0, 0x1B));

            keyValues = new List<KeyValue>();
            keyValues.Add(new KeyValue(lat, ' ', ' ', ' ', 3));
            keyValues.Add(new KeyValue(ru, ' ', ' ', ' ', 3));
            keys.Add(new KeyText("vk_bksp", keyValues, 0x01, 0x81, 0x08));

            keyValues = new List<KeyValue>();
            keyValues.Add(new KeyValue(lat, ' ', ' ', ' ', 3));
            keyValues.Add(new KeyValue(ru, ' ', ' ', ' ', 3));
            keys.Add(new KeyText("vk_tab", keyValues, 0x0F, 0x8F, 0x09));

            keyValues = new List<KeyValue>();
            keyValues.Add(new KeyValue(lat, ' ', ' ', ' ', 3));
            keyValues.Add(new KeyValue(ru, ' ', ' ', ' ', 3));
            keys.Add(new KeyText("vk_del", keyValues, 0x53, 0xD3, 0x2E));

            keyValues = new List<KeyValue>();
            keyValues.Add(new KeyValue(lat, ' ', ' ', ' ', 3));
            keyValues.Add(new KeyValue(ru, ' ', ' ', ' ', 3));
            keys.Add(new KeyText("vk_caps", keyValues, 0x3A, 0xBA, 0x14));

            keyValues = new List<KeyValue>();
            keyValues.Add(new KeyValue(lat, ' ', ' ', ' ', 3));
            keyValues.Add(new KeyValue(ru, ' ', ' ', ' ', 3));
            keys.Add(new KeyText("vk_enter", keyValues, 0x1C, 0x9C, 0x0D));

            keyValues = new List<KeyValue>();
            keyValues.Add(new KeyValue(lat, ' ', ' ', ' ', 3));
            keyValues.Add(new KeyValue(ru, ' ', ' ', ' ', 3));
            keys.Add(new KeyText("vk_lshift", keyValues, 0x2A, 0xAA, 0xA0));

            keyValues = new List<KeyValue>();
            keyValues.Add(new KeyValue(lat, ' ', ' ', ' ', 3));
            keyValues.Add(new KeyValue(ru, ' ', ' ', ' ', 3));
            keys.Add(new KeyText("vk_rshift", keyValues, 0x2A, 0xAA, 0xA0));

            keyValues = new List<KeyValue>();
            keyValues.Add(new KeyValue(lat, ' ', ' ', ' ', 3));
            keyValues.Add(new KeyValue(ru, ' ', ' ', ' ', 3));
            keys.Add(new KeyText("vk_up", keyValues, 0x48, 0xC8, 0x26));

            keyValues = new List<KeyValue>();
            keyValues.Add(new KeyValue(lat, ' ', ' ', ' ', 3));
            keyValues.Add(new KeyValue(ru, ' ', ' ', ' ', 3));
            keys.Add(new KeyText("vk_right", keyValues, 0x4D, 0xCD, 0x27));

            keyValues = new List<KeyValue>();
            keyValues.Add(new KeyValue(lat, ' ', ' ', ' ', 3));
            keyValues.Add(new KeyValue(ru, ' ', ' ', ' ', 3));
            keys.Add(new KeyText("vk_down", keyValues, 0x50, 0xD0, 0x28));

            keyValues = new List<KeyValue>();
            keyValues.Add(new KeyValue(lat, ' ', ' ', ' ', 3));
            keyValues.Add(new KeyValue(ru, ' ', ' ', ' ', 3));
            keys.Add(new KeyText("vk_left", keyValues, 0x4B, 0xCB, 0x25));


        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            /*

            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
            */
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public void changeKeyboard()
        {
            q_label = getKeyLabel("vk_q").ToString();
            w_label = getKeyLabel("vk_w").ToString();
            e_label = getKeyLabel("vk_e").ToString();
            r_label = getKeyLabel("vk_r").ToString();
            t_label = getKeyLabel("vk_t").ToString();
            y_label = getKeyLabel("vk_y").ToString();
            u_label = getKeyLabel("vk_u").ToString();
            i_label = getKeyLabel("vk_i").ToString();
            o_label = getKeyLabel("vk_o").ToString();
            p_label = getKeyLabel("vk_p").ToString();

            a_label = getKeyLabel("vk_a").ToString();
            s_label = getKeyLabel("vk_s").ToString();
            d_label = getKeyLabel("vk_d").ToString();
            f_label = getKeyLabel("vk_f").ToString();
            g_label = getKeyLabel("vk_g").ToString();
            h_label = getKeyLabel("vk_h").ToString();
            j_label = getKeyLabel("vk_j").ToString();
            k_label = getKeyLabel("vk_k").ToString();
            l_label = getKeyLabel("vk_l").ToString();

            z_label = getKeyLabel("vk_z").ToString();
            x_label = getKeyLabel("vk_x").ToString();
            c_label = getKeyLabel("vk_c").ToString();
            v_label = getKeyLabel("vk_v").ToString();
            b_label = getKeyLabel("vk_b").ToString();
            n_label = getKeyLabel("vk_n").ToString();
            m_label = getKeyLabel("vk_m").ToString();

            baps_label = getKeyLabel("vk_baps").ToString();
            minus_label = getKeyLabel("vk_minus").ToString();
            plus_label = getKeyLabel("vk_plus").ToString();
            leftbr_label = getKeyLabel("vk_leftbr").ToString();
            rightbr_label = getKeyLabel("vk_rightbr").ToString();
            bslash_label = getKeyLabel("vk_bslash").ToString();
            column_label = getKeyLabel("vk_column").ToString();
            aps_label = getKeyLabel("vk_aps").ToString();
            comma_label = getKeyLabel("vk_comma").ToString();
            dot_label = getKeyLabel("vk_dot").ToString();
            slash_label = getKeyLabel("vk_slash").ToString();
            space_label = getKeyLabel("vk_space").ToString();

            label_1 = getKeyLabel("vk_1").ToString();
            label_2 = getKeyLabel("vk_2").ToString();
            label_3 = getKeyLabel("vk_3").ToString();
            label_4 = getKeyLabel("vk_4").ToString();
            label_5 = getKeyLabel("vk_5").ToString();
            label_6 = getKeyLabel("vk_6").ToString();
            label_7 = getKeyLabel("vk_7").ToString();
            label_8 = getKeyLabel("vk_8").ToString();
            label_9 = getKeyLabel("vk_9").ToString();
            label_0 = getKeyLabel("vk_0").ToString();

        }

        public byte getKeyCode(string keyName)
        {
            byte keyCode = 0;
            KeyText key = keys.Find(x => x.keyName.Equals(keyName));
            if (key != null)
            {
                keyCode = key.keyCode;
            }
            return keyCode;
        }

        public byte getKeyDown(string keyName)
        {
            byte keyCode = 0;
            KeyText key = keys.Find(x => x.keyName.Equals(keyName));
            if (key != null)
            {
                keyCode = key.keyDown;
            }
            return keyCode;
        }

        public byte getKeyUp(string keyName)
        {
            byte keyCode = 0;
            KeyText key = keys.Find(x => x.keyName.Equals(keyName));
            if (key != null)
            {
                keyCode = key.keyUp;
            }
            return keyCode;
        }


        public char getKeyLabel(string keyName)
        {
            char keyLabel = (char)0;
            KeyText key = keys.Find(x => x.keyName.Equals(keyName));

            if (key != null)
            {
                KeyValue keyVal = key.keyValues.Find(x => x.Locale.Equals(Locale));
                if (keyVal != null)
                {
                    if (keyVal.KeyType == 1) // letter
                        keyLabel = ((Caps && !Shift) || (!Caps && Shift) ? keyVal.CapsValue : keyVal.DefValue);
                    else if (keyVal.KeyType == 2) // figure
                        keyLabel = (Shift ? keyVal.ShiftValue : keyVal.DefValue);
                }
            }
            return keyLabel;
        }

        private string _q_label;
        public string q_label
        {
            get { return _q_label;  }
            set { _q_label = value;
                //OnPropertyChanged("q_label");
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(q_label)));
            }
        }

        private string _w_label;
        public string w_label
        {
            get { return _w_label; }
            set
            {
                _w_label = value;
                OnPropertyChanged("w_label");
            }
        }

        private string _e_label;
        public string e_label
        {
            get { return _e_label; }
            set
            {
                _e_label = value;
                OnPropertyChanged("e_label");
            }
        }

        private string _r_label;
        public string r_label
        {
            get { return _r_label; }
            set
            {
                _r_label = value;
                OnPropertyChanged("r_label");
            }
        }

        private string _t_label;
        public string t_label
        {
            get { return _t_label; }
            set
            {
                _t_label = value;
                OnPropertyChanged("t_label");
            }
        }

        private string _y_label;
        public string y_label
        {
            get { return _y_label; }
            set
            {
                _y_label = value;
                OnPropertyChanged("y_label");
            }
        }

        private string _u_label;
        public string u_label
        {
            get { return _u_label; }
            set
            {
                _u_label = value;
                OnPropertyChanged("u_label");
            }
        }

        private string _i_label;
        public string i_label
        {
            get { return _i_label; }
            set
            {
                _i_label = value;
                OnPropertyChanged("i_label");
            }
        }

        private string _o_label;
        public string o_label
        {
            get { return _o_label; }
            set
            {
                _o_label = value;
                OnPropertyChanged("o_label");
            }
        }

        private string _p_label;
        public string p_label
        {
            get { return _p_label; }
            set
            {
                _p_label = value;
                OnPropertyChanged("p_label");
            }
        }

        private string _a_label;
        public string a_label
        {
            get { return _a_label; }
            set
            {
                _a_label = value;
                OnPropertyChanged("a_label");
            }
        }

        private string _s_label;
        public string s_label
        {
            get { return _s_label; }
            set
            {
                _s_label = value;
                OnPropertyChanged("s_label");
            }
        }

        private string _d_label;
        public string d_label
        {
            get { return _d_label; }
            set
            {
                _d_label = value;
                OnPropertyChanged("d_label");
            }
        }

        private string _f_label;
        public string f_label
        {
            get { return _f_label; }
            set
            {
                _f_label = value;
                OnPropertyChanged("f_label");
            }
        }

        private string _g_label;
        public string g_label
        {
            get { return _g_label; }
            set
            {
                _g_label = value;
                OnPropertyChanged("g_label");
            }
        }

        private string _h_label;
        public string h_label
        {
            get { return _h_label; }
            set
            {
                _h_label = value;
                OnPropertyChanged("h_label");
            }
        }

        private string _j_label;
        public string j_label
        {
            get { return _j_label; }
            set
            {
                _j_label = value;
                OnPropertyChanged("j_label");
            }
        }

        private string _k_label;
        public string k_label
        {
            get { return _k_label; }
            set
            {
                _k_label = value;
                OnPropertyChanged("k_label");
            }
        }

        private string _l_label;
        public string l_label
        {
            get { return _l_label; }
            set
            {
                _l_label = value;
                OnPropertyChanged("l_label");
            }
        }

        private string _z_label;
        public string z_label
        {
            get { return _z_label; }
            set
            {
                _z_label = value;
                OnPropertyChanged("z_label");
            }
        }

        private string _x_label;
        public string x_label
        {
            get { return _x_label; }
            set
            {
                _x_label = value;
                OnPropertyChanged("x_label");
            }
        }

        private string _c_label;
        public string c_label
        {
            get { return _c_label; }
            set
            {
                _c_label = value;
                OnPropertyChanged("c_label");
            }
        }

        private string _v_label;
        public string v_label
        {
            get { return _v_label; }
            set
            {
                _v_label = value;
                OnPropertyChanged("v_label");
            }
        }

        private string _b_label;
        public string b_label
        {
            get { return _b_label; }
            set
            {
                _b_label = value;
                OnPropertyChanged("b_label");
            }
        }

        private string _n_label;
        public string n_label
        {
            get { return _n_label; }
            set
            {
                _n_label = value;
                OnPropertyChanged("n_label");
            }
        }

        private string _m_label;
        public string m_label
        {
            get { return _m_label; }
            set
            {
                _m_label = value;
                OnPropertyChanged("m_label");
            }
        }

        private string _baps_label;
        public string baps_label
        {
            get { return _baps_label; }
            set
            {
                _baps_label = value;
                OnPropertyChanged("baps_label");
                // PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(baps_label)));
            }
        }

        private string _1_label;
        public string label_1
        {
            get { return _1_label; }
            set
            {
                _1_label = value;
                OnPropertyChanged("label_1");
            }
        }

        private string _2_label;
        public string label_2
        {
            get { return _2_label; }
            set
            {
                _2_label = value;
                OnPropertyChanged("label_2");
            }
        }

        private string _3_label;
        public string label_3
        {
            get { return _3_label; }
            set
            {
                _3_label = value;
                OnPropertyChanged("label_3");
            }
        }

        private string _4_label;
        public string label_4
        {
            get { return _4_label; }
            set
            {
                _4_label = value;
                OnPropertyChanged("label_4");
            }
        }

        private string _5_label;
        public string label_5
        {
            get { return _5_label; }
            set
            {
                _5_label = value;
                OnPropertyChanged("label_5");
            }
        }

        private string _6_label;
        public string label_6
        {
            get { return _6_label; }
            set
            {
                _6_label = value;
                OnPropertyChanged("label_6");
            }
        }

        private string _7_label;
        public string label_7
        {
            get { return _7_label; }
            set
            {
                _7_label = value;
                OnPropertyChanged("label_7");
            }
        }

        private string _8_label;
        public string label_8
        {
            get { return _8_label; }
            set
            {
                _8_label = value;
                OnPropertyChanged("label_8");
            }
        }

        private string _9_label;
        public string label_9
        {
            get { return _9_label; }
            set
            {
                _9_label = value;
                OnPropertyChanged("label_9");
            }
        }

        private string _0_label;
        public string label_0
        {
            get { return _0_label; }
            set
            {
                _0_label = value;
                OnPropertyChanged("label_0");
            }
        }

        private string _minus_label;
        public string minus_label
        {
            get { return _minus_label; }
            set
            {
                _minus_label = value;
                OnPropertyChanged("minus_label");
            }
        }

        private string _plus_label;
        public string plus_label
        {
            get { return _plus_label; }
            set
            {
                _plus_label = value;
                OnPropertyChanged("plus_label");
            }
        }

        private string _leftbr_label;
        public string leftbr_label
        {
            get { return _leftbr_label; }
            set
            {
                _leftbr_label = value;
                OnPropertyChanged("leftbr_label");
            }
        }

        private string _rightbr_label;
        public string rightbr_label
        {
            get { return _rightbr_label; }
            set
            {
                _rightbr_label = value;
                OnPropertyChanged("rightbr_label");
            }
        }

        private string _bslash_label;
        public string bslash_label
        {
            get { return _bslash_label; }
            set
            {
                _bslash_label = value;
                OnPropertyChanged("bslash_label");
            }
        }

        private string _column_label;
        public string column_label
        {
            get { return _column_label; }
            set
            {
                _column_label = value;
                OnPropertyChanged("column_label");
            }
        }

        private string _aps_label;
        public string aps_label
        {
            get { return _aps_label; }
            set
            {
                _aps_label = value;
                OnPropertyChanged("aps_label");
            }
        }

        private string _comma_label;
        public string comma_label
        {
            get { return _comma_label; }
            set
            {
                _comma_label = value;
                OnPropertyChanged("comma_label");
            }
        }

        private string _dot_label;
        public string dot_label
        {
            get { return _dot_label; }
            set
            {
                _dot_label = value;
                OnPropertyChanged("dot_label");
            }
        }

        private string _slash_label;
        public string slash_label
        {
            get { return _slash_label; }
            set
            {
                _slash_label = value;
                OnPropertyChanged("slash_label");
            }
        }

        private string _space_label;
        public string space_label
        {
            get { return _space_label; }
            set
            {
                _space_label = value;
                OnPropertyChanged("space_label");
            }
        }


    }
}
