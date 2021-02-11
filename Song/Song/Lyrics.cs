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
                @$"I don't know why she swallowed a fly - perhaps she'll die!
",
                @"There was an old lady who swallowed a spider;
That wriggled and wiggled and tickled inside her.
She swallowed the spider to catch the fly;
I don't know why she swallowed a fly - perhaps she'll die!
",
                @"There was an old lady who swallowed a bird;
How absurd to swallow a bird.
She swallowed the bird to catch the spider,
She swallowed the spider to catch the fly;
I don't know why she swallowed a fly - perhaps she'll die!
",
                @"There was an old lady who swallowed a cat;
Fancy that to swallow a cat!
She swallowed the cat to catch the bird,
She swallowed the bird to catch the spider,
She swallowed the spider to catch the fly;
I don't know why she swallowed a fly - perhaps she'll die!
",
                @"There was an old lady who swallowed a dog;
What a hog, to swallow a dog!
She swallowed the dog to catch the cat,
She swallowed the cat to catch the bird,
She swallowed the bird to catch the spider,
She swallowed the spider to catch the fly;
I don't know why she swallowed a fly - perhaps she'll die!
",
                @"There was an old lady who swallowed a cow;
I don't know how she swallowed a cow!
She swallowed the cow to catch the dog,
She swallowed the dog to catch the cat,
She swallowed the cat to catch the bird,
She swallowed the bird to catch the spider,
She swallowed the spider to catch the fly;
I don't know why she swallowed a fly - perhaps she'll die!
",              
            };

            Song = ComposeSong();
                
        }
        public string ComposeSong()
        {
            var joinedSections = GetStart();
            foreach (var section in sectionList)
            {
                joinedSections += section;
            }
            joinedSections += GetEnding();
            return joinedSections;
        }
        public string GetStart() => "There was an old lady who swallowed a fly.\n";
        public string GetEnding() => "There was an old lady who swallowed a horse...\n" +
            "...She's dead, of course!";

    }
}
