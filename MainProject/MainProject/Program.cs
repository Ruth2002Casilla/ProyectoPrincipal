using MainProject.Components;
using MainProject.DAL;
using MainProject.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Configura las opciones del contexto de la base de datos
builder.Services.AddDbContext<Context>(options =>{
    // Obtén la cadena de conexión desde appsettings.json
    var connectionString = builder.Configuration.GetConnectionString("conexion");
    options.UseSqlServer(connectionString);
});

builder.Services.AddScoped<TicketsService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
