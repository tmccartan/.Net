using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Composite
{
    public class CompositeExample
    {
        public CompositeExample()
        {

        }
        public void StartExample()
        {
            Component mainCanvas = new Canvas();
            mainCanvas.Add(new TextBox());
            mainCanvas.Add(new CheckBox());
            Component subCanvas = new Canvas();
            subCanvas.Add(new CheckBox());
            mainCanvas.Add(subCanvas);
            mainCanvas.Display(1);          
        }        
    }
    public abstract class Component
    {       
        public abstract void Display(int indent);

        public virtual void Add(Component comp)
        {
            throw new NotImplementedException();
        }
     
        public virtual void Remove(Component comp)
        {
            throw new NotImplementedException();
        }
      
        
    }
    public abstract class Composite:Component
    {
        public List<Component> children;
        public Composite()
        {
            children = new List<Component>();
        }
        public override void Add(Component comp)
        {
            children.Add(comp);
        }
        public override void Remove(Component comp)
        {
            children.Remove(comp);
        }
        public override void Display(int indent)
        {
            foreach(Component comp in children)
            {
                Console.Write(new String('-',indent));
                comp.Display(indent +1);
            }
        }

    }
    public class TextBox:Component
    {
        public TextBox()
        {

        }
        public override void Display(int indent)
        {
            Console.WriteLine(new String('-',indent)+"TextBox");
        }

    }
    public class CheckBox : Component
    {
        public CheckBox()
        {

        }
        public override void Display(int indent)
        {
            Console.WriteLine(new String('-', indent) + "CheckBox");
        }

    }
    public class Canvas:Composite
    {
        public Canvas()
            :base()
        {

        }
        public override void Display(int indent)
        {
            Console.WriteLine(new String('-', indent) + "Canvas");
            base.Display(indent);
        }

    }
}
