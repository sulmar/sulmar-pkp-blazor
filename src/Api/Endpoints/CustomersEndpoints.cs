using Domain.Abstractions;
using Domain.Models;
using System.Security.Claims;

namespace Api.Endpoints;


public static class CustomersEndpoints
{

    // REST API
    // GET - pobierz
    // POST - utworz
    // PUT/PATCH - zamien/zmien
    // DELETE - usun

    // Metoda rozszerzajaca (Extension Method)
    public static RouteGroupBuilder MapCustomersApi(this RouteGroupBuilder group)
    {
        group.MapGet("", (ICustomerRepository repository) => repository.GetAll())
             .RequireAuthorization(c => c.RequireRole("dev").RequireClaim("phonenumber"));

        group.MapGet("{id}", (int id, ICustomerRepository repository) => repository.GetById(id))
            .WithName("GetCustomerById")
            .RequireAuthorization("VIP"); // wymagamy polityki VIP

        group.MapPost("", (Customer customer, ICustomerRepository repository, HttpContext httpContext) =>
        {
            // TODO: Dodac walidacje za pomoca CustomerValidator

            repository.Add(customer);

            // return Results.Created($"api/customers/{customer.Id}", customer);

            if (httpContext.User.IsInRole("dev"))
            {

            }

            if (httpContext.User.HasClaim(c=>c.Type == "phonenumber"))
            {
                var phoneNumber = httpContext.User.FindFirstValue("phonenumber");

                Console.WriteLine($"send sms to {phoneNumber}");
            }

            return Results.CreatedAtRoute("GetCustomerById", new { customer.Id }, customer);
        });

        group.MapPut("", () => "Updated customer");
        group.MapDelete("{id}", (int id, ICustomerRepository repository) => repository.Remove(id));

        return group;
    }
}
