using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Preparation.API.Data;
using Preparation.API.Data.Repository;
using Preparation.API.Enums;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers(setup =>
            setup.ReturnHttpNotAcceptable = true
        ).AddXmlDataContractSerializerFormatters() // Dodajemo podršku za XML tako da ukoliko klijent to traži u Accept header-u zahteva možemo da serializujemo payload u XML u odgovoru.
        .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.Converters.Add(new DocumentTypeConverter());
            options.JsonSerializerOptions.Converters.Add(new DocumentStatusConverter());
        }
        )
        .ConfigureApiBehaviorOptions(setupAction => // Deo koji se odnosi na podržavanje Problem Details for HTTP APIs
        {
            setupAction.InvalidModelStateResponseFactory = context =>
            {
                // Kreiramo problem details objekat
                ProblemDetailsFactory problemDetailsFactory = context.HttpContext.RequestServices
                    .GetRequiredService<ProblemDetailsFactory>();

                // Prosle?ujemo trenutni kontekst i ModelState, ovo prevodi validacione greške iz ModelState-a u RFC format
                ValidationProblemDetails problemDetails = problemDetailsFactory.CreateValidationProblemDetails(
                    context.HttpContext,
                    context.ModelState);

                // Ubacujemo dodatne podatke
                problemDetails.Detail = "See errors fields for more info.";
                problemDetails.Instance = context.HttpContext.Request.Path;

                // Podrazumevano se sve vra?a kao status 400 BadRequest, to je ok kada nisu u pitanju validacione greške,
                // ako jesu ho?emo da koristimo status 422 UnprocessibleEntity
                // tražimo info koji status kod da koristimo
                ActionExecutingContext? actionExecutiongContext = context as ActionExecutingContext;

                // Proveravamo da li postoji neka greška u ModelState-u, a tako?e proveravamo da li su svi prosle?eni parametri dobro parsirani
                // ako je sve ok parsirano ali postoje greške u validaciji ho?emo da vratimo status 422
                if ((context.ModelState.ErrorCount > 0) &&
                    (actionExecutiongContext?.ActionArguments.Count == context.ActionDescriptor.Parameters.Count))
                {
                    problemDetails.Type = "https://google.com"; // ina?e treba da stoji link ka stranici sa detaljima greške
                    problemDetails.Status = StatusCodes.Status422UnprocessableEntity;
                    problemDetails.Title = "A validation error occurred.";

                    // Sve vra?amo kao UnprocessibleEntity objekat
                    return new UnprocessableEntityObjectResult(problemDetails)
                    {
                        ContentTypes = { "application/problem+json" }
                    };
                }

                // Ukoliko postoji nešto što nije moglo da se parsira ho?emo da vra?amo status 400 kao i do sada
                problemDetails.Status = StatusCodes.Status400BadRequest;
                problemDetails.Title = "An error occurred while parsing the submitted content.";
                return new BadRequestObjectResult(problemDetails)
                {
                    ContentTypes = { "application/problem+json" }
                };
            };
        });

builder.Services.AddDbContext<PreparationDBContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'PreparationDBContext' not found.")));
builder.Services.AddScoped<IDocumentRepository, DocumentRepository>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


//builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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

app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
