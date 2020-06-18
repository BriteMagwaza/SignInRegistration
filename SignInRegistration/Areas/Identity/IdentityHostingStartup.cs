using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SignInRegistration.Areas.Identity.Data;
using SignInRegistration.Data;

[assembly: HostingStartup(typeof(SignInRegistration.Areas.Identity.IdentityHostingStartup))]
namespace SignInRegistration.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<SignInRegistrationDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("SignInRegistrationDbContextConnection")));

                services.AddDefaultIdentity<ApplicationUser>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                })
               

                
                    .AddEntityFrameworkStores<SignInRegistrationDbContext>();
            });
        }
    }
}