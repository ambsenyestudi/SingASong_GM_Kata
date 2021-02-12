namespace Song
{
    public class Section:SentenceComposition
    {
        private Section(SectionOpening opening, SectionEnding ending):base(Compose(opening, ending))
        {
        }
        private static string Compose(SectionOpening opening, SectionEnding ending)
        {
            return ComposeSentences(opening.Value, ending.Value);
        }

        public static Section Create(SectionOpening opening, SectionEnding ending)
        {
            return new Section(opening, ending);
        }
    }
}
