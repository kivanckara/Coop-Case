using System;

namespace CoopCase
{
    internal static class Program
    {
        private static void Main()
        {
            Console.WriteLine($"Welcome to the {new Coop.Entity.Animal().Name} COOP Simulation!\nPlease enter simulation cycles (Monthly): ");

            int cycles;
            while (!int.TryParse(Console.ReadLine(), out cycles))
            {
                Console.WriteLine("Cycles must be numeric. Please enter again: ");
            }

            new Coop.Business.Coop().Simulate(cycles);
            Console.ReadLine();
        }
    }
}