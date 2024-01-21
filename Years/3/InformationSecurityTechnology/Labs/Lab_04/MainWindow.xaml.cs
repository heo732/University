using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.IO;
using Encryption;
using Microsoft.Win32;

namespace Lab_03
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static bool IsCorrectKey(string str)
        {
            if (str.Length != 10)
            {
                return false;
            }
            else
            {
                foreach (var item in str)
                {
                    if ((item != '0') && (item != '1'))
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        private static BitArray GetKey(string keyStr)
        {
            var bits = new List<bool>();
            for (int i = 9; i >= 0; i--)
            {
                bits.Add(keyStr[i] == '0' ? false : true);
            }
            return new BitArray(bits.ToArray());
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonEncrypt_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxIn.Text.Length == 0)
            {
                MessageBox.Show("Поле відкритого тексту порожнє!");
            }
            else if (!IsCorrectKey(textBoxKey.Text))
            {
                MessageBox.Show("Некоректний ключ!");
            }            
            else
            {
                BitArray key = GetKey(textBoxKey.Text);
                textBoxOut.Text = S_DES.Encrypt(key, textBoxIn.Text);
            }
        }

        private void ButtonSaveFileOut_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxOut.Text.Length == 0)
            {
                MessageBox.Show("Поле зашифрованого тексту порожнє!");
            }
            else
            {
                var file = new SaveFileDialog
                {
                    Title = "Збереження зашифрованого файлу",
                    AddExtension = true,
                    Filter = "*.txt|*.txt|*.*|*.*"
                };
                if (file.ShowDialog() ?? false)
                {
                    using (var writer = new StreamWriter(file.FileName))
                    {
                        writer.Write(textBoxOut.Text);
                    }
                }
            }
        }

        private void ButtonOpenFileIn_Click(object sender, RoutedEventArgs e)
        {
            var file = new OpenFileDialog
            {
                Title = "Оберіть файл з текстом для шифрування",
                Filter = "*.txt|*.txt|*.*|*.*"
            };
            if (file.ShowDialog() ?? false)
            {
                using (var reader = new StreamReader(file.FileName))
                {
                    textBoxIn.Text = reader.ReadToEnd();
                }
            }
        }       

        private void ButtonDecrypt_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxIn_Decrypt.Text.Length == 0)
            {
                MessageBox.Show("Поле зашифрованого тексту порожнє!");
            }
            else if (!IsCorrectKey(textBoxKey_Decrypt.Text))
            {
                MessageBox.Show("Некоректний ключ!");
            }
            else
            {
                BitArray key = GetKey(textBoxKey_Decrypt.Text);
                textBoxOut_Decrypt.Text = S_DES.Decrypt(key, textBoxIn_Decrypt.Text);
            }
        }

        private void ButtonSaveFileOut_Decrypt_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxOut_Decrypt.Text.Length == 0)
            {
                MessageBox.Show("Поле відкритого тексту порожнє!");
            }
            else
            {
                var file = new SaveFileDialog
                {
                    Title = "Збереження файлу з відкритим текстом",
                    AddExtension = true,
                    Filter = "*.txt|*.txt|*.*|*.*"
                };
                if (file.ShowDialog() ?? false)
                {
                    using (var writer = new StreamWriter(file.FileName))
                    {
                        writer.Write(textBoxOut_Decrypt.Text);
                    }
                }
            }
        }

        private void ButtonOpenFileIn_Decrypt_Click(object sender, RoutedEventArgs e)
        {
            var file = new OpenFileDialog
            {
                Title = "Оберіть файл із зашифрованим текстом",
                Filter = "*.txt|*.txt|*.*|*.*"
            };
            if (file.ShowDialog() ?? false)
            {
                using (var reader = new StreamReader(file.FileName))
                {
                    textBoxIn_Decrypt.Text = reader.ReadToEnd();
                }
            }
        }
    }    
}
