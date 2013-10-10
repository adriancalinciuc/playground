using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{

    public enum Move
    {
        First,
        Last,
        TenUp,
        TenDown,
        Up,
        Down
    }

    internal static class SequenceListExtension
    {

        public static void OrderOnIndex(this IList<CustomData> list, Move where, int oldIndex)
        {
            if (oldIndex < 0 || oldIndex > list.Count())
                return;

            int newIndex;
            int maxIndex = list.Count() - 1;
            switch (where)
            {
                case Move.First:
                    newIndex = 0;
                    break;
                case Move.Last:
                    newIndex = maxIndex;
                    break;
                case Move.TenUp:
                    newIndex = (oldIndex - 10);
                    break;
                case Move.TenDown:
                    newIndex = oldIndex + 10;
                    break;
                case Move.Up:
                    newIndex = oldIndex - 1;
                    break;
                case Move.Down:
                    newIndex = oldIndex + 1;
                    break;
                default:
                    newIndex = oldIndex;
                    break;
            }

            if (newIndex < 0)
                newIndex = 0;
            if (newIndex > maxIndex)
                newIndex = maxIndex;

            var data = list.ElementAt(oldIndex);
            list.RemoveAt(oldIndex);
            list.Insert(newIndex, data);
        }

        public static void OrderOnData(this IList<CustomData> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] != null)
                    list[i].Order = i;
            }
        }

        public static void PrintList(this IList<CustomData> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine("Index {0} / DataIndex {1}", list.IndexOf(item), item.Order);
            }
            Console.ReadKey();

        }
    
    
    }

    public class OrderCollection
    {
        public  IList<CustomData> _list { get; private set; }

        public OrderCollection(List<CustomData> list)
        {
            _list = list;
        }

        public void OrderOnIndex(Move where, int oldIndex)
        {
            if (oldIndex < 0 || oldIndex > _list.Count)
                return;

            int newIndex;
            int maxIndex = _list.Count -1;
            switch (where)
            {
                case Move.First:
                    newIndex = 0;
                    break;
                case Move.Last:
                    newIndex = maxIndex;
                    break;
                case Move.TenUp:
                    newIndex = (oldIndex - 10);
                    break;
                case Move.TenDown:
                    newIndex = oldIndex + 10;
                    break;
                case Move.Up:
                    newIndex = oldIndex - 1;
                    break;
                case Move.Down:
                    newIndex = oldIndex + 1;
                    break;
                default:
                    newIndex = oldIndex;
                    break;
            }

            if (newIndex < 0)
                newIndex = 0;
            if (newIndex > maxIndex)
                newIndex = maxIndex;

            var data = _list.ElementAt(oldIndex);
            _list.RemoveAt(oldIndex);
            
            
            _list.Insert(newIndex, data);
        }

        public void OrderOnData()
        {

            for (int i = 0; i < _list.Count; i++)
            {
                if (_list[i] != null)
                    _list[i].Order = i;
            }
        }

        public void PrintList()
        {
            foreach (var item in _list)
            {
                Console.WriteLine("Index {0} / DataIndex {1}", _list.IndexOf(item), item.Order);
            }
            Console.ReadKey();
        
        }
    }
}
