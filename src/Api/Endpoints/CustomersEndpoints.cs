using Domain.Abstractions;

namespace Api.Endpoints;


public static class CustomersEndpoints
{

    // Metoda rozszerzajaca (Extension Method)
    public static RouteGroupBuilder MapCustomersApi(this RouteGroupBuilder group)
    {
        group.MapGet("", (ICustomerRepository repository) => repository.GetAll());
        group.MapGet("{id}", (int id) => $"Hello Customer {id}");
        group.MapPost("", () => "Created customer");
        group.MapPut("", () => "Updated customer");
        group.MapDelete("", () => "Deleted customer");

        return group;
    }
}
