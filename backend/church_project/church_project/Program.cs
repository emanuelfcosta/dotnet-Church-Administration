using System.Text.Json.Serialization;
using church_project.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddTransient<SisChurchContextFactory>();
builder.Services.AddTransient(opt =>
    opt.GetService<SisChurchContextFactory>()!.CreateDbContext());

builder.Services.AddControllers().AddJsonOptions(opt =>
    opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.RoutePrefix = String.Empty;
        options.SwaggerEndpoint("/swagger/v1/swagger.json",
            "ChuchProject.Api");
    });
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

