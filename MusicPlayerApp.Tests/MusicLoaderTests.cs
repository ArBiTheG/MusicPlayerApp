using MusicPlayerApp.Core.Interfaces.Loaders;
using MusicPlayerApp.Infrastructure.Loaders;
using Xunit.Abstractions;

namespace MusicPlayerApp.Tests
{
    public class MusicLoaderTests
    {
        private readonly ITestOutputHelper output;

        public MusicLoaderTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void Load_SkilletMusic_Title()
        {
            string excepted = "Hero";
            string actual = string.Empty;

            IMusicLoader loader = new TagLibMusicLoader();

            var music = loader.Load(@"C:\Users\Daniil\Music\Hero.mp3");
            actual = music.Title;

            output.WriteLine($"Title: {music.Title}");

            Assert.Equal(excepted, actual);
        }
    }
}
