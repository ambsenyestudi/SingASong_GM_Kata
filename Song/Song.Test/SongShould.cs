using ApprovalTests;
using System;
using Xunit;

namespace Song.Test
{
    public class SongShould
    {
        [Fact]
        public void Test1()
        {
            var sut = new Lyrics();
            Approvals.Verify(sut.Song);
        }
    }
}
