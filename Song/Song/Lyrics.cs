using System;
using System.Collections.Generic;
using System.Linq;

namespace Song
{
    public class Lyrics
    {
        private const int ANIMAL_COUNT = 7;
        private List<string> animalCollection;
        private readonly Dictionary<string, string> animalRymesDictionary;

        public string Song { get; }
        public Lyrics(List<string> animalCollection, Dictionary<string, string> animalRymesDictionary)
        {
            if(animalCollection.Count != ANIMAL_COUNT)
            {
                throw new ArgumentException($"{nameof(animalCollection)} must be {ANIMAL_COUNT} items long");
            }
            this.animalCollection = animalCollection;
            this.animalRymesDictionary = animalRymesDictionary;
            Song = ComposeSong();
                
        }
        
        public string ComposeSong()
        {
            var joinedSections = GetStart();
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
                var separator = animal == animalRymesDictionary.Keys.First()
                    ? "."
                    : "!";
                var verb = animal == animalRymesDictionary.Keys.Last()
                    ? "swallowed"
                    : "swallow";
                return $"{animalRymesDictionary[animal]} {verb} a {animal}{separator}\n";
            }
            return "That wriggled and wiggled and tickled inside her.\n";
        }
        public string BuildThereWasAnOldLadyWhoSwallowed(string animal) =>
            $"There was an old lady who swallowed a {animal};\n";
        public string GetStart() => $"There was an old lady who swallowed a {animalCollection.First()}.\n" +
            GetDontKnowWhySheSwallowed(animalCollection.First());

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

        public string GetEnding() => $"There was an old lady who swallowed a {animalCollection.Last()}...\n" +
            "...She's dead, of course!";

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
