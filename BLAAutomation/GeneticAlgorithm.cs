using System;
using System.Collections.Generic;
using System.Linq;

namespace BLAAutomation
{
    public class Individual
    {
        public int[] Genes { get; set; }
        public double Fitness { get; set; }

        public Individual(int length)
        {
            Genes = new int[length];
        }
    }

    public class GeneticAlgorithm
    {
        private int _populationSize;
        private int _generations;
        private double _mutationRate;
        private double _crossoverRate;
        private int _geneLength;
        private List<Individual> _population;
        private Random _random;

        public GeneticAlgorithm(int populationSize, int generations, double mutationRate, double crossoverRate, int geneLength)
        {
            _populationSize = populationSize;
            _generations = generations;
            _mutationRate = mutationRate;
            _crossoverRate = crossoverRate;
            _geneLength = geneLength;
            _population = new List<Individual>();
            _random = new Random();
        }

        public void InitializePopulation()
        {
            for (int i = 0; i < _populationSize; i++)
            {
                Individual individual = new Individual(_geneLength);
                for (int j = 0; j < _geneLength; j++)
                {
                    individual.Genes[j] = _random.Next(0, 2); // Генерация генов 0 или 1
                }
                _population.Add(individual);
            }
        }

        public void EvaluateFitness()
        {
            foreach (var individual in _population)
            {
                individual.Fitness = CalculateFitness(individual);
            }
        }

        private double CalculateFitness(Individual individual)
        {
            // Пример расчета приспособленности (количество единиц в генах)
            return individual.Genes.Count(g => g == 1);
        }

        public void Selection()
        {
            // Пример отбора с использованием рулетки
            List<Individual> newPopulation = new List<Individual>();
            double totalFitness = _population.Sum(ind => ind.Fitness);
            for (int i = 0; i < _populationSize; i++)
            {
                double randomValue = _random.NextDouble() * totalFitness;
                double cumulativeFitness = 0.0;
                foreach (var individual in _population)
                {
                    cumulativeFitness += individual.Fitness;
                    if (cumulativeFitness >= randomValue)
                    {
                        newPopulation.Add(individual);
                        break;
                    }
                }
            }
            _population = newPopulation;
        }

        public void Crossover()
        {
            // Пример одноточечного скрещивания
            for (int i = 0; i < _populationSize; i += 2)
            {
                if (_random.NextDouble() <= _crossoverRate)
                {
                    int crossoverPoint = _random.Next(1, _geneLength - 1);
                    Individual parent1 = _population[i];
                    Individual parent2 = _population[i + 1];
                    for (int j = crossoverPoint; j < _geneLength; j++)
                    {
                        int temp = parent1.Genes[j];
                        parent1.Genes[j] = parent2.Genes[j];
                        parent2.Genes[j] = temp;
                    }
                }
            }
        }

        public void Mutate()
        {
            foreach (var individual in _population)
            {
                for (int i = 0; i < _geneLength; i++)
                {
                    if (_random.NextDouble() <= _mutationRate)
                    {
                        individual.Genes[i] = (individual.Genes[i] == 0) ? 1 : 0;
                    }
                }
            }
        }

        public void Run()
        {
            InitializePopulation();
            for (int generation = 0; generation < _generations; generation++)
            {
                EvaluateFitness();
                Selection();
                Crossover();
                Mutate();
            }
            EvaluateFitness();
        }

        public Individual GetBestIndividual()
        {
            return _population.OrderByDescending(ind => ind.Fitness).FirstOrDefault();
        }
    }
}
