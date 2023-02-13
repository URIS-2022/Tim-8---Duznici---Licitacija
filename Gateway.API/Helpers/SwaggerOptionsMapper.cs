using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Gateway.API.Helpers;

public class SwaggerOptionsMapper
{
    public static void AddSwaggerDocs(SwaggerGenOptions options)
    {
        AddAdministrationSwaggerDoc(options);
        AddAuthSwaggerDoc(options);
        AddComplaintSwaggerDoc(options);
        AddBiddingSwaggerDoc(options);
        AddLandlotSwaggerDoc(options);
        AddLeaseSwaggerDoc(options);
        AddLicitationSwaggerDoc(options);
        AddPaymentSwaggerDoc(options);
        AddPersonSwaggerDoc(options);
        AddPreparationsSwaggerDoc(options);
    }
    public static void AddSwaggerEndpoints(SwaggerUIOptions options)
    {
        GenerateEndpoint(options, "Administration");
        GenerateEndpoint(options, "Auth");
        GenerateEndpoint(options, "Bidding");
        GenerateEndpoint(options, "Complaint");
        GenerateEndpoint(options, "Landlot");
        GenerateEndpoint(options, "Lease");
        GenerateEndpoint(options, "Licitation");
        GenerateEndpoint(options, "Payment");
        GenerateEndpoint(options, "Person");
        GenerateEndpoint(options, "Preparation");
    }
    private static void GenerateEndpoint(SwaggerUIOptions options, string serviceName)
    {
        options.SwaggerEndpoint($"/swagger/{serviceName}/swagger.json", $"Gateway {serviceName} Service API");
    }
    private static void AddAdministrationSwaggerDoc(SwaggerGenOptions options)
    {
        options.SwaggerDoc("Administration",
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
    }
    private static void AddAuthSwaggerDoc(SwaggerGenOptions options)
    {
        options.SwaggerDoc("Auth",
            new OpenApiInfo()
            {
                Title = "Auth Service API",
                Version = "v1.0.0",
                Description = "API Gateway acts as a bridge between different microservices and their consumers. It provides a single entry point for external requests and acts as a security barrier, handling authentication, authorization, and rate-limiting. The API Gateway also performs various tasks such as load balancing, request routing, and caching to improve the overall performance of the microservice architecture.",
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
    }
    private static void AddComplaintSwaggerDoc(SwaggerGenOptions options)
    {
        options.SwaggerDoc("Complaint",
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
    }
    private static void AddBiddingSwaggerDoc(SwaggerGenOptions options)
    {
        options.SwaggerDoc("Bidding",
            new OpenApiInfo()
            {
                Title = "Bidding Service API",
                Version = "v1.0.0",
                Description = "The microservice lease refers to a specific module or component that handles the process of bidding an lot or landlot.",
                Contact = new OpenApiContact
                {
                    Name = "Mladen Krsmanović",
                    Email = "krsmanovic.it37.2019@uns.ac.rs",
                    Url = new Uri("https://www.linkedin.com/in/mladen-krsmanovi%C4%87-78060b1bb/")
                },
                License = new OpenApiLicense
                {
                    Name = "MIT licence",
                    Url = new Uri("https://opensource.org/licenses/MIT")
                },
                TermsOfService = new Uri("https://opensource.org/licenses/MIT")
            });
    }
    private static void AddLandlotSwaggerDoc(SwaggerGenOptions options)
    {
        options.SwaggerDoc("Landlot",
            new OpenApiInfo()
            {
                Title = "Landlot Service API",
                Version = "v1.0.0",
                Description = "Landlot.API is a microservice that provides auction lot management services. It allows you to create, update, and delete parcels, as well as generate JSON Web Tokens (JVTs) for use in securing subsequent API requests.",
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
    }
    private static void AddLeaseSwaggerDoc(SwaggerGenOptions options)
    {
        options.SwaggerDoc("Lease",
            new OpenApiInfo()
            {
                Title = "Lease Service API",
                Version = "v1.0.0",
                Description = "The microservice lease refers to a specific module or component that handles the process of leasing an item or resource. It deals with which buyer lease which landlot.",
                Contact = new OpenApiContact
                {
                    Name = "Marko Rakić",
                    Email = "rakic.it6.2019@uns.ac.rs",
                    Url = new Uri("https://www.linkedin.com/in/markorakic/")
                },
                License = new OpenApiLicense
                {
                    Name = "MIT licence",
                    Url = new Uri("https://opensource.org/licenses/MIT")
                },
                TermsOfService = new Uri("https://opensource.org/licenses/MIT")
            });
    }
    private static void AddLicitationSwaggerDoc(SwaggerGenOptions options)
    {
        options.SwaggerDoc("Licitation",
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
    }
    private static void AddPaymentSwaggerDoc(SwaggerGenOptions options)
    {
        options.SwaggerDoc("Payment",
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
    }
    private static void AddPersonSwaggerDoc(SwaggerGenOptions options)
    {
        options.SwaggerDoc("Person",
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
    }
    private static void AddPreparationsSwaggerDoc(SwaggerGenOptions options)
    {
        options.SwaggerDoc("Preparation",
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
    }
}
