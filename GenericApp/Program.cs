using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericApp
{
    class SimpleGeneric<T>
    {
        private T[] values;                 // T type의 배열 (values라는 변수)
        private int index;

        public SimpleGeneric(int len)
        {
            values = new T[len];
            index = 0;
        }
        public void Add(params T[] args)
        {
            foreach (T item in args)
            {
                values[index++] = item;
            }
        }
        public void print ()
        {
            foreach (T item in values)
            {
                Console.Write(item + ", ");

            }
            Console.WriteLine();

        }
	
    }
    class Program
    {
        static void Main(string[] args)
        {
            SimpleGeneric<Int32> gintegers = new SimpleGeneric<int>(10);
            SimpleGeneric<double> gDoubles = new SimpleGeneric<double>(10);

            gintegers.Add(1, 2);
            gintegers.Add(1, 2, 3, 4, 5, 6, 7);
            gintegers.Add(10);

            gDoubles.Add(10.0, 12.4, 37.5);

            gintegers.print();
            gDoubles.print();




        }
    }
}
