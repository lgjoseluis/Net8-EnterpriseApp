using Pacagroup.Ecommerce.Persistence;
using Pacagroup.Ecommerce.Application.UseCases;
using Pacagroup.Ecommerce.Service.WebApi.Modules.Authentication;
using Pacagroup.Ecommerce.Service.WebApi.Modules.Feature;
using Pacagroup.Ecommerce.Service.WebApi.Modules.Injection;
using Pacagroup.Ecommerce.Service.WebApi.Modules.Mapper;
using Pacagroup.Ecommerce.Service.WebApi.Modules.Swagger;
using Pacagroup.Ecommerce.Service.WebApi.Modules.Validator;
using WatchDog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMapper();
builder.Services.AddInjections(builder.Configuration);
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddFeatures(builder.Configuration);
builder.Services.AddValidator();
builder.Services.AddAuthenticationJwt(builder.Configuration);
builder.Services.AddWatchDog(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGenCustom();

builder.Logging.AddWatchDogLogger();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Ecommerce V1");
    });
}

app.UseWatchDogExceptionLogger();

app.UseCors("policyApiEcommerce");
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.UseWatchDog(conf => {
    conf.WatchPageUsername = builder.Configuration.GetSection("WatchDog:WatchPageUsername").Value;
    conf.WatchPagePassword = builder.Configuration.GetSection("WatchDog:WatchPagePassword").Value;
});

app.Run();
