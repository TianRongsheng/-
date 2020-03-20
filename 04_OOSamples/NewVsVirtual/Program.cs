using System;

namespace NewVsVirtual
{
    public class BaseClass
    {
        public virtual void Foo() { Console.WriteLine("BaseClass.Foo"); }
    }

    public class Overrider : BaseClass
    {
        public override void Foo() { Console.WriteLine("Overrider.Foo"); }
    }

    public class Hider : BaseClass
    {
        public new void Foo() { Console.WriteLine("Hider.Foo"); }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Overrider o = new Overrider();
            BaseClass b1 = o;
            o.Foo();                           // Overrider.Foo
            b1.Foo();                          // Overrider.Foo

            Hider h = new Hider();
            BaseClass b2 = h;
            h.Foo();                           // Hider.Foo
            b2.Foo();                          // BaseClass.Foo
        }
    }
}
