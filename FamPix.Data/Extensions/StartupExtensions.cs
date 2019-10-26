using FamPix.Core;
using FamPix.Data;
using FamPix.Data.Abstracts;
using FamPix.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace FamPix
{
    public static class StartupExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<FamPixDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<IFamPixDbContext, FamPixDbContext>();
            services.AddScoped<IRepository<Photo>, PhotoRepository>();
            services.AddScoped<IRepository<Album>, AlbumRepository>();

            return services;
        }
    }
}
