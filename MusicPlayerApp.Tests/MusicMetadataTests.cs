using Microsoft.VisualStudio.TestPlatform.Utilities;
using MusicPlayerApp.Services;
using Xunit.Abstractions;

namespace MusicPlayerApp.Tests
{
    public class MusicMetadataTests
    {
        private readonly ITestOutputHelper output;
        const string PATH_SKILLET_HERO = @"Skillet_-_Hero_47950055.mp3";

        public MusicMetadataTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void GetTitle_SkilletMusic_Hero()
        {
            string expected = "Hero";

            IMusicMetadata metadata = new MusicMetadata(PATH_SKILLET_HERO);
            string actual = metadata.Title;
            output.WriteLine("Title: " + actual);

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void GetArtists_SkilletMusic_Skillet()
        {
            string expected = "Skillet";

            IMusicMetadata metadata = new MusicMetadata(PATH_SKILLET_HERO);
            string[] actual = metadata.Artists;
            output.WriteLine("Artists: " + string.Join(", ",actual));

            Assert.Contains(expected, actual);
        }
    }
}
