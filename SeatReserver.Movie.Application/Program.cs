using Autofac.Extensions.DependencyInjection;
using Autofac;
using SeatReserver.Movie.Application.Registeration;
using static VoipService.Api.Configuration.AutofacConfigurationExtensions;
using SeatReserver.Movie.Domain.Entities;
using VoipService.Api.Swagger;
using VoipService.Api.Configuration;
using SeatReserver.Movie.Application.MiddleWares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.RegisterDbContext(builder.Configuration);
builder.Services.RegisterFluentValidation();
builder.Services.RegisterMediatR(typeof(IEntity).Assembly, typeof(Program).Assembly);
builder.Services.RegisterApiVersioning();
builder.Services.RegisterMasteransit(builder.Configuration);

builder.Services.RegisterCustomSwagger(builder.Configuration);


//set autofac
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>
(builder => builder.RegisterModule(new ServiceModules()));

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCustomExceptionHandler();

app.UseAuthorization();
app.UseCustomSwaggerUI();
app.SeedDatabase(builder.Environment);

app.MapControllers();

app.Run();
