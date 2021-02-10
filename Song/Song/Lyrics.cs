using System.Collections.Generic;
using System.Linq;

namespace Song
{
    public class Lyrics
    {
        public string Song { get; }
        public Lyrics()
        {
            var animals = new List<string>{
                "fly",
                "spider",
                "bird",
                "cat",
                "dog",
                "cow",
                "horse"
            };
            var sectionList = new List<string>
            {
                @$"There was an old lady who swallowed a fly.
                I don't know why she swallowed a fly - perhaps she'll die!
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
                @"There was an old lady who swallowed a horse...
                ...She's dead, of course!"
            };
            var joinedSections = "";
            foreach (var section in sectionList)
            {
                joinedSections += section;
            }
            Song = joinedSections;
                
        }
    }
}
