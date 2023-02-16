using Auth.API.Data;
using Auth.API.Data.Repository;
using Auth.API.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Shared.Configs;
using System.Reflection;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(setup =>
            setup.ReturnHttpNotAcceptable = true
        ).AddXmlDataContractSerializerFormatters() // Dodajemo podršku za XML tako da ukoliko klijent to traži u Accept header-u zahteva možemo da serializujemo payload u XML u odgovoru.
        .AddJsonOptions(options =>
        options.JsonSerializerOptions.Converters.Add(new SystemUserRoleConverter()))
        .ConfigureApiBehaviorOptions(setupAction => // Deo koji se odnosi na podržavanje Problem Details for HTTP APIs
        {
            setupAction.InvalidModelStateResponseFactory = SharedApiOptions.SetUpInvalidModelStateResponseFactory;
        });

builder.Services.AddDbContext<AuthDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<ISystemUserRepository, SystemUserRepository>();

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
            Title = "Auth Service API",
            Version = "v1.0.0",
            Description = "Auth.API is a microservice that provides user management and JWT authentication services. It allows you to create, update, and delete users, as well as authenticate users and generate JSON Web Tokens (JWT) for use in securing subsequent API requests. This microservice is crucial in ensuring the security and access control of the system.",
            Contact = new OpenApiContact
            {
                Name = "Mladen Draganović",
                Email = "draganovic.it68.2019@uns.ac.rs",
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

app.MapControllers();

app.UseHttpsRedirection();

app.Run();
