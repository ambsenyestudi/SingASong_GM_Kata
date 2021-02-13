using SingASong.SharedKernel;
using System.Collections.Generic;
using System.Linq;

namespace Song.Sections
{
    public class Section : ValueObject
    {
        public IReadOnlyCollection<string> SentenceList { get; }
        protected Section(List<string> sentenceList)
        {
            SentenceList = sentenceList;
        }

        private Section(SectionOpening opening, SectionEnding ending) : 
            this(new List<string>
            {
                opening.Value,
                ending.Value
            })
        {
        }
        private Section(SectionOpening opening, AnimalRhyme rhyme, List<string> animalReviewSentenceList, SectionEnding ending, string rhymeSeparator= "!") : 
            this(ComposeSentences(opening, rhyme, animalReviewSentenceList, ending, rhymeSeparator))
        {
        }

        public override string ToString() =>
            string.Join("\n", SentenceList);
        private static List<string> ComposeSentences(SectionOpening opening, AnimalRhyme rhyme, List<string> animalReviewSentenceList, SectionEnding ending, string rhymeSeparator)
        {
            var openingSetences = ComposeOpening(opening);
            var composedSentences = ComposeRhyme(rhyme, openingSetences, rhymeSeparator);
            composedSentences.AddRange(animalReviewSentenceList);
            composedSentences.Add(ending.Value);
            return composedSentences;
        }

        private static List<string> ComposeRhyme(AnimalRhyme rhyme, List<string> openingSetences, string separator)
        {
            openingSetences.Add(rhyme == AnimalRhyme.Empty
                ? "That wriggled and wiggled and tickled inside her."
                : $"{rhyme.Value}{separator}");
            return openingSetences;
        }


        private static List<string> ComposeOpening(SectionOpening opening) =>
            new List<string>
            {
                opening.Value,
            };
        
        public static Section Create(string animal, string separator = ".")
        {
            var opening = new SectionOpening(animal, separator);
            var ending = new SectionEnding(animal);
            return new Section(opening, ending);
        }
        public static Section Create(List<string> animalCollection, AnimalRhyme rhyme, string separator = "!")
        {
            var opening = new SectionOpening(animalCollection.Last());
            var ending = new SectionEnding(animalCollection.First());
            var animalReview = new AnimalReviewSection(animalCollection); 
            
            return new Section(opening, rhyme, animalReview.GetSentences(), ending, separator);
        }

        protected override IEnumerable<object> GetEqualityComponents() => SentenceList;
    }

}