using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(ELibrary_Team_1.Areas.Identity.IdentityHostingStartup))]
namespace ELibrary_Team_1.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}