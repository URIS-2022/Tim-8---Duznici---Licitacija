﻿using Complaint.API.Data;
using Complaint.API.Data.Repository;
using Complaint.API.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(setup =>
            setup.ReturnHttpNotAcceptable = true
        ).AddXmlDataContractSerializerFormatters() // Dodajemo podršku za XML tako da ukoliko klijent to traži u Accept header-u zahteva možemo da serializujemo payload u XML u odgovoru.
        .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.Converters.Add(new ComplaintTypeConverter());
            options.JsonSerializerOptions.Converters.Add(new ComplaintActionConverter());
            options.JsonSerializerOptions.Converters.Add(new ComplaintStatusConverter());
        }
        )
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

builder.Services.AddDbContext<ComplaintDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'ComplaintDbContext' not found.")));
builder.Services.AddScoped<IComplaintRepository, ComplaintRepository>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//builder.Services.AddScoped<IRepository, Repository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1",
        new OpenApiInfo()
        {
            Title = "Complaint Service API",
            Version = "v1.0.0",
            Description = "Complaint.API is a microservice that manages the creation and management of buyer complaints for public bidding and announcements. It allows for the creation and tracking of complaints, as well as providing necessary information for resolution. This microservice plays a crucial role in ensuring fair and transparent resolution of complaints in the public bidding and announcement process.",
            Contact = new OpenApiContact
            {
                Name = "Sandra Stojanov",
                Email = "stojanov.it78.2019@uns.ac.rs",
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

app.UseHttpsRedirection();

app.Run();
