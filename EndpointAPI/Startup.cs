using AutoMapper;
using Demo.Core.ApplicationService;
using Demo.Core.ApplicationService.Config.Profiles;
using Demo.Core.Contracts;
using Demo.Infra.Data;
using Demo.Infra.EF;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace EndpointAPI
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
           

            var mapperConfig = new MapperConfiguration(mc =>

             mc.AddProfile(new AccountProfile())


             );

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddScoped<MyUnitOfWork>();
            services.AddDbContext<DemoContext>(option => 
            option.UseSqlServer(Configuration.GetConnectionString("default")));

            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new Info { Title = "Accpunt API", Version = "V1.0.0" });
            });
            services.AddScoped<IAccountRepository, AccountRepository>();
        
            services.AddScoped<IAccountFacade, AccountFacade>();
         
           




            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", " API V1");
            });

            app.UseMvc();
        }
    }
}
