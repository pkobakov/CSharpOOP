using System;



namespace P01.Stream_Progress
{
    public class Program
    {
        static void Main()
        {
            Music myalbum = new Music("Metallica", "Black album", 97, 100);
            File myFile = new File("Die Hard", 180, 4050);

            StreamProgressInfo first = new StreamProgressInfo(myalbum);
            StreamProgressInfo second = new StreamProgressInfo(myFile);

            Console.WriteLine(first.CalculateCurrentPercent());
            Console.WriteLine(second.CalculateCurrentPercent());
        }
    }
}
