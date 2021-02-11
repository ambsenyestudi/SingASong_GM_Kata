using System.Collections.Generic;
using System.Linq;

namespace Song
{
    public class Lyrics
    {
        private List<string> animals;
        private readonly List<string> sectionList;

        public string Song { get; }
        public Lyrics()
        {
            animals = new List<string>{
                "fly",
                "spider",
                "bird",
                "cat",
                "dog",
                "cow",
                "horse"
            };
            sectionList = new List<string>
            {
                @"That wriggled and wiggled and tickled inside her.
",
                @"How absurd to swallow a bird.
She swallowed the bird to catch the spider,
",
                @"Fancy that to swallow a cat!
She swallowed the cat to catch the bird,
She swallowed the bird to catch the spider,
",
                @"What a hog, to swallow a dog!
She swallowed the dog to catch the cat,
She swallowed the cat to catch the bird,
She swallowed the bird to catch the spider,
",
                @"I don't know how she swallowed a cow!
She swallowed the cow to catch the dog,
She swallowed the dog to catch the cat,
She swallowed the cat to catch the bird,
She swallowed the bird to catch the spider,
",              
            };

            Song = ComposeSong();
                
        }
        public string ComposeSong()
        {
            var joinedSections = GetStart();
            for (int i = 0; i < sectionList.Count; i++)
            {
                var animalIndex = i + 1;
                var currSection = BuildThereWasAnOldLadyWhoSwallowed(animals[animalIndex]) +
                    sectionList[i] + GetSwallowedTheSpiderToCatchTheFly() +
                    GetDontKnowWhySheSwallowedAFly();
                joinedSections += currSection;
            }
            joinedSections += GetEnding();
            return joinedSections;
        }
        public string BuildThereWasAnOldLadyWhoSwallowed(string animal) =>
            $"There was an old lady who swallowed a {animal};\n";
        public string GetStart() => "There was an old lady who swallowed a fly.\n" + 
            GetDontKnowWhySheSwallowedAFly();

        public string GetDontKnowWhySheSwallowedAFly() => "I don't know why she swallowed a fly - perhaps she'll die!\n";
        public string GetSwallowedTheSpiderToCatchTheFly() => "She swallowed the spider to catch the fly;\n";

        public string GetEnding() => "There was an old lady who swallowed a horse...\n" +
            "...She's dead, of course!";

    }
}
