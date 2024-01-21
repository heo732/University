using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Lab_03
{
    public class AlphabetListItem : INotifyPropertyChanged
    {
        private uint numberReal;
        private char letterReal;
        private char letterEncrypt;
        private uint numberEncrypt;

        public uint NumberReal
        {
            get { return numberReal; }
            set
            {
                numberReal = value;
                OnPropertyChanged("NumberReal");
            }
        }

        public char LetterReal
        {
            get { return letterReal; }
            set
            {
                letterReal = value;
                OnPropertyChanged("LetterReal");
            }
        }

        public char LetterEncrypt
        {
            get { return letterEncrypt; }
            set
            {
                letterEncrypt = value;
                OnPropertyChanged("LetterEncrypt");
            }
        }

        public uint NumberEncrypt
        {
            get { return numberEncrypt; }
            set
            {
                numberEncrypt = value;
                OnPropertyChanged("NumberEncrypt");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
