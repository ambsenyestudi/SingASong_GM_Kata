using System;
using System.Collections.Generic;
using System.Text;

namespace Song
{
    public class AnimalRhyme
    {

        public string Animal { get; }
        public string Rhyme { get; }
        public VerbTenses VerbTense { get; }
        private AnimalRhyme(string animal, string rhyme, VerbTenses verbTenses)
        {
            Animal = animal;
            Rhyme = rhyme;
            VerbTense = verbTenses;
        }
        public static AnimalRhyme CreatePresentTenseRhyme(string animal, string rhyme) =>
            new AnimalRhyme(animal, rhyme, VerbTenses.Present);

        public static AnimalRhyme CreatePastTenseRhyme(string animal, string rhyme) =>
            new AnimalRhyme(animal, rhyme, VerbTenses.Past);
    }
}
