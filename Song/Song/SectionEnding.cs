using System.Collections.Generic;

namespace Song
{
    public class SectionEnding : ValueObject
    {
        public string Value { get; }
        private const string prefix = "I don't know why she swallowed a";
        private const string sufix = "- perhaps she'll die!";

        public SectionEnding(string  animal)
        {
            Value = $"{prefix} {animal} {sufix}";
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
