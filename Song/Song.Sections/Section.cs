using SingASong.SharedKernel;
using System.Collections.Generic;
using System.Linq;

namespace Song.Sections
{
    public class Section : ValueObject
    {
        private const string NO_ANIMAL_RHYME_SENTENCE = "That wriggled and wiggled and tickled inside her.";
        public IReadOnlyCollection<string> SentenceList { get; }
        protected Section(List<string> sentenceList)
        {
            SentenceList = sentenceList;
        }

        private Section(SectionStart opening, AnimalRhyme rhyme, List<string> animalReviewSentenceList, SectionEnd ending, string rhymeSeparator= "!") 
        {
            SentenceList = ComposeSentences(opening, rhyme, animalReviewSentenceList, ending, rhymeSeparator);
        }

        public override string ToString() =>
            string.Join("\n", SentenceList);
        private List<string> ComposeSentences(SectionStart opening, AnimalRhyme rhyme, List<string> animalReviewSentenceList, SectionEnd ending, string rhymeSeparator)
        {
            var openingSetences = ComposeOpening(opening);
            var composedSentences = ComposeRhyme(rhyme, openingSetences, rhymeSeparator);
            composedSentences.AddRange(animalReviewSentenceList);
            composedSentences.Add(ending.Value);
            return composedSentences;
        }

        private List<string> ComposeRhyme(AnimalRhyme rhyme, List<string> openingSetences, string separator)
        {
            openingSetences.Add(rhyme == AnimalRhyme.Empty
                ? NO_ANIMAL_RHYME_SENTENCE
                : $"{rhyme.Value}{separator}");
            return openingSetences;
        }


        private static List<string> ComposeOpening(SectionStart opening) =>
            new List<string>
            {
                opening.Value,
            };
        
        
        public static Section Create(List<string> animalCollection, AnimalRhyme rhyme, string separator = "!")
        {
            var opening = new SectionStart(animalCollection.Last());
            var ending = new SectionEnd(animalCollection.First());
            var animalReview = new AnimalReviewSection(animalCollection); 
            
            return new Section(opening, rhyme, animalReview.GetSentences(), ending, separator);
        }

        protected override IEnumerable<object> GetEqualityComponents() => SentenceList;
    }

}