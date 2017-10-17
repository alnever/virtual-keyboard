using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tastatur_1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        const int WS_EX_NOACTIVATE = 0x08000000;
        const int GWL_EXSTYLE = -20;

        [DllImport("user32", SetLastError = true)]
        private extern static int GetWindowLong(IntPtr hwnd, int nIndex);

        [DllImport("user32", SetLastError = true)]
        private extern static int SetWindowLong(IntPtr hwnd, int nIndex, int dwNewValue);

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            WindowInteropHelper wih = new WindowInteropHelper(this);
            int exstyle = GetWindowLong(wih.Handle, GWL_EXSTYLE);
            exstyle |= WS_EX_NOACTIVATE;
            SetWindowLong(wih.Handle, GWL_EXSTYLE, exstyle);
        }

        public static MainWindow mainWindow;
        private KeyBoard keyBoard;
        public KeyBoard _keyBoard {
                get { return keyBoard;  }
                set { keyBoard = value;  }
            }


        public MainWindow()
        {
            InitializeComponent();
            _keyBoard = (KeyBoard)this.Resources["keyBoard"];
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo(keyBoard.Locale));
        }

        private void vk_caps_MouseUp(object sender, MouseButtonEventArgs e)
        {
            keyBoard.Caps = !keyBoard.Caps;
            keyBoard.changeKeyboard();
            key_MouseUp(sender, e);
        }

        private void vk_shift_MouseUp(object sender, MouseButtonEventArgs e)
        {
            keyBoard.Shift = true;
            keyBoard.changeKeyboard();
            key_MouseDown(sender, e);
        }

        private void vk_latrus_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (keyBoard.Locale == keyBoard.ru)
                keyBoard.Locale = keyBoard.lat;
            else
                keyBoard.Locale = keyBoard.ru;

            keyBoard.changeKeyboard();

            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo(keyBoard.Locale));
        }



        private void key_MouseDown(object sender, MouseButtonEventArgs e)
        {
            byte keyCode = keyBoard.getKeyCode(((TextBlock)sender).Name);
            byte keyDown = keyBoard.getKeyDown(((TextBlock)sender).Name);

            keybd_event(keyCode, keyDown, 0, 0);
        }

        private void key_MouseUp(object sender, MouseButtonEventArgs e)
        {
            byte keyCode = keyBoard.getKeyCode(((TextBlock)sender).Name);
            byte keyUp = keyBoard.getKeyUp(((TextBlock)sender).Name);

            keybd_event(keyCode, keyUp, 2, 0);
            
            if (keyBoard.Shift)
            {
                keyBoard.Shift = false;
                keyBoard.changeKeyboard();
                keyCode = keyBoard.getKeyCode("vk_lshift");
                keyUp = keyBoard.getKeyUp("vk_lshift");
                keybd_event(keyCode, keyUp, 2, 0);
            }
            
        }

    }
}
