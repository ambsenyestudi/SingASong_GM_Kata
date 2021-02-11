using System;
using System.Collections.Generic;

namespace Song
{
    class Program
    {
        static void Main(string[] args)
        {
            var animalCollection = new List<string>{
                "fly",
                "spider",
                "bird",
                "cat",
                "dog",
                "cow",
                "horse"
            };
            var lyrics = new Lyrics(animalCollection);

            Console.WriteLine(lyrics.Song);
        }
    }
}
