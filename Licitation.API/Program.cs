using Licitation.API.Data;
using Licitation.API.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using Licitation.API.Enums;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(setup =>
            setup.ReturnHttpNotAcceptable = true
        ).AddXmlDataContractSerializerFormatters() // Dodajemo podršku za XML tako da ukoliko klijent to traži u Accept header-u zahteva možemo da serializujemo payload u XML u odgovoru.
        .AddJsonOptions(options =>
        options.JsonSerializerOptions.Converters.Add(new DocumentTypeConverter()))
        .ConfigureApiBehaviorOptions(setupAction => // Deo koji se odnosi na podržavanje Problem Details for HTTP APIs
        {
            setupAction.InvalidModelStateResponseFactory = context =>
            {
                // Kreiramo problem details objekat
                ProblemDetailsFactory problemDetailsFactory = context.HttpContext.RequestServices
                    .GetRequiredService<ProblemDetailsFactory>();

                // Prosleđujemo trenutni kontekst i ModelState, ovo prevodi validacione greške iz ModelState-a u RFC format
                ValidationProblemDetails problemDetails = problemDetailsFactory.CreateValidationProblemDetails(
                    context.HttpContext,
                    context.ModelState);

                // Ubacujemo dodatne podatke
                problemDetails.Detail = "See errors fields for more info.";
                problemDetails.Instance = context.HttpContext.Request.Path;

                // Podrazumevano se sve vraća kao status 400 BadRequest, to je ok kada nisu u pitanju validacione greške,
                // ako jesu hoćemo da koristimo status 422 UnprocessibleEntity
                // tražimo info koji status kod da koristimo
                ActionExecutingContext? actionExecutiongContext = context as ActionExecutingContext;

                // Proveravamo da li postoji neka greška u ModelState-u, a takođe proveravamo da li su svi prosleđeni parametri dobro parsirani
                // ako je sve ok parsirano ali postoje greške u validaciji hoćemo da vratimo status 422
                if ((context.ModelState.ErrorCount > 0) &&
                    (actionExecutiongContext?.ActionArguments.Count == context.ActionDescriptor.Parameters.Count))
                {
                    problemDetails.Type = "https://google.com"; // inače treba da stoji link ka stranici sa detaljima greške
                    problemDetails.Status = StatusCodes.Status422UnprocessableEntity;
                    problemDetails.Title = "A validation error occurred.";

                    // Sve vraćamo kao UnprocessibleEntity objekat
                    return new UnprocessableEntityObjectResult(problemDetails)
                    {
                        ContentTypes = { "application/problem+json" }
                    };
                }

                // Ukoliko postoji nešto što nije moglo da se parsira hoćemo da vraćamo status 400 kao i do sada
                problemDetails.Status = StatusCodes.Status400BadRequest;
                problemDetails.Title = "An error occurred while parsing the submitted content.";
                return new BadRequestObjectResult(problemDetails)
                {
                    ContentTypes = { "application/problem+json" }
                };
            };
        });

builder.Services.AddDbContext<LicitationDBContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<ILicitationRepository, LicitationRepository>();

builder.Services.AddScoped<IDocumentRepository, DocumentRepository>();

builder.Services.AddScoped<ILicitationLandRepository, LicitationLandRepository>();

builder.Services.AddScoped<ILicitationPublicBiddingRepository, LicitationPublicBiddingRepository>();

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
            Title = "Licitation Service API",
            Version = "v1.0.0",
            Description = "Licitation.API is a microservice developed in C# programming language that manages the process of bidding for contracts or tenders. It provides a platform for organizations to create, manage, and participate in licitations. The service generates a JSON token that serves as a secure means of identifying and accessing the information related to a specific licitation process.",
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

app.MapControllers();

app.Run();
