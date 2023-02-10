using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Preparation.API.Data;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddDbContext<PreparationDBContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder.WithOrigins("https://localhost:7000")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials());
});
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1",
        new OpenApiInfo()
        {
            Title = "Preparation Service API",
            Version = "v1.0.0",
            Description = "Preparation.API is a microservice that provides announcements and documents management. It allows you to create, update and delete documents as well as announcements. This microservice is the key in collecting and providing valid documents and preparing announcements based on those documents for the further licitation process.",
            Contact = new OpenApiContact
            {
                Name = "Dejan Petrov",
                Email = "petrov.it40.2019@uns.ac.rs",
                Url = new Uri("http://ftn.uns.ac.rs/691618389/fakultet-tehnickih-nauka")
            },
            License = new OpenApiLicense
            {
                Name = "MIT licence",
                Url = new Uri("https://opensource.org/licenses/MIT")
            },
            TermsOfService = new Uri("https://opensource.org/licenses/MIT")
        });

    string xmlComments = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

    string xmlCommentsPath = Path.Combine(AppContext.BaseDirectory, xmlComments);

    options.IncludeXmlComments(xmlCommentsPath);
});

var app = builder.Build();

app.UseCors("CorsPolicy");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
