using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Online_Bookshop_Final_Project.Models;

[assembly: HostingStartup(typeof(Online_Bookshop_Final_Project.Areas.Identity.IdentityHostingStartup))]
namespace Online_Bookshop_Final_Project.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<Online_Bookshop_IdentityContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("Online_Bookshop_IdentityContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<Online_Bookshop_IdentityContext>();
            });
        }
    }
}