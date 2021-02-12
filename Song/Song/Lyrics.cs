using System;
using System.Collections.Generic;
using System.Linq;

namespace Song
{
    public class Lyrics
    {
        private const int ANIMAL_COUNT = 7;
        private List<string> animalCollection;
        private readonly List<AnimalRhyme> animalRymeList;

        public string Song { get; }
        public Lyrics(List<string> animalCollection, List<AnimalRhyme> animalRymeList)
        {
            if(animalCollection.Count != ANIMAL_COUNT)
            {
                throw new ArgumentException($"{nameof(animalCollection)} must be {ANIMAL_COUNT} items long");
            }
            this.animalCollection = animalCollection;
            this.animalRymeList = animalRymeList;
            Song = ComposeSong();
                
        }
        
        public string ComposeSong()
        {
            var joinedSections = GetStart()+"\n";
            for (int i = 0; i < animalCollection.Count-2; i++)
            {
                var animalIndex = i + 1;
                var animal = animalCollection[animalIndex];
                var currSection =
                    BuildThereWasAnOldLadyWhoSwallowed(animal) +
                    GetMainSectionTheme(animal) +
                    GetSwallowedAllPrecedingAnimals(animal) +
                    GetDontKnowWhySheSwallowed(animalCollection.First());
                joinedSections += currSection;
            }
            joinedSections += GetEnding();
            return joinedSections;
        }
        public string GetMainSectionTheme(string animal)
        {
            
            if(GetPreviousAnimalIndex(animal) != 0)
            {
                var currRyme = animalRymeList.First(x => x.Animal == animal);
                var separator = currRyme.Equals(animalRymeList.First())
                    ? "."
                    : "!";
                
                return $"{currRyme.Value}{separator}\n";
            }
            return "That wriggled and wiggled and tickled inside her.\n";
        }

        public string BuildThereWasAnOldLadyWhoSwallowed(string animal) => 
            new SectionOpening(animal).Value + "\n";
        public string GetStart() =>
            ComposeSection(animalCollection.First(), ".");
            /*
            new SectionOpening(animalCollection.First(), ".").Value + "\n" +
            GetDontKnowWhySheSwallowed(animalCollection.First());
            */

        public string ComposeSection(string animal, string separator = ";")
        {
            var opening = new SectionOpening(animal, separator);
            var ending = new SectionEnding(animal);
            return ComposeSentences(opening.Value, ending.Value);
        }

        private string ComposeSentences(params string[] sentences) =>
            string.Join("\n", sentences);

        public string GetDontKnowWhySheSwallowed(string animal) => $"I don't know why she swallowed a {animal} - perhaps she'll die!\n";
        public string GetSwallowedAllPrecedingAnimals(string animal)
        {
            var animalIndex = animalCollection.IndexOf(animal);
            var result = "";
            while (animalIndex > 0)
            {
                result += GetSwallowedAnimalToCatchPreviousAnimal(animalCollection[animalIndex]);
                animalIndex--;
            }
            return result;
        }
        public string GetSwallowedAnimalToCatchPreviousAnimal(string animal)
        {
            var previousAnimal = GetPreviousAnimal(animal);
            var separator = GetSeparatorFromAnimal(animal);
            return $"She swallowed the {animal} to catch the {previousAnimal}{separator}\n";
        }
        public string GetSwallowedTheSpiderToCatchTheFly() => 
            GetSwallowedAnimalToCatchPreviousAnimal(animalCollection[1]);

        public string GetEnding() => new LyricsEnding(animalCollection.Last()).Value;

        public string GetPreviousAnimal(string animal) =>
            animalCollection[GetPreviousAnimalIndex(animal)];

        public int GetPreviousAnimalIndex(string animal) =>
            animalCollection.IndexOf(animal) - 1;

        public string GetSeparatorFromAnimal(string animal) =>
            GetPreviousAnimalIndex(animal) == 0
                ? ";"
                : ",";

    }
}
