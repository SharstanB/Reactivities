using API;
using Application.Activities.Command;
using Application.Repositories;
using Application.Validators.Activities;
using Domain.IRepositories;
using Domain.Mediator;
using Domain.Services.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.IdentityEnitities;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();

builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDBContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddIdentityApiEndpoints<AppUser>(options =>
{
    options.User.RequireUniqueEmail = true;
})
.AddRoles<IdentityRole>()
.AddEntityFrameworkStores<AppDBContext>();

builder.Services.ConfigureApplicationCookie(options =>
{
    // Cookie settings
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

    options.LoginPath = "/Identity/Account/Login";
    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
    options.SlidingExpiration = true;
});

builder.Services.AddValidatorsFromAssemblyContaining<CreateActivityValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<EditActivityValidator>();


builder.Services.AddScoped<IMediator, Mediator>();


builder.Services.Scan(scan => scan 
    .FromAssemblyOf<CreateActivity>()// Scan Application assembly
    .AddClasses(classes => classes.AssignableTo(typeof(IRequestHandler<,>)))
    .AsImplementedInterfaces()
    .WithScopedLifetime());

//builder.Services.AddScoped<IPipelineBehavior<CreateActivity.Command, OperationResult<Guid>>, ValidationBehavior<CreateActivity.Command, OperationResult<Guid>>>();

builder.Services.AddTransient<ExceptionMiddleware>();


builder.Services.Scan(scan => scan
    .FromAssemblyOf<ActivityRepository>() 
    .AddClasses(classes => classes.AssignableTo(typeof(IRepositoty<>)))
    .AsImplementedInterfaces()
    .WithScopedLifetime());

builder.Services.AddHostedService<DataBaseSeeder>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        policy => policy.WithOrigins("http://localhost:3000", "https://localhost:3000")
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

builder.Services.AddAuthorization();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapGroup("api").MapIdentityApi<AppUser>();

app.Run();
