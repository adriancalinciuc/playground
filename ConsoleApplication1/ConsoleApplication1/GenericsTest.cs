using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public delegate void testDelegate<T>(T testObj,int i);

    public class GenericsTest<T> where T : MyGenericType
    {

        testDelegate<MyGenericType> test = (s,v) =>
          {
              s.Hello(v);
          };

        public GenericsTest(T testObject)
        {

            //  testObject.Hello();
            test(testObject,8);

        }

    }
    public class MyGenericType
    {
        public void Hello()
        {
            Console.WriteLine(this.ToString());

        }
        public void Hello(int p)
        {
            Console.WriteLine(this.ToString() + ++p);

        }

    }


}
