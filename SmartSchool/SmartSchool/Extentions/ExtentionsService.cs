using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartSchool.Models;
using SmartSchool.UnitOfWork;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.Extentions
{
    public static class ExtentionsService
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection service)
        {
            service.AddTransient<IUnitOfWork, UnitOfWorks>();
            return service;
        }
        public static IServiceCollection AddDataBase(this IServiceCollection service)
        {
            service.AddDbContext<SmartSchoolContext>(option =>
            {
                option.UseSqlServer(GetConnectionString());
            });
            return service;
        }
        private static string GetConnectionString()
        {
            IConfigurationRoot config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true).Build();
            var connString = config["ConnectionString:default"];
            return connString;
        }
    }
}
