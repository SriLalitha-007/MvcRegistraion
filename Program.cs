//using MvcRegistraion.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MvcRegistraion.Services;
using MvcRegistraion.Models;
using MvcRegistraion;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<RegistrationFormDatabaseSettings>(builder.Configuration.GetSection("RegistrationFormDatabase"));

builder.Services.AddSingleton<RegisterServices>();

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<EmailService>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();



// Startup a custom class create by me 
var startUp = new Startup();
startUp.ConfigureRoutes(app);

app.Run();
