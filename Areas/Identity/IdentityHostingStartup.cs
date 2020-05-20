using System;
using AuthMvc.Areas.Identity.Data;
using AuthMvc.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(AuthMvc.Areas.Identity.IdentityHostingStartup))]
namespace AuthMvc.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<AuthMvcContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("AuthMvcContextConnection")));

                services.AddDefaultIdentity<ApplicationUser>(options => {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false; 
                    })
                    .AddEntityFrameworkStores<AuthMvcContext>();
            });
        }
    }
}