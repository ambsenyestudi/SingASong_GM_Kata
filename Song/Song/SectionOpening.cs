using System.Collections.Generic;

namespace Song
{
    public class SectionOpening: ValueObject
    {
        private const string TEXT = "There was an old lady who swallowed a ";
        public string Value { get; }
        public SectionOpening(string animal, string separtor = ";")
        {
            Value = TEXT + animal + separtor;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
