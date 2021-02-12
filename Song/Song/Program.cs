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
            var rymeList = new List<AnimalRhyme>
            {
                AnimalRhyme.CreatePresentTenseRhyme("bird", "How absurd to"),
                AnimalRhyme.CreatePresentTenseRhyme("cat", "Fancy that to"),
                AnimalRhyme.CreatePresentTenseRhyme("dog", "What a hog, to"),
                AnimalRhyme.CreatePastTenseRhyme("cow", "I don't know how she")
            };
            var lyrics = new Lyrics(animalCollection, rymeList);

            Console.WriteLine(lyrics.Song);
        }
    }
}
