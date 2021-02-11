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
            var sut = new Lyrics(animalCollection);
            Approvals.Verify(sut.Song);
        }
    }
}
