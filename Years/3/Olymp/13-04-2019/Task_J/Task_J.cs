using System;
using System.Text;

namespace Task_J
{
    class Task_J
    {
        static void Main(string[] args)
        {
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var values = Console.ReadLine().Split(' ');
            int n = int.Parse(values[0]);
            int k = int.Parse(values[1]);
            var speach = new StringBuilder();
            for (int i = 0; i < k; i++)
            {
                speach.Append("Z");
            }
            int alphabetIndex = 0;
            for (int i = 0; i < n - k; i++)
            {
                speach.Append(alphabet[alphabetIndex]);
                alphabetIndex++;
                if (alphabetIndex >= alphabet.Length)
                {
                    alphabetIndex = 0;
                }
            }
            Console.Write(speach.ToString());
        }
    }
}