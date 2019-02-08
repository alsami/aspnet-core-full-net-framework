using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Full.NetFrameWork.AspNetCore
{
    public interface IDependency
    {
    }

    public class Dependency : IDependency
    {
    }

    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IDependency, Dependency>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.Run(async ctx =>
            {
                var dependency = ctx.RequestServices.GetRequiredService<IDependency>();
                await ctx.Response.WriteAsync($"Hello I got a dependency {dependency.GetHashCode()}");
            });
        }
    }
}