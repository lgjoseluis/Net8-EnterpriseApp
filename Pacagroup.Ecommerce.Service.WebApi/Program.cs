using Pacagroup.Ecommerce.Service.WebApi.Modules.Feature;
using Pacagroup.Ecommerce.Service.WebApi.Modules.Injection;
using Pacagroup.Ecommerce.Service.WebApi.Modules.Mapper;
using Pacagroup.Ecommerce.Service.WebApi.Modules.Swagger;
using Pacagroup.Ecommerce.Service.WebApi.Modules.Validator;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMapper();
builder.Services.AddInjections(builder.Configuration);
builder.Services.AddFeatures(builder.Configuration);
builder.Services.AddValidator();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGenCustom();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Ecommerce V1");
    });
}

app.UseCors("policyApiEcommerce");

app.UseAuthorization();

app.MapControllers();

app.Run();
