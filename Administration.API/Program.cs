using Administration.API.Data;
using Administration.API.Data.Repository;
using Administration.API.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Shared.Configs;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(setup =>
            setup.ReturnHttpNotAcceptable = true
        ).AddXmlDataContractSerializerFormatters() // Dodajemo podršku za XML tako da ukoliko klijent to traži u Accept header-u zahteva možemo da serializujemo payload u XML u odgovoru.
        .AddJsonOptions(options =>
        options.JsonSerializerOptions.Converters.Add(new DocumentTypeConverter()))
        .ConfigureApiBehaviorOptions(setupAction => // Deo koji se odnosi na podržavanje Problem Details for HTTP APIs
        {
            setupAction.InvalidModelStateResponseFactory = SharedApiOptions.SetUpInvalidModelStateResponseFactory;
        });

builder.Services.AddDbContext<AdministrationDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IMemberRepository, MemberRepository>();
builder.Services.AddScoped<ICommitteeRepository, CommitteeRepository>();
builder.Services.AddScoped<ICommitteeMemberRepository, CommitteeMemberRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1",
        new OpenApiInfo()
        {
            Title = "Administration Service API",
            Version = "v1.0.0",
            Description = "Administration.API is a microservice that works with committees, their members, documents, and yearly plans. It provides management and organization for committees, including tracking member information and handling important documents. The primary focus of this microservice is the yearly plan, which it helps to create, track, and implement. This microservice plays a vital role in ensuring efficient and effective administration for the committees it supports.",
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
