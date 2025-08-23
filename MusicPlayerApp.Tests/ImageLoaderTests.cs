using Microsoft.VisualStudio.TestPlatform.Utilities;
using MusicPlayerApp.Services;
using System.Linq;
using Xunit.Abstractions;

namespace MusicPlayerApp.Tests
{
    public class ImageLoaderTests
    {
        private readonly ITestOutputHelper output;
        const string PATH_SKILLET_HERO = @"Skillet_-_Hero_47950055.mp3";

        public ImageLoaderTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void LoadBytes_SkilletMusic_NotEmpty()
        {
            int expected_lenght = 0; 

            IImageLoader loader = new ImageMetadataLoader();
            byte[] bytes = loader.LoadBytes(PATH_SKILLET_HERO);
            int actual_lenght = bytes.Length;
            output.WriteLine($"Bytes: {actual_lenght}");
            output.WriteLine($"Hash: {bytes.GetHashCode()}");

            Assert.NotEqual(expected_lenght, actual_lenght);
        }
    }
}