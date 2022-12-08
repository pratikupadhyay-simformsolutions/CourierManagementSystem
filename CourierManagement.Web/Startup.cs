using AutoMapper;
using CourierManagement.Database;
using CourierManagement.Repository.IRepositories;
using CourierManagement.Repository.Repositories;
using CourierManagement.Services.Helper;
using CourierManagement.Services.IService;
using CourierManagement.Services.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CourierManagement.Web
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
            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            services.AddRazorPages().AddRazorRuntimeCompilation();

            services.AddDbContext<CourierManagmentContext>(options =>
    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
    b => b.MigrationsAssembly(typeof(CourierManagmentContext).Assembly.FullName)));

            services.AddRazorPages();

            RegisterAutoMapper(services);

            services.AddTransient<ICourierRepository, CourierRepository>();
            services.AddTransient<ICourierService, CourierService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, CourierManagmentContext dataContext)
        {
            dataContext.Database.Migrate();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(name: "default", pattern: "{controller=Courier}/{action=List}/{id?}");
            });
        }

        private void RegisterAutoMapper(IServiceCollection services)
        {
            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
