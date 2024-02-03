using MainProject.Components;
using MainProject.DAL;
using MainProject.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var conexion = builder.Configuration.GetConnectionString("conexion");
builder.Services.AddDbContext<Context>(options =>
    options.UseSqlite(conexion));

builder.Services.AddScoped<PrioridadesService>();
builder.Services.AddScoped<ClientesService>();
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
