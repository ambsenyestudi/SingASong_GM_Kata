using System.Collections.Generic;
using System.Linq;

namespace Song.Sections
{
    internal class AnimalReviewSection
    {
        private readonly List<string> animalCollection;

        public AnimalReviewSection(List<string> animalCollection)
        {
            this.animalCollection = animalCollection;
        }
        public override string ToString()
        {
            var result = string.Empty;

            var count = animalCollection.Count - 1;
            var isPreciding = animalCollection.Count > 1;

            while (isPreciding && count > 0)
            {
                var currAnimal = animalCollection[count];
                var currSentence = result == string.Empty
                    ? GetSwallowedAnimalToCatchPreviousAnimal(currAnimal)
                    : "\n" + GetSwallowedAnimalToCatchPreviousAnimal(currAnimal);
                result += currSentence;
                count--;
                isPreciding = HasPredecessors(animalCollection[count]);
            }
            return result;
        }
        private bool HasPredecessors(string animal) =>
            animal != animalCollection.First();
        private string GetSwallowedAnimalToCatchPreviousAnimal(string animal)
        {
            var previousAnimal = GetPreviousAnimal(animal);
            var separator = GetSeparatorFromAnimal(animal);
            return $"She swallowed the {animal} to catch the {previousAnimal}{separator}";
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