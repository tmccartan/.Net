using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Decorator
{
    public class DecoratorExample
    {
        public DecoratorExample()
        {

        }
        public void StartExample()
        {
            Drink terryDrink = new LowFatMilkDecorator(new Coffee());
            terryDrink.MakeDrink();
            Console.WriteLine();
            Drink joesDrink = new PlainMilkDecorator(new SugarDecorator(new DecaffCoffee()));
            joesDrink.MakeDrink();
        }
        
    }
    public abstract class Drink
    {
        public abstract void MakeDrink();
    }
    public abstract class DrinkDecorator:Drink
    {
        public Drink container { get; set; }

        public DrinkDecorator(Drink currentDrink)
        {
            container = currentDrink;
        }
        public override void MakeDrink()
        {
            if(container != null)
            {
                container.MakeDrink();
            }
        }
    }

    public class PlainMilkDecorator:DrinkDecorator
    {
        public PlainMilkDecorator(Drink currentDrink)
            :base(currentDrink)
        { 

        }
        public override void MakeDrink()
        {
            container.MakeDrink();
            Console.Write("with Plain Milk ");
        }
    }
    public class LowFatMilkDecorator : DrinkDecorator
    {
        public LowFatMilkDecorator(Drink currentDrink)
            :base(currentDrink)
        { 

        }
        public override void MakeDrink()
        {
            container.MakeDrink();
            Console.Write("with Low fat Milk ");
        }
    }
    public class SugarDecorator:DrinkDecorator
    {
        public SugarDecorator(Drink currentDrink)
            :base(currentDrink)
        {

        }
        public override void MakeDrink()
        {
            container.MakeDrink();
            Console.Write("with Sugar ");
        }
    }

    public class DecaffCoffee:Drink
    {
        public override void MakeDrink()
        {
            Console.Write("Decaff coffee ");
        }
    }
    public class Coffee:Drink
    {
        public override void MakeDrink()
        {
            Console.Write("Nice coffee ");
        }
    }
}
