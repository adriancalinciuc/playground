using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication.FactoryTest
{
    class Dummy
    {
        public Dummy()
        {
            Console.Out.WriteLine("this is the dummy class");
        }
    }


    class DummyWithConstructor
    {
        public DummyWithConstructor(int a, string b, bool c)
        {
            Console.Out.WriteLine("this is the DummyWithConstructor class and int//string//bool params");
        }

        DummyWithConstructor()
        {
            Console.Out.WriteLine("this is the DummyWithConstructor class and no params");
        
        }
    }
}
