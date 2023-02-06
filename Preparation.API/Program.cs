using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1",
        new OpenApiInfo()
        {
            Title = "Preparation Service API",
            Version = "v1.0.0",
            Description = "Preparation.API is a microservice that provides user management and JWT authentication services. It allows you to create, update, and delete users, as well as authenticate users and generate JSON Web Tokens (JWT) for use in securing subsequent API requests. This microservice is crucial in ensuring the security and access control of the system.",
            Contact = new OpenApiContact
            {
                Name = "Dejan Petrov",
                Email = "petrov.it40.2019@uns.ac.rs",
                Url = new Uri("https://draganovik.com")
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
