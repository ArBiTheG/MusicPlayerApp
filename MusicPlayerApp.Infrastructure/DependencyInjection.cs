using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MusicPlayerApp.Core.Interfaces.Adapters;
using MusicPlayerApp.Core.Interfaces.Loaders;
using MusicPlayerApp.Infrastructure.Adapters;
using MusicPlayerApp.Infrastructure.Loaders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerApp.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IMusicLoader, TagLibMusicLoader>();
            services.AddSingleton<IImageLoader, TagLibImageLoader>();
            services.AddSingleton<IMusicPlayerAdapter, VlcMusicPlayerAdapter>();
            return services;
        }
    }
}
