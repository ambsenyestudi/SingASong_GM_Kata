using SingASong.SharedKernel;
using System.Collections.Generic;

namespace Song.Sections
{
    internal class SectionEnd : ValueObject
    {
        internal string Value { get; }
        private const string prefix = "I don't know why she swallowed a";
        private const string sufix = "- perhaps she'll die!";

        internal SectionEnd(string animal)
        {
            Value = $"{prefix} {animal} {sufix}";
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}