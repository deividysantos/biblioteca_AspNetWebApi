using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using AutoMapper;
using biblioteca_AspNetWebApi.Mapper;
using biblioteca_AspNetWebApi.Data;
using Microsoft.EntityFrameworkCore;
using biblioteca_AspNetWebApi.Services;
using biblioteca_AspNetWebApi.Repository;
using biblioteca_AspNetWebApi.Repository.RepositoryInterfaces;

namespace biblioteca_AspNetWebApi
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

            var mappingConfig = new MapperConfiguration(
                mapperConfiguration => 
                mapperConfiguration.AddProfile(new Mapping())
            );

            IMapper mapper = mappingConfig.CreateMapper();

            services.AddSingleton(mapper);
            
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "biblioteca_AspNetWebApi", Version = "v1" });
            });

            services.AddDbContext<BibliotecaContext>(options => 
            options.UseSqlServer(Configuration.GetConnectionString("biblioteca")));

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IClerkRepository, ClerkRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IPunishmentRepository, PunishmentRepository>();

            //to do: arrumar a inje????o de depend??ncia
            services.AddTransient<BookService>();
            services.AddTransient<ClerkService>();
            services.AddTransient<ClientService>();
            services.AddTransient<OrderService>();
            services.AddTransient<PunishmentService>();

            services.AddCors();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "biblioteca_AspNetWebApi v1"));
            }

            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true)
                .AllowCredentials());

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
