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
            var joinedSections = GetStart();
            var composingAnimals = animalCollection
                .Take(animalCollection.Count - 1)
                .ToList();
            for (int i = 1; i < composingAnimals.Count; i++)
            {
                var processingAnimalList = composingAnimals.GetRange(0, i + 1);
                var animal = composingAnimals[i];
                var currSection = Section.Create(
                    new SectionOpening(animal),
                     MiddleSection(animal, processingAnimalList),
                     new SectionEnding(animalCollection.First())
                    );
                joinedSections += "\n" + currSection.Value;
            }
            joinedSections += "\n" + GetEnding();
            return joinedSections;
        }
        private string MiddleSection(string animal, List<string> animalCollection) =>
            GetMainSectionTheme(animal) + new AnimalReviewSection(animalCollection).ToString();
        /*
    {

        if(animalCollection.Count == 2)
        {
            return GetMainSectionTheme(animal) + new AnimalReviewSection(animalCollection).ToString();
        }
        return GetMainSectionTheme(animal) + GetSwallowedAllPrecedingAnimals(animal);
    }
        */
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
        public string GetStart() {
            var firstAnimal = animalCollection.First();
            return Section.Create(
                new SectionOpening(firstAnimal, "."),
                new SectionEnding(firstAnimal))
                .Value;
        }
        public string GetSwallowedAllPrecedingAnimals(string animal)
        {
            var animalIndex = animalCollection.IndexOf(animal);
            var result = "";
            while (animalIndex > 0)
            {
                result += animalIndex == 1
                    ? GetSwallowedAnimalToCatchPreviousAnimal(animalCollection[animalIndex], "")
                    : GetSwallowedAnimalToCatchPreviousAnimal(animalCollection[animalIndex]);
                animalIndex--;
            }
            return result;
        }
        public string GetSwallowedAnimalToCatchPreviousAnimal(string animal, string lineEnding="\n")
        {
            var previousAnimal = GetPreviousAnimal(animal);
            var separator = GetSeparatorFromAnimal(animal);
            return $"She swallowed the {animal} to catch the {previousAnimal}{separator}{lineEnding}";
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
