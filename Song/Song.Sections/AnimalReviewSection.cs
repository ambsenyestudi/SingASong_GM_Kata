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
        public List<string> GetSentences()
        {
            var result = new List<string>();
            var count = animalCollection.Count - 1;
            var isPreciding = animalCollection.Count > 1;

            while (isPreciding && count > 0)
            {
                var currAnimal = animalCollection[count];
                result.Add(GetSwallowedAnimalToCatchPreviousAnimal(currAnimal));
                count--;
                isPreciding = HasPredecessors(animalCollection[count]);
            }
            return result;
        }
        public override string ToString() =>
            string.Join(",", GetSentences());

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