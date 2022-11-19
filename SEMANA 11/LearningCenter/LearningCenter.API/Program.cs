using System.Text.Json.Serialization;
using LearningCenter.Domain;
using LearningCenter.Infraestructure;
using LearningCenter.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Dependency injection
builder.Services.AddScoped<ICategoryDomain,CategoryDomain>();
builder.Services.AddScoped<ICategoryRepository,CategoryRepository>();

var connectionString = builder.Configuration.GetConnectionString("learningCenterConnection");

builder.Services.AddDbContext<LearningCenterDB>(        
    dbContextOptions => dbContextOptions.UseSqlServer("name=ConnectionStrings:DefaultConnection")
    );

builder.Services.AddAutoMapper(
    typeof(LearningCenter.API.Mapper.ModelToResource),
    typeof(LearningCenter.API.Mapper.ResourceToModel)
);
    
var app = builder.Build();

using (var scope = app.Services.CreateScope())

using (var context = scope.ServiceProvider.GetService<LearningCenterDB>())

{

    context.Database.EnsureCreated();

}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();