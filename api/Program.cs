using infrastructure;
using infrastructure.repositories;
using service;

var builder = WebApplication.CreateBuilder(args);

if (builder.Environment.IsDevelopment())
{
    Console.WriteLine(Utilities.devConnectionString);
    Console.WriteLine(Utilities.connectionString);

    builder.Services.AddNpgsqlDataSource(Utilities.devConnectionString,
         dataSourceBuilder => dataSourceBuilder.EnableParameterLogging());
}

builder.Services.AddNpgsqlDataSource(Utilities.connectionString);






builder.Services.AddSingleton<HistoryService>();
builder.Services.AddSingleton<HistoryRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

    app.UseSwagger();
    app.UseSwaggerUI();


app.UseCors(options => {
    options.SetIsOriginAllowed(origin => true)
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials();
});

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseHttpsRedirection();

app.Run();