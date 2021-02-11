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
            var rymeDictionary = new Dictionary<string, string>
            {
                ["bird"] = "How absurd to",
                ["cat"] = "Fancy that to",
                ["dog"] = "What a hog, to",
                ["cow"] = "I don't know how she"
            };
            var lyrics = new Lyrics(animalCollection, rymeDictionary);

            Console.WriteLine(lyrics.Song);
        }
    }
}
