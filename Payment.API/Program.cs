using Microsoft.OpenApi.Models;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Payment.API.Data;
using Microsoft.EntityFrameworkCore;
using Payment.API.Data.Repository;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(setup =>
            setup.ReturnHttpNotAcceptable = true
        ).AddXmlDataContractSerializerFormatters() // Dodajemo podršku za XML tako da ukoliko klijent to traži u Accept header-u zahteva možemo da serializujemo payload u XML u odgovoru.
                                                   //.AddJsonOptions(options =>
                                                   //options.JsonSerializerOptions.Converters.Add(new SystemUserRoleConverter()))
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

builder.Services.AddDbContext<PaymentDBContext>(options =>
       options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddControllers();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();

builder.Services.AddScoped<IPaymentWarrantRepository, PaymentWarrantRepository>();

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

    //options.IncludeXmlComments(xmlCommentsPath);

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
