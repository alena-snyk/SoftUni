﻿using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(Panda.Areas.Identity.IdentityHostingStartup))]
namespace Panda.Areas.Identity
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