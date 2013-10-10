using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = new GenericsTest<MyGenericType>(new MyGenericType());
            Console.ReadKey();

            //  var orderHelper = new OrderCollection(new Generator().CreateObjectList().OrderBy(p => p.Order).ToList());
            var orderHelper = new Generator().CreateObjectList().OrderBy(p => p.Order).ToList();
            Console.WriteLine("---------Original List--------------");
            orderHelper.PrintList();


            orderHelper.OrderOnIndex(Move.First, 19);
            Console.WriteLine("---------List Elements are 'moved' Move.First, 19--------------");
            orderHelper.PrintList();
            orderHelper.OrderOnIndex(Move.First, 19);
            Console.WriteLine("---------List Elements are 'moved' Move.First, 19--------------");
            orderHelper.PrintList();
            orderHelper.OrderOnIndex(Move.First, 19);
            Console.WriteLine("---------List Elements are 'moved' Move.First, 19--------------");
            orderHelper.PrintList();
            orderHelper.OrderOnIndex(Move.First, 19);
            Console.WriteLine("---------List Elements are 'moved' Move.First, 19--------------");
            orderHelper.PrintList();
            orderHelper.OrderOnIndex(Move.Last, 1);
            Console.WriteLine("---------List Elements are 'moved' Move.Last, 1--------------");
            orderHelper.PrintList();
            orderHelper.OrderOnIndex(Move.TenDown, 4);
            Console.WriteLine("---------List Elements are 'moved' Move.TenDown, 4--------------");
            orderHelper.PrintList();
            orderHelper.OrderOnIndex(Move.TenUp, 4);
            Console.WriteLine("---------List Elements are 'moved' Move.TenUp, 4 --------------");
            orderHelper.PrintList();
            orderHelper.OrderOnIndex(Move.Last, 4);
            Console.WriteLine("---------List Elements are 'moved' Move.Last, 4--------------");
            orderHelper.PrintList();
            orderHelper.OrderOnIndex(Move.TenUp, 7);
            Console.WriteLine("---------List Elements are 'moved' Move.TenUp, 7--------------");
            orderHelper.PrintList();


            orderHelper.OrderOnData();
            Console.WriteLine("-------Elements are reordered----------------");

            orderHelper.PrintList();

        }


        private class Generator
        {
            public IEnumerable<CustomData> CreateObjectList()
            {
                IList<CustomData> list = new List<CustomData>();
                for (int i = 0; i < 20; i++)
                {

                    CustomData obj = new CustomData { Order = i, SomeData = "xxx" + i };
                    list.Add(obj);
                }

                return list;
            }

        }



    }
}
