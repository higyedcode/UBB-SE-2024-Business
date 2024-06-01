using Backend.Models;
using Backend.Repositories;
using Backend.Services;
using Iss.Database;
using Iss.Repository;
using Iss.Service;
using Iss.Services;
using Microsoft.EntityFrameworkCore;
using RestApi_ISS.Repository;
using RestApi_ISS.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddScoped<IAdAccountRepository, AdAccountRepository>();
builder.Services.AddScoped<IAdAccountService, AdAccountService>();

builder.Services.AddScoped<IAdRepository, AdRepository>();
builder.Services.AddScoped<IAdService, AdService>();

builder.Services.AddScoped<IAdSetRepository, AdSetRepository>();
builder.Services.AddScoped<IAdSetService, AdSetService>();

builder.Services.AddScoped<ICampaignRepository, CampaignRepository>();
builder.Services.AddScoped<ICampaignService, CampaignService>();

builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<InterfaceBankAccountService, BankAccountService>();

builder.Services.AddScoped<DataEncryptionService>();

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddScoped<ReviewRepository, ReviewRepository>();
builder.Services.AddScoped<IServiceReview, ReviewService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
