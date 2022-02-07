using GraphQL;
using GraphQL.DataLoader;
using GraphQL.MicrosoftDI;
using GraphQL.NewtonsoftJson;
using GraphQL.Server;
using GraphQL.Types;
using Series.DataBase;
using Series.GraphQL;

var builder = WebApplication.CreateBuilder(args);

ILoggerFactory loggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });

// Add services to the container.
builder.Services.AddSingleton<IDocumentWriter, DocumentWriter>();
builder.Services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
builder.Services.AddSingleton<IDataLoaderContextAccessor, DataLoaderContextAccessor>();
//services.AddSingleton<DataLoaderDocumentListener>();

builder.Services.AddTransient<SeriesSchema>();
builder.Services.AddTransient<SeriesQuery>();
builder.Services.AddTransient<SeriesMutation>();

builder.Services.AddSingleton<ISchema, SeriesSchema>(services => new SeriesSchema(new SelfActivatingServiceProvider(services)));

builder.Services.AddDbContext<SeriesContext>();

builder.Services.AddGraphQL(options =>
{
    options.EnableMetrics = true;
})
.AddSystemTextJson();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseGraphQLPlayground();
}

app.UseAuthorization();

app.MapControllers();

app.UseGraphQL<ISchema>();

app.Run();
