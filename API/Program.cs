using Data.Entities;
using Azure.Identity;
using Data.Repositories.UserRepo;
using Business.Services.UserServices;
using Data.Repositories.UserRepo;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.AzureKeyVault;
using Azure.Security.KeyVault.Secrets;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Connect Database 
//builder.Services.AddDbContext<PetLoversDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

if (builder.Environment.IsDevelopment())
{
    var keyVaultURL = builder.Configuration.GetSection("KeyVault:KeyVaultURL"); 
    var keyVaultClientId = builder.Configuration.GetSection("KeyVault:ClientId"); 
    var keyVaultClientSecret = builder.Configuration.GetSection("KeyVault:ClientSecret"); 
    var keyVaultDirectoryId = builder.Configuration.GetSection("KeyVault:DirectoryId");

    var credential = new ClientSecretCredential(keyVaultDirectoryId.Value!.ToString(), keyVaultClientId.Value!.ToString(), keyVaultClientSecret.Value!.ToString());
    builder.Configuration.AddAzureKeyVault(keyVaultURL.Value!.ToString(), keyVaultClientId.Value!.ToString(), keyVaultClientSecret.Value!.ToString(), new DefaultKeyVaultSecretManager());

    var client = new SecretClient(new Uri(keyVaultURL.Value!.ToString()), credential);
    builder.Services.AddDbContext<PetLoversDbContext>(options =>
    { 
        options.UseSqlServer(client.GetSecret("PetLoversDatabase").Value.Value.ToString());
    });
}

// Subcribe service
//builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IUserServices, UserServices>();

//Subcribe repository
//builder.Services.AddTransient<ICategoryRepo, CategoryRepo>();
builder.Services.AddTransient<IUserRepo, UserRepo>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
