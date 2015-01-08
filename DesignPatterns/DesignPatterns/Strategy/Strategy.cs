using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Strategy
{
    public abstract class Strategy
    {
        public abstract void RunTask();
    }
    public class RandomNumberStrategy : Strategy
    {
        public override void RunTask()
        {
            Random rnd = new Random();
             for(int i = 0; i<10; i++)
            {
                Console.WriteLine(rnd.Next(1,10));
            }
        }
    }
    public class LinearNumberStrategy : Strategy
    {
        public override void RunTask()
        {
            for(int i = 0; i<10; i++)
            {
                Console.WriteLine(i);
            }
        }
    }

    public class StrategyExample
    {
        public StrategyExample()
        {
            
        }

        public Strategy SelectedStrategy { get; set; }

        public void StartExample()
        {            
            SelectedStrategy.RunTask();
        }
    }
}
