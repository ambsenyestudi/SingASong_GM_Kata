namespace SingASong.Domain
{
    public class LyricsEnding
    {
        public const string ENDING = "...She's dead, of course!";
        public string Value { get; }
        public LyricsEnding(string animal)
        {
            Value = composeSentences(
                $"There was an old lady who swallowed a {animal}...",
                ENDING);
        }
        private string composeSentences(params string[] sentences) =>
            string.Join("\n", sentences);
    }
}
