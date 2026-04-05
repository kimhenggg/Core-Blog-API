using MongoDB.Driver;
using BlogApi.Services;

var builder = WebApplication.CreateBuilder(args);

// 1. read config
var connectionString = builder.Configuration["MongoDB:ConnectionString"];
var databaseName = builder.Configuration["MongoDB:DatabaseName"];

// 2. register MongoDB
builder.Services.AddSingleton<IMongoClient>(new MongoClient(connectionString));
builder.Services.AddSingleton(sp =>
    sp.GetRequiredService<IMongoClient>().GetDatabase(databaseName));

// 3. register BlogService  ← this is what you are missing
builder.Services.AddSingleton<BlogService>();

builder.Services.AddControllers();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapControllers();
app.Run();