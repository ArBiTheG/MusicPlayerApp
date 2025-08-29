using LibVLCSharp.Shared;
using MusicPlayerApp.Domain.Interfaces.Adapters;
using MusicPlayerApp.Infrastructure.Adapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace MusicPlayerApp.Tests
{
    public class MusicPlayerTests
    {
        private readonly ITestOutputHelper output;

        public MusicPlayerTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void Play_SkilletMusic_True()
        {
            using IMusicPlayer music = new VlcMusicPlayer();

            music.Open(@"C:\Users\Daniil\Music\Hero.mp3");
            var result = music.Play();
            Assert.True(result);
        }

        [Fact]
        public void Play_WithoutSkilletMusic_False()
        {
            using IMusicPlayer music = new VlcMusicPlayer();

            var result = music.Play();

            Assert.False(result);
        }
    }
}
