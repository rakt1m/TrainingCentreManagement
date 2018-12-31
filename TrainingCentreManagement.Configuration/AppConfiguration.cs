using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TrainingCentreManagement.BLL.Contracts;
using TrainingCentreManagement.BLL.Managers;
using TrainingCentreManagement.DatabaseContext.DatabaseContext;
using TrainingCentreManagement.Repositories.Contracts;
using TrainingCentreManagement.Repositories.Repositories;


namespace TrainingCentreManagement.Configuration
{
   public static class AppConfiguration
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("ApplicationDbContext"), b => b.MigrationsAssembly("TrainingCentreManagement.DatabaseContext")));

           
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddTransient<IInstituteRepository, InstituteRepository>();
            services.AddTransient<IInstituteManager, InstituteManager>();
            services.AddTransient<ICourseRepository, CourseRepository>();
            services.AddTransient<ICourseManager, CourseManager>();
            services.AddTransient<IBatchRepository, BatchRepository>();
            services.AddTransient<IBatchManager, BatchManager>();
            services.AddTransient<ITraineeRepository, TraineeRepository>();
            services.AddTransient<ITraineeManager, TraineeManager>();

            services.AddTransient<ITrainerRepository, TrainerRepository>();
            services.AddTransient<ITrainerManager, TrainerManager>();
<<<<<<< HEAD
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<ICategoryManager, CategoryManager>();
=======
>>>>>>> f086ee706453272d91887f09ef1c2e4ebf3d9e98
        }
    }
}
