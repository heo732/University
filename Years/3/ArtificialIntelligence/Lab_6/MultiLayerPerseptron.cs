using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    public class MultiLayerPerseptron
    {
        private List<NeuralLayer> layers;

        public MultiLayerPerseptron(List<NeuralLayer> layers)
        {
            this.layers = new List<NeuralLayer>(layers);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputSignals">Must contains signal[0] = 1.0 for for wages[0]</param>
        /// <returns>Out signals list</returns>
        public List<double> MakeOutputSignals(List<double> inputSignals)
        {
            var ret = new List<double>(inputSignals);
            foreach (var item in layers)
            {
                ret = item.MakeOutputSignals(ret);
                ret.Insert(0, 1.0);
            }
            ret.RemoveAt(0);
            return ret;
        }

        public void Educate(List<double> desireResponse, double educationSpeed)
        {
            //errors of upper layer (output layer)
            var prevErrors = new List<double>();

            //index for layers
            int k = layers.Count - 1;

            for (int i = 0; i < layers[k].neurons.Count; i++)
            {
                double y = layers[k].lastOutputSignals[i];
                prevErrors.Add( y * ( 1.0 - y ) * ( desireResponse[i] - y ) );
            }

            //Educate the output layer
            layers[k].Educate(educationSpeed: educationSpeed, errors: prevErrors);
            k--;
            
                        
            while (k >= 0)
            {
                //errors of lower layer (input layer)
                var nextErrors = new List<double>();

                for (int i = 0; i < layers[k].neurons.Count; i++)
			    {
                    double y = layers[k].lastOutputSignals[i];
                    double sum = 0.0;
                    for (int l = 0; l < layers[k+1].neurons.Count; l++)
                        //sum += prevErrors[l] * layers[k + 1].neurons[l].wages[i];
                        sum += prevErrors[l] * layers[k + 1].neurons[l].wages[i + 1];
                    nextErrors.Add( y * ( 1.0 - y ) * sum );
			    }
                
                //Educate current layer
                layers[k].Educate(educationSpeed: educationSpeed, errors: nextErrors);

                k--;
                prevErrors = new List<double>(nextErrors);
            }
        }
    }

    public class NeuralLayer
    {
        /// <summary>
        /// All the neurons must be initialized with random wages.
        /// All the neurons must be different.
        /// </summary>
        public List<Neuron> neurons;

        public List<double> lastOutputSignals;
        
        public NeuralLayer(List<Neuron> neurons)
        {
            this.neurons = new List<Neuron>(neurons);
        }

        public List<double> MakeOutputSignals(List<double> inputSignals)
        {
            lastOutputSignals = new List<double>();
            foreach (var item in neurons)
                lastOutputSignals.Add(item.MakeOutputSignal(inputSignals));
            return new List<double>(lastOutputSignals);
        }

        public void Educate(double educationSpeed, List<double> errors)
        {
            for (int i = 0; i < neurons.Count; i++)
                neurons[i].Educate(educationSpeed: educationSpeed, error: errors[i]);
        }
    }
        
    public class Neuron
    {
        public List<double> wages;
        protected List<double> lastInputSignals;
        private static Random random = new Random();

        public delegate double ActivationFunction(double sum);
        private ActivationFunction activationFunction;

        public Neuron(int numberOfWages, ActivationFunction activationFunction)
        {
            wages = new List<double>();
            for (int i = 0; i < numberOfWages; i++)
            {
                //wages.Add(-0.00001 + random.NextDouble() * 0.00002);
                wages.Add(random.NextDouble());
            }

            this.activationFunction = activationFunction;
        }

        public double MakeOutputSignal(List<double> inputSignals)
        {
            lastInputSignals = new List<double>(inputSignals);

            double sum = 0.0;
            for (int i = 0; i < wages.Count; i++)
            {
                sum += wages[i] * lastInputSignals[i];
            }

            return activationFunction(sum);
        }

        public void Educate(double educationSpeed, double error)
        {
            for (int j = 0; j < wages.Count; j++)
            {
                wages[j] += educationSpeed * lastInputSignals[j] * error;
            }
        }
    }
}
