using ApprovalTests;
using Songs.SharedKernel;
using System;
using System.Collections.Generic;
using Xunit;

namespace Song.Test
{
    public class SongShould
    {
        [Fact]
        public void HaveLyrics()
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
            var rymeList = new List<AnimalRhyme>
            {
                AnimalRhyme.CreatePresentTenseRhyme("bird", "How absurd to"),
                AnimalRhyme.CreatePresentTenseRhyme("cat", "Fancy that to"),
                AnimalRhyme.CreatePresentTenseRhyme("dog", "What a hog, to"),
                AnimalRhyme.CreatePastTenseRhyme("cow", "I don't know how she")
            };
            var lyrics = new Lyrics(animalCollection, rymeList);
            var sut = new Lyrics(animalCollection, rymeList);
            Approvals.Verify(sut.Song);
        }
    }
}
