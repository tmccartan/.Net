using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Factory
{
    public class FactoryExample
    {
        public void StartExample()
        {
            Factory controlFactory = new Version1Factory();
            Control control = controlFactory.makeControl();
            Console.WriteLine(control.name);
            controlFactory = new Version2Factory();
            control = controlFactory.makeControl();
            Console.WriteLine(control.name);
        }
    }
    public abstract class Control
    {
        public string name { get; set; }

        public Control()
        {

        }
    }
    public abstract class Factory
    {
        public Factory()
        {

        }
        public abstract Control makeControl();
    }
    public class TextboxV1:Control
    {
        public TextboxV1()
        {
            name = "Ima Version 1 TextBox";
        }
    }
    public class TextboxV2 : Control
    {
        public TextboxV2()
        {
            name = "Ima Version 2 TextBox -- so much better than Version 1";
        }
    }
    public class Version1Factory:Factory
    {
        public override Control makeControl()
        {
            return new TextboxV1();
        }
    }
    public class Version2Factory:Factory
    {
        public override Control makeControl()
        {
            return new TextboxV2();
        }
    }


}
