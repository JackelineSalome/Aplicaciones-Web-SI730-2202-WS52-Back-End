using System.Text.Json.Serialization;
using LearningCenter.API.Middleware;
using LearningCenter.Domain;
using LearningCenter.Infraestructure;
using LearningCenter.Infraestructure.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Dependency injection
builder.Services.AddScoped<ICategoryDomain,CategoryDomain>();
builder.Services.AddScoped<IUserDomain,UserDomain>();
builder.Services.AddScoped<ICategoryRepository,CategoryRepository>();
builder.Services.AddScoped<IUserRepository,UserRepository>();
builder.Services.AddScoped<ITokenDomain,TokenDomain>();
builder.Services.AddScoped<IEncryptDomain,EncryptDomain>();


var connectionString = builder.Configuration.GetConnectionString("learningCenterConnection");

builder.Services.AddDbContext<LearningCenterDB>(        
    dbContextOptions => dbContextOptions.UseSqlServer("name=ConnectionStrings:Server=SQLEXPRESS; Uid=admin ;Pwd=123456&;Database=LearningCenterDB")
    );

builder.Services.AddAutoMapper(
    typeof(LearningCenter.API.Mapper.ModelToResource),
    typeof(LearningCenter.API.Mapper.ResourceToModel)
);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
});
builder.Services.AddApplicationInsightsTelemetry();

//var  MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

/*builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy  =>
        {
            policy.WithOrigins("http://example.com",
                "http://www.contoso.com");
        });
});*/
    
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

//app.UseCors(MyAllowSpecificOrigins);
app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseMiddleware<JwtMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();