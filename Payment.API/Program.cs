using Microsoft.OpenApi.Models;
using System.Reflection;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1",
        new OpenApiInfo()
        {
            Title = "Payment Service API",
            Version = "v1.0.0",
            Description = "Payment.API is a microservice implemented in C# that facilitates the process of making and receiving payments. The service allows for the creation and management of payment transactions and provides secure access to payment information through the generation of a JSON token. This token can be used to authenticate and authorize payment transactions, ensuring that sensitive financial information is protected.",
            Contact = new OpenApiContact
            {
                Name = "Aleksandra Vrekić",
                Email = "vrekic.it25.2019@uns.ac.rs"
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

    //  options.IncludeXmlComments(xmlCommentsPath);

});

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    _ = app.UseSwagger();
    _ = app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    });
}

app.MapControllers();

app.Run();
