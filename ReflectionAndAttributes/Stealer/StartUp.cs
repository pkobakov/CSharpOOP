using System;

namespace Stealer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Spy spy = new Spy();

            string result = spy.StealFieldInfo("Stealer.Hacker", "username", "password");
            Console.WriteLine(result);

            string result2 = spy.AnalyzeAcessModifiers("Stealer.Hacker");
            Console.WriteLine(result2);

            string result3 = spy.RevealPrivateMethods("Stealer.Hacker");
            Console.WriteLine(result3);

            string result4 = spy.CollectGettersAndSetters("Stealer.Hacker");
            Console.WriteLine(result4);

        }
    }
}
