namespace Song
{
    public class Section:SentenceComposition
    {
        private Section(SectionOpening opening, SectionEnding ending, string text = ""):base(Compose(opening, ending, text))
        {
        }
        private static string Compose(SectionOpening opening, SectionEnding ending, string text ) =>
            string.IsNullOrWhiteSpace(text)
            ? ComposeSentences(opening.Value, ending.Value)
            : ComposeSentences(opening.Value, text, ending.Value);


        public static Section Create(SectionOpening opening, SectionEnding ending)
        {
            return new Section(opening, ending);
        }
        public static Section Create(SectionOpening opening, string text, SectionEnding ending)
        {
            return new Section(opening, ending, text);
        }
        public static Section Create(SectionOpening opening, string text, AnimalReviewSection animalReview, SectionEnding ending)
        {
            var texRev = text + animalReview.ToString();
            return new Section(opening, ending, texRev);
        }
        public static Section Create(SectionOpening opening, AnimalRhyme rime, AnimalReviewSection animalReview, SectionEnding ending)
        {
            var texRev = rime.Value + "\n" + animalReview.ToString();
            return new Section(opening, ending, texRev);
        }
    }
}
