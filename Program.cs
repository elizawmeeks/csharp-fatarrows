using System;
using System.Collections.Generic;

namespace expression_members
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hooray Eliza! You rock!");

            Bug Eliza = new Bug("Eliza", "praying mantis", new List<string>{"Kyle", "Smingleigh", "Caelyn", "Loren"}, new List<string>{"Ruby", "Sherman"});

            Bug Smingleigh = new Bug("Lord Custard Smingleigh OBE(redacted)", "teh worse bug", new List<string>{"Lady Smingleigh"}, new List<string>{"all the internets", "Rather Squiggly"});
            string sfm = Smingleigh.FormalName;
            string efm = Eliza.FormalName;
            Console.WriteLine("Formal Names: " + sfm + " and also " + Eliza.FormalName);

            string ElizaPreyList = Eliza.PreyList();
            string SmingleighPreyList = Smingleigh.PreyList();
            Console.WriteLine($@"Prey Lists:
{SmingleighPreyList}
{ElizaPreyList}");

        }
    }
    public class Bug
    {
        /*
            You can declare a typed public property, make it read-only,
            and initialize it with a default value all on the same
            line of code in C#. Readonly properties can be set in the
            class' constructors, but not by external code.
        */
        public string Name { get; } = "";
        public string Species { get; } = "";
        public ICollection<string> Predators { get; } = new List<string>();
        public ICollection<string> Prey { get; } = new List<string>();

        // Convert this readonly property to an expression member
        public string FormalName => $"{this.Name} the {this.Species}";

        // Class constructor
        public Bug(string name, string species, List<string> predators, List<string> prey)
        {
            this.Name = name;
            this.Species = species;
            this.Predators = predators;
            this.Prey = prey;
        }

        // Convert this method to an expression member
        public string PreyList() => string.Join(",", this.Prey);

        // Convert this method to an expression member
        public string PredatorList() => string.Join(",", this.Predators);

        // Convert this to expression method (hint: use a C# ternary)
        public string Eat(string food) => this.Prey.Contains(food) ? "{this.Name} ate the {food}." : "{this.Name} is still hungry.";

    }
}
