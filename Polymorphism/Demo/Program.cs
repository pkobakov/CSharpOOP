using System;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = new int[] { 1,2,3};

            var enumerator = array.GetEnumerator();

            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }
        }
    }
}
