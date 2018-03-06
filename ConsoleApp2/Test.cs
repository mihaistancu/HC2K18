using GeneticSharp.Domain;
using GeneticSharp.Domain.Crossovers;
using GeneticSharp.Domain.Mutations;
using GeneticSharp.Domain.Populations;
using GeneticSharp.Domain.Selections;
using GeneticSharp.Domain.Terminations;
using System;

namespace ConsoleApp2
{
    class Test
    {
        public OutputData DoIt(InputData inputData)
        {
            var selection = new EliteSelection();
            var crossover = new ThreeParentCrossover(); ; ;//OnePointCrossover
            var mutation = new ReverseSequenceMutation();//DisplacementMutation ReverseSequenceMutation
            var fitness = new MyProblemFitness(inputData);
            var chromosome = new MyProblemChromosome(inputData.F, inputData.N);
            var population = new Population(100, 1000, chromosome);

            var ga = new GeneticAlgorithm(population, fitness, selection, crossover, mutation);
            ga.Termination = new FitnessStagnationTermination(10000);
            ga.Population.GenerationStrategy = new TrackingGenerationStrategy();
            Console.WriteLine("GA running...");

            double currentFitness = 0;
            ga.GenerationRan += delegate(object obj, EventArgs eventArgs)
            {
                var outputx = new MyProblemFitness(inputData);
                var re = outputx.Evaluate(((GeneticAlgorithm)obj).BestChromosome);
                if(re != currentFitness)
                {
                    currentFitness = re;
                    Console.WriteLine("Fitness..." + re);
                }
            };

            ga.Start();
            
            var x = ga.BestChromosome;
            var output = new MyProblemFitness(inputData);
            var res = output.Evaluate(ga.BestChromosome);
            Console.WriteLine("Done...fitness..." + res);
            return output.OutputData;
        }
    }
}
