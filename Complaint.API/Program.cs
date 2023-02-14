using Complaint.API.Data;
using Complaint.API.Data.Repository;
using Complaint.API.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Shared.Configs;
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
            setupAction.InvalidModelStateResponseFactory = SharedApiOptions.SetUpInvalidModelStateResponseFactory;
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
