using Microsoft.VisualStudio.TestPlatform.Utilities;
using MusicPlayerApp.Domain.Interfaces.Loaders;
using MusicPlayerApp.Infrastructure.Loaders;
using TagLib.Id3v2;
using Xunit.Abstractions;

namespace MusicPlayerApp.Tests
{
    public class ImageLoaderTests
    {
        private readonly ITestOutputHelper output;

        public ImageLoaderTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void Load_SkilletMusic_NotEmpty()
        {
            long excepted = 0;
            long actual = 0;

            IImageLoader loader = new TagLibImageLoader();
            using (var stream = loader.Load(@"C:\Users\Daniil\Music\Hero.mp3"))
            {
                actual = stream.Length;
            }
            output.WriteLine($"Bytes: {actual.ToString()}");

            Assert.NotEqual(excepted, actual);
        }
    }
}