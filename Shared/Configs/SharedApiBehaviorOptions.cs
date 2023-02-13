using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Shared.Configs;

static class SharedApiOptions
{
    public static IActionResult SetUpInvalidModelStateResponseFactory(ActionContext context)
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
    }
}
