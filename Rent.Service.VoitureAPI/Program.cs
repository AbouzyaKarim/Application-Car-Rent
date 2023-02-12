using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rent.Service.VoitureAPI;
using Rent.Service.VoitureAPI.DbContexts;
using Rent.Service.VoitureAPI.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//DBcontext => sql server with connection
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
//Guichet unique
builder.Services.AddSingleton(mapper);


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//adding repo to services
//Add Scope
builder.Services.AddScoped<IVoitureRepository, VoitureRepository>();


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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
