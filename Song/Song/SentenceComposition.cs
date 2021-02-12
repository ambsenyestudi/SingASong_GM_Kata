using System.Collections.Generic;

namespace Song
{
    public class SentenceComposition: ValueObject
    {
        public string Value { get; }
        protected SentenceComposition(string value)
        {
            Value = value;
        }
        protected static string ComposeSentences(params string[] sentences) =>
            string.Join("\n", sentences);

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
