using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using SPortal.WebAPI.Model.Context;
using SPortal.WebAPI.Model.Repositories.Contract;
using SPortal.WebAPI.Model.Repositories;

namespace SPortal.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            DbContextOptionsBuilder<SPortalContext> spctx = new DbContextOptionsBuilder<SPortalContext>();
            spctx.UseSqlServer(Configuration.GetConnectionString("sportalConStr"));

            services.AddDbContext<SPortalContext>(opt=>{
                opt = spctx;
            });
        
            services.AddSingleton<ICategoryRepository,CategoryRepository>(c=>new CategoryRepository(new SPortalContext(spctx.Options)));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
