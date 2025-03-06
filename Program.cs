using api_filmes_senai.Context;
using api_filmes_senai.Interfaces;
using api_filmes_senai.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Adiciona o contexto do banco de dados (exemplo com SQL Server)
builder.Services.AddDbContext<Filmes_Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Adicionar o repositório e a interface ao continuar a injeção de dependência 
builder.Services.AddScoped<IGeneroRepository, GeneroRepository>();
builder.Services.AddScoped<IFilmeRepository, FilmeRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
// Adicionar o serviço de Controllers
builder.Services.AddControllers();

builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = "JwtBearer";
    options.DefaultAuthenticateScheme = "JwtBearer";


})
   .AddJwtBearer("JwtBearer", options =>
   {
       options.TokenValidationParameters = new TokenValidationParameters
       {
           
           ValidateIssuer = true,

           
           ValidateAudience = true,

     
           ValidateLifetime = true,

           IssuerSigningKey = new SymmetricSecurityKey
           (System.Text.Encoding.UTF8.GetBytes("filmes-chave-autenticacao-webapi-dev")),

           
           ClockSkew = TimeSpan.FromMinutes(5),

           
           ValidIssuer = "api_filmes_senai",
            
           ValidAudience = "api_filmes_senai"

       };
   });

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API de Filmes",
        Description = "Aplicacao para gerenciamento de filmes e Genero",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Isaac Borges Olivera",
            Url = new Uri("https://example.com/contact")
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
        }
    });
});







var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger(options =>
    {
        options.SerializeAsV2 = true;
    });

    app.UseSwaggerUI(options => // UseSwaggerUI is called only in Development.
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}
// Adicionar o Mapeamento dos Controllers
app.MapControllers();

app.UseAuthentication();

app.UseAuthorization();

app.Run();

// Adiciona o contexto do banco de dados (exemplo com SQL Server)
builder.Services.AddDbContext<Filmes_Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

