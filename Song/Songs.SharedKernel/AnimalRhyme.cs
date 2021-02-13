using System.Collections.Generic;

namespace SingASong.SharedKernel
{
    public class AnimalRhyme : ValueObject
    {
        public static AnimalRhyme Empty { get; } = new AnimalRhyme(string.Empty, string.Empty);
        public string Animal { get; }
        public string Value { get; }
        public string Rhyme { get; }
        public VerbTenses VerbTense { get; }
        private AnimalRhyme(string animal, string value)
        {
            Animal = animal;
            Value = value;
        }


        protected override IEnumerable<object> GetEqualityComponents() =>
            new object[] { Animal, Rhyme, VerbTense };


        private static string CreatPresentRhyme(string animal, string rhyme)
        {
            var preposition = animal.StartsWith('a') || animal.StartsWith('A')
                ? "an"
                : "a";
            return $"{rhyme} swallow {preposition} {animal}";
        }
        private static string CreatPastRhyme(string animal, string rhyme)
        {
            var preposition = animal.StartsWith('a') || animal.StartsWith('A')
                ? "an"
                : "a";
            return $"{rhyme} swallowed {preposition} {animal}";
        }
        private static AnimalRhyme CreatFromVerbTens(string animal, string rhyme, VerbTenses verbTense)
        {
            if (verbTense == VerbTenses.Present)
                return new AnimalRhyme(animal, CreatPresentRhyme(animal, rhyme));
            if (verbTense == VerbTenses.Past)
                return new AnimalRhyme(animal, CreatPastRhyme(animal, rhyme));
            return AnimalRhyme.Empty;
        }
        public static AnimalRhyme CreatePresentTenseRhyme(string animal, string rhyme) =>
            CreatFromVerbTens(animal, rhyme, VerbTenses.Present);

        public static AnimalRhyme CreatePastTenseRhyme(string animal, string rhyme) =>
            CreatFromVerbTens(animal, rhyme, VerbTenses.Past);
    }
}
