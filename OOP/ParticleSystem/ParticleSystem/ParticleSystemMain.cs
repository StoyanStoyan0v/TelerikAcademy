namespace ParticleSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    class ParticleSystemMain
    {
        const int SimulationRows = 40;
        const int SimulationCols = 100;

        static void Main(string[] args)
        {
            Console.WriteLine("Enter 1 for chaotic particles test, 2 for chicken particles test and 3 for particle repeller test:");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    ChaoticParticleTest();
                    break;
                case "2":
                    ChickenParticleTest();
                    break;
                case "3":
                    throw new NotImplementedException();
                default:
                    Console.WriteLine("Invalid input!");
                    break;
            }
        }

        // Test the ChickenParticle class through the ParcticleSystemMain class.
        private static void ChaoticParticleTest()
        {
            var renderer = new ConsoleRenderer(SimulationRows, SimulationCols);

            var particleOperator = new ChaoticParticleOperator();

            var particles = new List<Particle>()
            {
                new ChaoticParticle(new MatrixCoords(20, 20), new MatrixCoords(0, 0)),
                new ChaoticParticle(new MatrixCoords(20, 50), new MatrixCoords(0, 0))
            };

            var engine = new Engine(renderer, particleOperator, particles, 300);

            engine.Run();
        }

        // Test the ChaoticParticle through the ParticleSystemMain class.

        private static void ChickenParticleTest()
        {
            var renderer = new ConsoleRenderer(SimulationRows, SimulationCols);

            var particleOperator = new ChaoticParticleOperator();

            var particles = new List<Particle>()
            {
                new ChickenParticle(new MatrixCoords(10, 50), new MatrixCoords(0, 0))
            };

            var engine = new Engine(renderer, particleOperator, particles, 500);

            engine.Run();
        }
    }
}