using ApprovalTests;
using System;
using System.Collections.Generic;
using Xunit;

namespace Song.Test
{
    public class SongShould
    {
        [Fact]
        public void Test1()
        {
            var animalCollection = new List<string>{
                "fly",
                "spider",
                "bird",
                "cat",
                "dog",
                "cow",
                "horse"
            };
            var rymeDictionary = new Dictionary<string, string>
            {
                ["bird"] = "How absurd to",
                ["cat"] = "Fancy that to",
                ["dog"] = "What a hog, to",
                ["cow"] = "I don't know how she"
            };
            var sut = new Lyrics(animalCollection, rymeDictionary);
            Approvals.Verify(sut.Song);
        }
    }
}
