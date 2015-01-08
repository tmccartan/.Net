using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.AbstractFactory
{
    public class AbstractFactoryExample
    {
        public AbstractFactoryExample()
        {
        }
        public void StartExample()
        {
            ContinentFactory africa = new AfricaContinent();
            FoodChain world = new FoodChain(africa);
            world.StartFoodChain();

            // Create and run the American animal world
            ContinentFactory america = new AmericaCContinent();
            world = new FoodChain(america);
            world.StartFoodChain();

            // Wait for user input
            Console.ReadKey();
        }

        public class FoodChain
        {
            Herbivore _herby;
            Carnivore _carny;

            public FoodChain(ContinentFactory factory)
            {
                _herby = factory.createHerbAnimal();
                _carny = factory.createCarnAnimal();
            }
            public void StartFoodChain()
            {
                _herby.RunFrom(_carny);
                _carny.Eat(_herby);
            }
        }


        public abstract class ContinentFactory
        {
            public abstract Carnivore createCarnAnimal();
            public abstract Herbivore createHerbAnimal();
        }

        public class AfricaContinent : ContinentFactory
        {
            public override Carnivore createCarnAnimal()
            {
                return new Lion("Simba");
            }
            public override Herbivore createHerbAnimal()
            {
                return new Springbok("Skippy");
            }
        }
        public class AmericaCContinent : ContinentFactory
        {
            public override Carnivore createCarnAnimal()
            {
                return new Wolf("White Fang");
            }
            public override Herbivore createHerbAnimal()
            {
                return new Bison("Bertha");
            }
        }

        public abstract class Carnivore
        {
            public string Name { get; set; }
            public void Eat(Herbivore herbie)
            {
                Console.WriteLine(Name + " eats " + herbie.Name);
            }
        }
        public abstract class Herbivore
        {
            public string Name { get; set; }
            public void RunFrom(Carnivore carny)
            {
                Console.WriteLine(Name + " runs from " + carny.Name);
            }
        }

        public class Lion : Carnivore
        {
            public Lion(string Name)
            {
                this.Name = Name;
            }
        }
        public class Wolf : Carnivore
        {
            public Wolf(string Name)
            {
                this.Name = Name;
            }
        }
        public class Springbok : Herbivore
        {
            public Springbok(string Name)
            {
                this.Name = Name;
            }
        }
        public class Bison : Herbivore
        {
            public Bison(string Name)
            {
                this.Name = Name;
            }
        }

    }

}
