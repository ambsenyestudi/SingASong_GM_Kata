using System.Collections.Generic;

namespace Song
{
    public class FirstSentence: ValueObject
    {
        private const string TEXT = "There was an old lady who swallowed a ";
        public string Value { get; }
        public FirstSentence(string animal, string separtor = ";")
        {
            Value = TEXT + animal + separtor;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
