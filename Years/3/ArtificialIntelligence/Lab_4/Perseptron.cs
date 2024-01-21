using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab_2
{
    public class Perseptron
    {
        ulong epoch;
        public double CoefficientOfEducationSpeed { get; set; }
        List<Neiron> neirons;

        List<bool> lastSignals;
        List<double> lastRecognize;

        public ulong GetEpoch()
        {
            return epoch;
        }

        public Perseptron(string fileName, int numberOfNeirons, int size)
        {
            FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate);
            BinaryReader br = new BinaryReader(fs);

            long len = fs.Length;

            var wages = new List<double>();

            neirons = new List<Neiron>();

            if (len == 0 || len - 16 != (size * 8 * numberOfNeirons))
            {
                epoch = 0;
                CoefficientOfEducationSpeed = 0.9;
                //var random = new Random();
                for (int i = 0; i < numberOfNeirons; i++)
                {
                    wages.Clear();
                    for (int j = 0; j < size; j++)
                    {
                        //wages.Add(random.NextDouble());
                        wages.Add(0.0);
                    }
                    neirons.Add(new Neiron(wages));
                }
            }
            else
            {
                fs.Seek(0, SeekOrigin.Begin);
                epoch = br.ReadUInt64();
                fs.Seek(8, SeekOrigin.Begin);
                CoefficientOfEducationSpeed = br.ReadDouble();

                for (int i = 0; i < numberOfNeirons; i++)
                {
                    wages.Clear();
                    for (long p = 16 + i * size * 8; p < 16 + i * size * 8 + size * 8; p += 8)
                    {
                        fs.Seek(p, SeekOrigin.Begin);                        
                        wages.Add(br.ReadDouble());
                    }
                    neirons.Add(new Neiron(wages));
                }                
            }

            br.Close();
            fs.Close();
        }

        public List<double> Recognize(List<bool> signals)
        {
            lastSignals = new List<bool>(signals);
            lastRecognize = new List<double>();

            foreach (var item in neirons)
            {
                lastRecognize.Add(item.Recognize(lastSignals));
            }

            return new List<double>(lastRecognize);
        }

        public void Education(List<bool> desireResponse)
        {
            for (int i = 0; i < neirons.Count; i++)
            {
                double d = desireResponse[i] ? 1.0 : 0.0;
                double y = lastRecognize[i];
                double error = y * (1.0 - y) * (d - y);
                neirons[i].Education(error, CoefficientOfEducationSpeed, lastSignals);
            }

            epoch++;
        }

        public void SaveToFile(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);

            bw.Write(epoch);
            bw.Write(CoefficientOfEducationSpeed);
            foreach (var neiron in neirons)
            {
                foreach (var wage in neiron.wages)
                {
                    bw.Write(wage);
                }
            }

            bw.Close();
            fs.Close();
        }
    }
}
