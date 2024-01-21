using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    public class Neiron
    {
        public List<double> wages;

        public Neiron(List<double> _wages)
        {
            wages = new List<double>(_wages);
        }

        public double Recognize(List<bool> signals)
        {
            double sum = 0;
            for (int i = 0; i < wages.Count; i++)
            {
                if (signals[i])
                    sum += wages[i];
            }
            return 1.0 / (1.0 + Math.Exp(-sum) );
        }

        public void Education(double error, double coefficientOfEducationSpeed, List<bool> signals)
        {
            if (coefficientOfEducationSpeed != 0.0 && error != 0.0)
                for (int i = 0; i < wages.Count; i++)
                {
                    if (signals[i])
                        wages[i] += coefficientOfEducationSpeed * error;
                }
        }
    }
}