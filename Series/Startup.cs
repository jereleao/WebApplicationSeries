using GraphQL;
using GraphQL.DataLoader;
using GraphQL.NewtonsoftJson;
using GraphQL.Server;
using GraphQL.Types;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Series.Database.Interfaces;
using Series.Database.Repositories;
using Series.DataBase;
using Series.GraphQL;
using Series.GraphQL.Types;

namespace Series
{
    public class Startup
    {
        public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IDocumentWriter, DocumentWriter>();
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<IDataLoaderContextAccessor, DataLoaderContextAccessor>();
            services.AddSingleton<DataLoaderDocumentListener>();
            services.AddTransient<ISchema, SeriesSchema>();
            services.AddTransient<SeriesQuery>();
            services.AddTransient<SeriesMutation>();

            services.AddTransient<SerieType>();
            services.AddTransient<CategoryType>();
            services.AddTransient<SerieInputType>();

            services.AddTransient<ISerieRepository, SerieRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();

            services
                .AddGraphQL(
                    (options, provider) =>
                    {
                        // Load GraphQL Server configurations
                        var graphQLOptions = Configuration
                            .GetSection("GraphQL")
                            .Get<GraphQLOptions>();
                        options.ComplexityConfiguration = graphQLOptions.ComplexityConfiguration;
                        options.EnableMetrics = graphQLOptions.EnableMetrics;
                        // Log errors
                        var logger = provider.GetRequiredService<ILogger<Startup>>();
                        options.UnhandledExceptionDelegate = ctx =>
                            logger.LogError("{Error} occurred", ctx.OriginalException.Message);
                    })
                // Adds all graph types in the current assembly with a singleton lifetime.
                .AddGraphTypes()
                // Add GraphQL data loader to reduce the number of calls to our repository. https://graphql-dotnet.github.io/docs/guides/dataloader/
                .AddDataLoader()
                .AddSystemTextJson();

            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            services.AddDbContext<SeriesContext>();
                //(options => options.UseLoggerFactory(loggerFactory).UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=GameStoreDb;Trusted_Connection=True;"), ServiceLifetime.Transient);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseGraphQLPlayground();
            }

            app.UseGraphQL<ISchema>();
        }
    }
}