using System;
using System.Collections.ObjectModel;
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
        private ObservableCollection<AlphabetListItem> AlphabetList { get; } = new ObservableCollection<AlphabetListItem>();

        private ObservableCollection<AlphabetListItem> AlphabetList_Decrypt { get; } = new ObservableCollection<AlphabetListItem>();

        private CaesarAffinitySystem encryption = new CaesarAffinitySystem();

        private CaesarAffinitySystem encryption_Decrypt = new CaesarAffinitySystem();

        public MainWindow()
        {
            InitializeComponent();
            listViewAlphabet.ItemsSource = AlphabetList;
            listViewAlphabet_Decrypt.ItemsSource = AlphabetList_Decrypt;
        }

        private void ButtonEncrypt_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxIn.Text.Length == 0)
            {
                MessageBox.Show("Поле незашифрованого тексту порожнє!");
            }
            else if (encryption.AlphabetByLetter.Count == 0)
            {
                MessageBox.Show("Алфавіт порожній!");
            }            
            else
            {
                textBoxOut.Text = encryption.Encrypt(textBoxIn.Text);
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

        private void ButtonOpenFileAlphabet_Click(object sender, RoutedEventArgs e)
        {
            if (uint.TryParse(textBoxKeyA.Text, out uint keyA) == false
                || uint.TryParse(textBoxKeyB.Text, out uint keyB) == false)
            {
                MessageBox.Show("Некоректно задані ключі шифрування, необхідні для побудови алфавіту!");
            }
            else
            {
                var file = new OpenFileDialog
                {
                    Title = "Оберіть текстовий файл для побудови алфавіту",
                    Filter = "*.txt|*.txt|*.*|*.*"
                };
                if (file.ShowDialog() ?? false)
                {                    
                    try
                    {
                        encryption.BuildAlphabetFromFile(file.FileName);
                        encryption.BuildCodeDictionary(keyA, keyB);
                        AlphabetList.Clear();
                        foreach (var letter in encryption.AlphabetByLetter.Keys)
                        {
                            AlphabetList.Add(new AlphabetListItem
                            {
                                LetterReal = letter,
                                NumberReal = encryption.AlphabetByLetter[letter],
                                LetterEncrypt = encryption.Encrypt(letter),
                                NumberEncrypt = encryption.AlphabetByLetter[encryption.Encrypt(letter)]
                            });
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }                    
                }
            }
        }

        private void ButtonDecrypt_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxIn_Decrypt.Text.Length == 0)
            {
                MessageBox.Show("Поле зашифрованого тексту порожнє!");
            }
            else if (encryption_Decrypt.AlphabetByLetter.Count == 0)
            {
                MessageBox.Show("Алфавіт порожній!");
            }
            else
            {
                textBoxOut_Decrypt.Text = encryption_Decrypt.Decrypt(textBoxIn_Decrypt.Text);
            }
        }

        private void ButtonSaveFileOut_Decrypt_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxOut_Decrypt.Text.Length == 0)
            {
                MessageBox.Show("Поле розшифрованого тексту порожнє!");
            }
            else
            {
                var file = new SaveFileDialog
                {
                    Title = "Збереження розшифрованого файлу",
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

        private void ButtonOpenFileIn_Decrypt_Click(object sender, RoutedEventArgs e)
        {
            var file = new OpenFileDialog
            {
                Title = "Оберіть файл з текстом для розшифровки",
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

        private void ButtonOpenFileAlphabet_Decrypt_Click(object sender, RoutedEventArgs e)
        {
            if (uint.TryParse(textBoxKeyA_Decrypt.Text, out uint keyA) == false
                || uint.TryParse(textBoxKeyB_Decrypt.Text, out uint keyB) == false)
            {
                MessageBox.Show("Некоректно задані ключі шифрування, необхідні для побудови алфавіту!");
            }
            else
            {
                var file = new OpenFileDialog
                {
                    Title = "Оберіть текстовий файл для побудови алфавіту",
                    Filter = "*.txt|*.txt|*.*|*.*"
                };
                if (file.ShowDialog() ?? false)
                {
                    try
                    {
                        encryption_Decrypt.BuildAlphabetFromFile(file.FileName);
                        encryption_Decrypt.BuildCodeDictionary(keyA, keyB);
                        AlphabetList_Decrypt.Clear();
                        foreach (var letter in encryption_Decrypt.AlphabetByLetter.Keys)
                        {
                            AlphabetList_Decrypt.Add(new AlphabetListItem
                            {
                                LetterReal = letter,
                                NumberReal = encryption_Decrypt.AlphabetByLetter[letter],
                                LetterEncrypt = encryption_Decrypt.Encrypt(letter),
                                NumberEncrypt = encryption_Decrypt.AlphabetByLetter[encryption_Decrypt.Encrypt(letter)]
                            });
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
    }    
}
