using System.Collections.Generic;

namespace Song.Sections
{
    public class OpeningSection:Section
    {
        private OpeningSection(SectionStart opening, SectionEnd ending) :
            base(new List<string>
            {
                opening.Value,
                ending.Value
            })
        {

        }
        public static OpeningSection Create(string animal, string separator = ".")
        {
            var opening = new SectionStart(animal, separator);
            var ending = new SectionEnd(animal);
            return new OpeningSection(opening, ending);
        }
    }
}
