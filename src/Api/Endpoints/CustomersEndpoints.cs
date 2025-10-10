using Domain.Abstractions;
using Domain.Models;

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
        group.MapGet("", (ICustomerRepository repository) => repository.GetAll());
        group.MapGet("{id}", (int id, ICustomerRepository repository) => repository.GetById(id))
            .WithName("GetCustomerById");

        group.MapPost("", (Customer customer, ICustomerRepository repository) =>
        {

            repository.Add(customer);

            // return Results.Created($"api/customers/{customer.Id}", customer);

            return Results.CreatedAtRoute("GetCustomerById", new { customer.Id }, customer);
        });

        group.MapPut("", () => "Updated customer");
        group.MapDelete("", () => "Deleted customer");

        return group;
    }
}
