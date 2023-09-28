using Data.Entities;
using Data.Repositories.UserRepo;
using Data.Repositories.PostRepo;
using Business.Services.PostServices;
using Business.Services.UserServices;
using Data.Repositories.UserRepo;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Connect Database 
builder.Services.AddDbContext<PetLoversDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Subcribe service
//builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<IPostServices, PostServices>();


//Subcribe repository
//builder.Services.AddTransient<ICategoryRepo, CategoryRepo>();
builder.Services.AddTransient<IUserRepo, UserRepo>();
builder.Services.AddTransient<IPostRepo, PostRepo>();




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
