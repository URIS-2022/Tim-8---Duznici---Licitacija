using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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
            Title = "Person Service API",
            Version = "v1.0.0",
            Description = "Person.API ​​is a microservice that provides person management services. It allows you to create, update, and delete faces, as well as generate JSON Web Tokens (JVTs) for use in securing subsequent API requests. It is possible to track whether the person is legal or physical, whether he has a contact person and from which address he applied.",
            Contact = new OpenApiContact
            {
                Name = "Andrea Ilić",
                Email = "ilic.it70.2019@uns.ac.rs"
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

WebApplication app = builder.Build();

app.UseCors("CorsPolicy");

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    _ = app.UseSwagger();
    _ = app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    });
}

app.UseHttpsRedirection();

app.UseRouting();

app.MapControllers();

app.Run();