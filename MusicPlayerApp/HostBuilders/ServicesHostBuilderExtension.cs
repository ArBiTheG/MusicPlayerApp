using LibVLCSharp.Shared;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MusicPlayerApp.Services;
using MusicPlayerApp.Services.MusicPlayer;
using MusicPlayerApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerApp.HostBuilders
{
    public static class ServicesHostBuilderExtension
    {
        public static IHostBuilder AddServices(this IHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureServices((context, services) =>
            {
                services.AddSingleton<IMusicDataLoader>(s => new MusicDataLoader(str => new MusicMetadata(str)));
                services.AddSingleton<IMusicImageLoader>(s => new MusicImageLoader(str => new MusicMetadataImage(str)));

                services.AddSingleton(new LibVLC());
                services.AddSingleton<MediaPlayer>();
                services.AddSingleton<IMusicPlayer,VlcMusicPlayer>();
                services.AddSingleton<MusicService>();
            });
            return hostBuilder;
        }
    }
}
