using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genetic
{
    public class GeneticAlgorithm
    {
        public delegate double FitnessFunction(ulong x);
        private Random random = new Random();

        private FitnessFunction fitnessFunction;
        private int populationSize;
        private int numberGenesInChromosome;
        private double probabilityMutation;
        private double probabilityCrossover;

        // Person phenotype in decimal & genotype in binary.
        private List<ulong> population;
        private List<double> adaptability;

        public GeneticAlgorithm(int populationSize, int numberGenesInChromosome,
            double probabilityCrossover, double probabilityMutation, FitnessFunction fitnessFunction)
        {
            if (populationSize < 1)
                throw new ArgumentOutOfRangeException("populationSize", "Size of population may not be less than 1!");
            if (numberGenesInChromosome < 2)
                throw new ArgumentOutOfRangeException("numberGenesInChromosome", "Number of genes in chromosome may not be less than 2!");
            if (probabilityMutation < 0.0 || probabilityMutation > 1.0)
                throw new ArgumentOutOfRangeException("probabilityMutation", "Probability of mutation must be in range [0,1].");
            if (probabilityCrossover < 0.0 || probabilityCrossover > 1.0)
                throw new ArgumentOutOfRangeException("probabilityCrossover", "Probability of crossover must be in range [0,1].");           
            if (fitnessFunction == null)
                throw new NullReferenceException("Fitness function may not be null-reference!");

            this.fitnessFunction = fitnessFunction;
            fitnessFunction = null;

            this.populationSize = populationSize;
            this.numberGenesInChromosome = numberGenesInChromosome;
            this.probabilityCrossover = probabilityCrossover;
            this.probabilityMutation = probabilityMutation;

            CreateStartPopulation();
        }

        private void RecalculateAdaptability()
        {
            adaptability = new List<double>();

            foreach (var item in population)
            {
                adaptability.Add(fitnessFunction(item));
            }
        }

        public ulong GetPhenotypeOfMaxAdaptedPerson()
        {
            return population[adaptability.IndexOf(adaptability.Max())];
        }

        private void CreateStartPopulation()
        {
            population = new List<ulong>();

            for (int i = 0; i < populationSize; i++)
            {
                ulong newValue = (ulong)random.Next(int.MaxValue);
                // shift of excessive bits
                newValue <<= 64 - numberGenesInChromosome;
                newValue >>= 64 - numberGenesInChromosome;
                population.Add( newValue );
            }

            RecalculateAdaptability();
        }

        // Calculate next generation.
        public void NextGeneration()
        {
            population = Mutation( Crossing( Selection() ) );

            RecalculateAdaptability();
        }

        // Return parents which are allowed to crossing.
        // <<Roulette>>.
        private List<ulong> Selection()
        {
            var parents = new List<ulong>();

            double sumAdaptability = adaptability.Sum();
            
            for (int i = 0; i < populationSize; i++)
            {
                double fillSectors = 0.0;
                int index = 0;
                // 99.99 -> max
                double r = (double)random.Next(100) + (double)random.Next(100) / 100.0;
                while (index < population.Count && !(fillSectors <= r && r < fillSectors + adaptability[index] / sumAdaptability))
                {
                    fillSectors += adaptability[index] / sumAdaptability;
                    index++;                    
                }
                if (index < population.Count)
                    parents.Add( population[index] );
                else
                    parents.Add( population[random.Next(population.Count)] );
            }

            return parents;
        }

        // Return children.
        private List<ulong> Crossing(List<ulong> parents)
        {
            var children = new List<ulong>();

            int index = 0;
            while (children.Count < populationSize)
            {
                // If probabilityCrossover worked for population[index],
                // then get population[index] and some population[random] for MadeCross(population[index], population[random]).
                // Else skip population[index] at this time.
                if (random.NextDouble() <= probabilityCrossover)
                {
                    foreach (var child in MadeCross(population[index], population[random.Next(population.Count)]))
                    {
                        children.Add(child);
                    }
                }

                index++;
                if (index >= populationSize)
                    index = 0;
            }

            if (children.Count > populationSize)
                children.RemoveAt(children.Count - 1);
            return children;
        }

        // Made two children by crossing
        private List<ulong> MadeCross(ulong p1, ulong p2)
        {
            var children = new List<ulong>();

            // Index of highest bit for low part
            int crossingPoint = random.Next(numberGenesInChromosome - 1);

            ulong maskLow = 1;
            for (int i = 0; i < crossingPoint + 1; i++)
                maskLow <<= 1; // * 2
            maskLow -= 1; // get [1111111..] length of which = crossingPoint + 1

            ulong low1 = p1 & maskLow;
            ulong low2 = p2 & maskLow;

            ulong maskHigh = 1;
            for (int i = 0; i < numberGenesInChromosome - (crossingPoint + 1); i++)
                maskHigh <<= 1; // * 2
            maskHigh -= 1; // get [1111111..] length of which = numberGenesInChromosome - (crossingPoint + 1)
            maskHigh <<= crossingPoint + 1;

            ulong high1 = p1 & maskHigh;
            ulong high2 = p2 & maskHigh;

            children.Add(high1 | low2);
            children.Add(high2 | low1);

            return children;
        }

        // Return children after mutation (it's a new generation of population).
        private List<ulong> Mutation(List<ulong> children)
        {
            var mutantChildren = new List<ulong>();

            foreach (var item in children)
            {
                ulong child = item;
                ulong mask = 1;
                for (int i = 0; i < numberGenesInChromosome; i++)
                {
                    if (random.NextDouble() <= probabilityMutation)
                    {
                        child ^= mask;
                    }

                    mask <<= 1;
                }
                mutantChildren.Add(child);
            }

            return mutantChildren;
        }
    }
}
