using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RestaurantAPI.Core.Application.Interfaces.Repositories;
using RestaurantAPI.Infrastructure.Persistence.Seeds.Category;
using RestaurantAPI.Infrastructure.Persistence.Seeds.Order;
using RestaurantAPI.Infrastructure.Persistence.Seeds.TableStatuses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            //Creating the dependency injection manually
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    //var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                    //var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                    //var productRepo = services.GetRequiredService<ITypeAccountRepository>();
                    var plateCategory = services.GetRequiredService<IPlateCategoryRepository>();
                    var orderStatus = services.GetRequiredService<IOrderStatusRepository>();
                    var tableStatus = services.GetRequiredService<ITableStatusRepository>();

                    await DefaultEntryCategory.SeedAsync(plateCategory);
                    await DefaultMainCourseCategory.SeedAsync(plateCategory);
                    await DefaultDrinkCategory.SeedAsync(plateCategory);
                    await DefaultDessertCategory.SeedAsync(plateCategory);

                    await DefaultDoneOrderStatus.SeedAsync(orderStatus);
                    await DefaultInProcessOrderStatus.SeedAsync(orderStatus);

                    await DefaultAttendedStatus.SeedAsync(tableStatus);
                    await DefaultAttendedStatus.SeedAsync(tableStatus);
                    await DefaultInProccessStatus.SeedAsync(tableStatus);


                    //await DefaultRoles.SeedAsync(userManager, roleManager);
                    //await DefaultAdminUser.SeedAsync(userManager, roleManager);
                    //await DefaultBasicUser.SeedAsync(userManager, roleManager);

                    //await DefaultSavingAccount.SeedAsync(productRepo);
                    //await DefaultCreditAccount.SeedAsync(productRepo);
                    //await DefaultLoanAccount.SeedAsync(productRepo);
                }
                catch (Exception)
                {

                    throw;
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
