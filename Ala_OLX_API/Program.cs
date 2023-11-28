using Ala_OLX_API.Middlewares;
using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using DataAccess.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OLX_Ala.Data;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
string connStr = builder.Configuration.GetConnectionString("LocalDb")!;

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x=>x.JsonSerializerOptions.ReferenceHandler=ReferenceHandler.IgnoreCycles);

// configure dependencies
builder.Services.AddDbContext<AlaOlxDbContext>(opts => opts.UseSqlServer(connStr));

builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<AlaOlxDbContext>().AddDefaultTokenProviders();

// configure services
builder.Services.AddScoped<IAnnouncementsServices, AnnouncementsService>();
builder.Services.AddScoped<IAccountsService, AccountsService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
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

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
