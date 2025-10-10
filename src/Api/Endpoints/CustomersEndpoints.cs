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
        group.MapGet("{id}", (int id, ICustomerRepository repository) => repository.GetById(id));

        group.MapPost("", (Customer customer, ICustomerRepository repository) => repository.Add(customer));

        group.MapPut("", () => "Updated customer");
        group.MapDelete("", () => "Deleted customer");

        return group;
    }
}
