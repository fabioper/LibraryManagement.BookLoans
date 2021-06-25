using BookLoans.API.Consumers;
using BookLoans.API.Services;
using BookLoans.API.Services.Contracts;
using BookLoans.Domain.Interfaces;
using BookLoans.Infra.Data;
using BookLoans.Infra.Messaging;
using BookLoans.Infra.Messaging.Contracts;
using BookLoans.Infra.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace BookLoans.API
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "BookLoans.API", Version = "v1"});
            });

            services.AddLogging(builder => builder.AddSeq(Configuration.GetSection("Seq")));
            
            services.AddDbContext<BookLoansContext>();

            services.AddScoped<ILoansService, LoansService>();
            services.AddScoped<ILoansRepository, LoansRepository>();
            services.AddScoped<IBooksRepository, BooksRepository>();

            services.AddScoped<IServiceBus, ServiceBus>();

            services.AddHostedService<BookCreatedConsumer>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BookLoans.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}