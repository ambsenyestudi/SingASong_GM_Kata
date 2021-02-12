using Songs.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Song.Sections
{
    public class Section : SentenceComposition
    {
        private Section(SectionOpening opening, SectionEnding ending, string text = "") : base(Compose(opening, ending, text))
        {
        }
        private static string Compose(SectionOpening opening, SectionEnding ending, string text) =>
            string.IsNullOrWhiteSpace(text)
            ? ComposeSentences(opening.Value, ending.Value)
            : ComposeSentences(opening.Value, text, ending.Value);

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
            var texRev = rhyme == AnimalRhyme.Empty
                ? "That wriggled and wiggled and tickled inside her.\n"
                : $"{rhyme.Value}{separator}\n"; 
            texRev += animalReview.ToString();
            return new Section(opening, ending, texRev);
        }
    }

}