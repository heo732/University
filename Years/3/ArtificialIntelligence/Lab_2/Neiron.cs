using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab_2
{
    public class Neiron
    {
        ulong epoch { get; set; }
        public long thresholdOfSensitivity { get; set; }
        long[,] wages;
        bool[,] lastSignals;
        bool lastRecognize;

        public Neiron(string fileName, long size1, long size2)
        {
            FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate);
            BinaryReader br = new BinaryReader(fs);

            long size = fs.Length;

            wages = new long[size1, size2];

            if (size == 0 || size - 16 != (size1 * size2 * 8))
            {
                epoch = 0;
                thresholdOfSensitivity = new Random().Next(-5, 6);                
                for (int i = 0; i < size1; i++)
                {
                    for (int j = 0; j < size2; j++)
                    {
                        wages[i, j] = new Random().Next(-5, 6);
                    }
                }
            }
            else
            {
                fs.Seek(0, SeekOrigin.Begin);
                epoch = br.ReadUInt64();
                fs.Seek(8, SeekOrigin.Begin);
                thresholdOfSensitivity = br.ReadInt64();

                for (long p = 16, i = 0, j = 0; p < size; p += 8, j++)
                {
                    fs.Seek(p, SeekOrigin.Begin);
                    if (j == size2)
                    {
                        j = 0;
                        i++;
                    }
                    wages[i, j] = br.ReadInt64();
                }
            }

            br.Close();
            fs.Close();
        }

        public void SaveToFile(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);

            bw.Write(epoch);
            bw.Write(thresholdOfSensitivity);
            foreach (var item in wages)
            {
                bw.Write(item);
            }

            bw.Close();
            fs.Close();
        }

        public bool Recognize(bool[,] signals)
        {
            lastSignals = new bool[signals.GetLength(0), signals.GetLength(1)];
            for (int i = 0; i < signals.GetLength(0); i++)
            {
                for (int j = 0; j < signals.GetLength(1); j++)
                {
                    lastSignals[i, j] = signals[i, j];
                }
            }

            long sum = 0;
            for (int i = 0; i < signals.GetLength(0); i++)
            {
                for (int j = 0; j < signals.GetLength(1); j++)
                {
                    if (signals[i, j])
                        sum += wages[i, j];
                }
            }
            lastRecognize = sum >= thresholdOfSensitivity ? true : false;
            return lastRecognize;
        }

        public void Education()
        {
            if (lastRecognize)
            {
                for (int i = 0; i < lastSignals.GetLength(0); i++)
                {
                    for (int j = 0; j < lastSignals.GetLength(1); j++)
                    {
                        if (lastSignals[i, j])
                            wages[i, j]--;
                    }
                }
            }
            else
            {
                for (int i = 0; i < lastSignals.GetLength(0); i++)
                {
                    for (int j = 0; j < lastSignals.GetLength(1); j++)
                    {
                        if (lastSignals[i, j])
                            wages[i, j]++;
                    }
                }
            }

            epoch++;
        }

        public ulong GetEpoch()
        {
            return epoch;
        }
    }
}