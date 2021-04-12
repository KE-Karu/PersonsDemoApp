using GraphQL.Server;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PersonsDemoApp.AppDbContext;
using PersonsDemoApp.InputTypes;
using PersonsDemoApp.Mutations;
using PersonsDemoApp.Repositories;
using PersonsDemoApp.Schemas;

namespace PersonsDemoApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
            });
            //services.AddCors(c =>
            //{
            //    c.AddPolicy("AllowOrigin", options => options.WithOrigins("https://localhost:5001"));
            //});
            //services.AddCors(c =>
            //{
            //    c.AddPolicy("AllowOrigin", options => options.WithOrigins("http://localhost:5000"));
            //});
            //services.AddCors(c =>
            //{
            //    c.AddPolicy("AllowOrigin", options => options.WithOrigins("http://localhost:52297"));
            //});
      
            services.AddRazorPages();
            services.AddDbContext<PersonsDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IRelationRepository, RelationRepository>();
            services
                .AddScoped<PersonsSchema>()
                .AddScoped<PersonsMutation>()
                .AddScoped<PersonsInputType>()
                .AddScoped<PersonalRelationsInputType>()
                .AddGraphQL((options, provider) =>
                {
                    options.EnableMetrics = Environment.IsDevelopment();
                    var logger = provider.GetRequiredService<ILogger<Startup>>();
                    options.UnhandledExceptionDelegate = ctx => logger.LogError("{Error} occurred", ctx.OriginalException.Message);
                })


            // Add required services for GraphQL request/response de/serialization
                .AddSystemTextJson() // For .NET Core 3+
                .AddErrorInfoProvider(opt => opt.ExposeExceptionStackTrace = Environment.IsDevelopment())
                .AddWebSockets() // Add required services for web socket support
                .AddDataLoader() // Add required services for DataLoader support
                .AddGraphTypes(typeof(PersonsSchema), ServiceLifetime.Scoped); // Add all IGraphType implementors in assembly which ChatSchema exists 
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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
            app.UseWebSockets();

            // use websocket middleware for ChatSchema at default path /graphql
            app.UseGraphQLWebSockets<PersonsSchema>("/graphql");
            // use HTTP middleware for ChatSchema at default path /graphql
            app.UseGraphQL<PersonsSchema>("/graphql");

            //app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCors(option => option.AllowAnyOrigin());
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
