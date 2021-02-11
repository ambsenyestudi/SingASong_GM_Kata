using System.Collections.Generic;
using System.Linq;

namespace Song
{
    public class Lyrics
    {
        private List<string> animalCollection;
        private readonly List<string> sectionTemplateList;
        private readonly Dictionary<string, string> sectionDictionary;

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
            sectionTemplateList = new List<string>
            {
                "How absurd to swallow a {0}.\n",
                "Fancy that to swallow a {0}!\n",
                "What a hog, to swallow a {0}!\n",
                "I don't know how she swallowed a {0}!\n",              
            };

            sectionDictionary = animalCollection.Skip(2).Take(sectionTemplateList.Count)
                .Select((x, i) => new { index = i, animal = x })
                .ToDictionary(k => k.animal, v => sectionTemplateList[v.index]);

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
                return string.Format(sectionDictionary[animal], animal);
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
