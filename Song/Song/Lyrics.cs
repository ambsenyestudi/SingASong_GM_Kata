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
                     GetMainSectionTheme(animal),
                     new AnimalReviewSection(processingAnimalList),
                     new SectionEnding(animalCollection.First())
                    );
                joinedSections += "\n" + currSection.Value;
            }
            joinedSections += "\n" + new LyricsEnding(animalCollection.Last()).Value;
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
        public string GetStart() {
            var firstAnimal = animalCollection.First();
            return Section.Create(
                new SectionOpening(firstAnimal, "."),
                new SectionEnding(firstAnimal))
                .Value;
        }        

        public int GetPreviousAnimalIndex(string animal) =>
            animalCollection.IndexOf(animal) - 1;


    }
}
