using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using TransitoDB.Infrastructure.Data;
using TransitoDB.Presentation.Security;

var builder = WebApplication.CreateBuilder(args);

// === Detectar dónde está appsettings.json ===
var contentRoot = builder.Environment.ContentRootPath;
var basePath =
    File.Exists(Path.Combine(contentRoot, "appsettings.json")) ? contentRoot :
    File.Exists(Path.Combine(contentRoot, "Presentation", "appsettings.json")) ? Path.Combine(contentRoot, "Presentation") :
    AppContext.BaseDirectory;

builder.Configuration
    .SetBasePath(basePath)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

builder.Services.AddControllers();

// DbContext
var cs = builder.Configuration.GetConnectionString("DefaultConnection")
         ?? throw new InvalidOperationException("Falta ConnectionStrings:DefaultConnection");
builder.Services.AddDbContext<TransitoDbContext>(opt =>
{
    opt.UseSqlServer(cs);
    if (builder.Environment.IsDevelopment())
    {
        opt.EnableDetailedErrors();
        opt.EnableSensitiveDataLogging();
    }
});

// === AUTH Basic ===
builder.Services.AddAuthentication(o =>
{
    o.DefaultAuthenticateScheme = BasicAuthenticationHandler.SchemeName;
    o.DefaultChallengeScheme = BasicAuthenticationHandler.SchemeName;
})
.AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>(
    BasicAuthenticationHandler.SchemeName, null);

builder.Services.AddAuthorization();

// Swagger con Basic
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Transito API", Version = "v1" });

    c.AddSecurityDefinition("basic", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "basic",
        In = ParameterLocation.Header,
        Description = "Autenticación básica. Usuario = Documento del empleado."
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { new OpenApiSecurityScheme { Reference = new OpenApiReference { Type=ReferenceType.SecurityScheme, Id="basic"} }, new string[]{} }
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();  // <- antes de Authorization
app.UseAuthorization();

app.MapControllers();

// Evita 404 en raíz
app.MapGet("/", () => "Transito API ✔  - usa /swagger");
app.MapGet("/health", () => new { ok = true, env = app.Environment.EnvironmentName });

app.Run();
