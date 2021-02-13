using ApprovalTests;
using Songs.SharedKernel;
using System;
using System.Collections.Generic;
using Xunit;
using domain = SingASong.Domain;

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
            var rhymeList = new List<AnimalRhyme>
            {
                AnimalRhyme.CreatePresentTenseRhyme("bird", "How absurd to"),
                AnimalRhyme.CreatePresentTenseRhyme("cat", "Fancy that to"),
                AnimalRhyme.CreatePresentTenseRhyme("dog", "What a hog, to"),
                AnimalRhyme.CreatePastTenseRhyme("cow", "I don't know how she")
            };
            var songId = Guid.NewGuid();
            var sut = new domain.Song(songId);
            sut.AddAnimals(animalCollection);
            sut.AddRhymes(rhymeList);
            var result = sut.GetLyrics();   
            Approvals.Verify(result);
        }
    }
}
