using Api.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddLogging(loggingBuilder =>
{
    loggingBuilder.AddConsole();
    loggingBuilder.AddDebug();
});

var connectionString = builder.Configuration.GetConnectionString("Docker") ?? default!;

builder.Services.UseDbContextFactory(connectionString);
builder.Services.UseDepencyInjection();

builder.Services.AddCors(options =>
{
    options.AddPolicy("localHostPolicy",
        builder => builder.WithOrigins("http://localhost:4200/", "http://127.0.0.1:4200/")
                          .AllowAnyMethod()
                          .AllowAnyHeader()
                          .AllowCredentials());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("localHostPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();