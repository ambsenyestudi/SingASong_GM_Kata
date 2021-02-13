using System.Collections.Generic;

namespace Song.Sections
{
    public class ClosingSection : Section
    {
        private const string ENDING = "...She's dead, of course!";
        public ClosingSection(string animal)
            :
            base(new List<string>
            {
                $"There was an old lady who swallowed a {animal}...",
                ENDING })
        {
        }
    }
}
