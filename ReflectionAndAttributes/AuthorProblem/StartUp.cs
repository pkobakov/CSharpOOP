using System;

namespace AuthorProblem
{
    [Author("Vlado")]
    public class StartUp
    {
        [Author ("Dimitar")]
        static void Main(string[] args)
        {
            Tracker tracker = new Tracker();
            tracker.PrintMethodsByAuthor();

          

        }
    }
}
