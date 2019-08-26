using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contently.Extensions
{
    public static class IdentityConfigurationExtension
    {
        public static IServiceCollection ConfigureIdentity(this IServiceCollection services )
        {
            //services.AddIdentity<ApplicationUser, IdentityRole>()
            //    .AddEntityFrameworkStores<ApplicationDbContext>()
            //    .AddDefaultTokenProviders();

            //services.Configure<IdentityOptions>(options =>
            //{
            //    // Password settings
            //    options.Password.RequireDigit = true;
            //    options.Password.RequiredLength = 8;
            //    options.Password.RequireNonAlphanumeric = false;
            //    options.Password.RequireUppercase = true;
            //    options.Password.RequireLowercase = false;

            //    // Lockout settings
            //    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
            //    options.Lockout.MaxFailedAccessAttempts = 10;

            //    // Cookie settings
            //    options.Cookies.ApplicationCookie.ExpireTimeSpan = TimeSpan.FromDays(150);
            //    options.Cookies.ApplicationCookie.LoginPath = "/Account/LogIn";
            //    options.Cookies.ApplicationCookie.LogoutPath = "/Account/LogOut";

            //    // User settings
            //    options.User.RequireUniqueEmail = true;
            //});

            return services;
        }
    }
}
