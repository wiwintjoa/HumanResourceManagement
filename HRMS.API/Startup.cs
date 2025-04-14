using HRMS.DataAccess;
using HRMS.DataAccess.Application;
using Microsoft.EntityFrameworkCore;

namespace HRMS.API
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();

			services.AddCors(options =>
			{
				options.AddPolicy(name: "AllowAllOrigin",
					builder =>
					{
						builder.WithOrigins("http://localhost:9000").AllowAnyHeader().AllowAnyMethod();
					});
			});

			services.AddSwaggerGen();

			services.AddDbContext<ApplicationContext>(options =>
			{
				options.UseSqlServer(this.Configuration.GetConnectionString("DefaultConnection"));
				options.EnableSensitiveDataLogging();
			});

			services.AddAutoMapper(typeof(AutoMapperProfile));

			services.SetupRepositories();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			// Configure the HTTP request pipeline.
			if (!env.IsProduction())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();

			app.UseExceptionHandler("/error");
			app.UseRouting();

			if (!env.IsProduction())
			{
				app.UseCors("AllowAllOrigin");
			}

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}

	}
}
