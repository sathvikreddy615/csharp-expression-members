using System;
using System.Collections.Generic;

namespace expression_members
{
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

        // Convert this readonly property to an expression member ---->

        // public string FormalName
        // {
        //     get
        //     {
        //         return $"{this.Name} the {this.Species}";
        //     }
        // }

        public string FormalName => $"{this.Name} the {this.Species}";

        // Class constructor
        public Bug(string name, string species, List<string> predators, List<string> prey)
        {
            this.Name = name;
            this.Species = species;
            this.Predators = predators;
            this.Prey = prey;
        }

        // Convert this method to an expression member ----->

        // {
        //     var commaDelimitedPrey = string.Join(",", this.Prey);
        //     return commaDelimitedPrey;
        // }
        public string PreyList() => string.Join(",", this.Prey);
        

        // Convert this method to an expression member ----->

        // {
        //     var commaDelimitedPredators = string.Join(",", this.Predators);
        //     return commaDelimitedPredators;
        // }
        public string PredatorList() => string.Join(",", this.Predators);
        
        // Convert this to expression method (hint: use a C# ternary) ---->

         // if (this.Prey.Contains(food))
            // {
            //     return $"{this.Name} ate the {food}.";
            // }
            // else
            // {
            //     return $"{this.Name} is still hungry.";
            // }
        public string Eat(string food) => this.Prey.Contains(food) ? $"{this.Name} ate the {food}." : $"{this.Name} is still hungry.";
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<string> ButterflyPrey = new List<string>{"flowers", "plants"};
            List<string> ButterflyPredators = new List<string>{"wasps", "birds", "frogs"}; 

            Bug Butterfly = new Bug("Butterfly", "Monarch", ButterflyPrey, ButterflyPredators);

            Console.WriteLine(Butterfly.PreyList());
            Console.WriteLine(Butterfly.PredatorList());
            Console.WriteLine(Butterfly.Eat("wasps"));

        }
    }
}
