using MusicPlayerApp.Models;
using MusicPlayerApp.Services;
using TagLib.Flac;
using Xunit.Abstractions;

namespace MusicPlayerApp.Tests
{
    public class MusicLoaderTests
    {
        private readonly ITestOutputHelper output;
        const string PATH_SKILLET_HERO = @"Skillet_-_Hero_47950055.mp3";

        public MusicLoaderTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void GetMusicTitle_SkilletMusic_Hero()
        {
            string expected = "Hero";

            IMusicMetadataLoader loader = new MusicMetadataLoader(str => new MusicMetadata(str));
            Music music = loader.Load(PATH_SKILLET_HERO);

            string actual = music.Title;
            output.WriteLine("Title: " + actual);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetMusicArtists_SkilletMusic_Hero()
        {
            string expected = "Skillet";

            IMusicMetadataLoader loader = new MusicMetadataLoader(str => new MusicMetadata(str));
            Music music = loader.Load(PATH_SKILLET_HERO);

            string[] actual = music.Artists;
            output.WriteLine("Artists: " + string.Join(", ", actual));

            Assert.Contains(expected, actual);
        }
    }
}
