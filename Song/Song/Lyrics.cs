using System.Collections.Generic;
using System.Linq;

namespace Song
{
    public class Lyrics
    {
        private List<string> animalCollection;
        private readonly List<string> sectionList;

        public string Song { get; }
        public Lyrics()
        {
            animalCollection = new List<string>{
                "fly",
                "spider",
                "bird",
                "cat",
                "dog",
                "cow",
                "horse"
            };
            sectionList = new List<string>
            {
                "That wriggled and wiggled and tickled inside her.\n",
                "How absurd to swallow a bird.\n",
                "Fancy that to swallow a cat!\n",
                "What a hog, to swallow a dog!\n",
                "I don't know how she swallowed a cow!\n",              
            };

            Song = ComposeSong();
                
        }
        public string ComposeSong()
        {
            var joinedSections = GetStart();
            for (int i = 0; i < sectionList.Count; i++)
            {
                var animalIndex = i + 1;
                var animal = animalCollection[animalIndex];
                var currSection = BuildThereWasAnOldLadyWhoSwallowed(animal) +
                    sectionList[i] + GetSwallowedAllPrecedingAnimals(animal) +
                    GetDontKnowWhySheSwallowed(animalCollection.First());
                joinedSections += currSection;
            }
            joinedSections += GetEnding();
            return joinedSections;
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
