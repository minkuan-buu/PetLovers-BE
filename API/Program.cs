using Data.Entities;
using Azure.Identity;
using Data.Repositories.UserRepo;
using Data.Repositories.PostRepo;
using Data.Repositories.CommentRepo;
using Business.Services.PostServices;
using Business.Services.CommentServices;
using Business.Services.UserServices;
using Data.Repositories.UserRepo;
using Microsoft.Extensions.Configuration.AzureKeyVault;
using Azure.Security.KeyVault.Secrets;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using Microsoft.EntityFrameworkCore;
using Business.Services.SecretServices;

var builder = WebApplication.CreateBuilder(args);

var keyVaultEndpoint = new Uri(Environment.GetEnvironmentVariable("ConnectionString"));
builder.Configuration.AddAzureKeyVault(keyVaultEndpoint, new DefaultAzureCredential());

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Connect Database 
//builder.Services.AddDbContext<PetLoversDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

/*if (builder.Environment.IsDevelopment())
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
}*/

builder.Services.AddDbContext<PetLoversDbContext>(option => option.UseSqlServer(SecretService.GetConnectionString()));

// Subcribe service
//builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<IPostServices, PostServices>();
builder.Services.AddScoped<IEmailServices, EmailServices>();
builder.Services.AddScoped<ICommentServices, CommentServices>();


//Subcribe repository
//builder.Services.AddTransient<ICategoryRepo, CategoryRepo>();
builder.Services.AddTransient<IUserRepo, UserRepo>();
builder.Services.AddTransient<IPostRepo, PostRepo>();
builder.Services.AddTransient<IOTPRepo, OTPRepo>();
builder.Services.AddTransient<ICommentRepo, CommentRepo>();




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
