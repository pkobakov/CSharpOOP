using System;

namespace Demo2
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 5;
            int[] nums = new int[] {1,2 };

            Console.WriteLine(Calc(a, nums)); 
        }

        public static int Calc(int a, params int[] nums)
        {
            int result = a + nums[0];
            return result;
        }
    }
}
