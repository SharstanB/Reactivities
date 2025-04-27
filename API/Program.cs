using API;
using Application.Activities.Queries;

//using Application.Mediator;
using Application.Repositories;
using Domain.Entities;
using Domain.IRepositories;
using Domain.Mediator;
using Microsoft.EntityFrameworkCore;
using Persistence;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();

builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDBContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<IMediator, Mediator>();

//Register Handlers Automatically
builder.Services.Scan(scan => scan
    .FromAssemblyOf<GetActivitiesList>()// Scan Application assembly
    .AddClasses(classes => classes.AssignableTo(typeof(IRequestHandler<,>)))
    .AsImplementedInterfaces()
    .WithScopedLifetime());

builder.Services.AddScoped<IRepositoty<Activity>, ActivityRepository>();
builder.Services.AddScoped<IRepositoty<City>, CityRepository>();
builder.Services.AddScoped<IRepositoty<Category>, CategoryRepository>();


builder.Services.AddHostedService<DataBaseSeeder>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        policy => policy.WithOrigins("http://localhost:3000", "https://localhost:3000")
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

var app = builder.Build();

app.UseCors("AllowReactApp");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1");
        c.RoutePrefix = string.Empty; // Set Swagger UI at root (http://localhost:5000)
    });
}
app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();
