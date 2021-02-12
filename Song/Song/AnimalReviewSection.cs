using System.Collections.Generic;
using System.Linq;

namespace Song
{
    public class AnimalReviewSection
    {
        private readonly List<string> animalCollection;

        public AnimalReviewSection(List<string> animalCollection)
        {
            this.animalCollection = animalCollection;
        }
        public override string ToString()
        {
            return GetSwallowedAnimalToCatchPreviousAnimal(animalCollection.Last(),"");
        }
        private string GetSwallowedAnimalToCatchPreviousAnimal(string animal, string lineEnding = "\n")
        {
            var previousAnimal = GetPreviousAnimal(animal);
            var separator = GetSeparatorFromAnimal(animal);
            return $"She swallowed the {animal} to catch the {previousAnimal}{separator}{lineEnding}";
        }
        private string GetPreviousAnimal(string animal) =>
            animalCollection[GetPreviousAnimalIndex(animal)];

        private int GetPreviousAnimalIndex(string animal) =>
            animalCollection.IndexOf(animal) - 1;

        private string GetSeparatorFromAnimal(string animal) =>
            GetPreviousAnimalIndex(animal) == 0
                ? ";"
                : ",";
    }
}
