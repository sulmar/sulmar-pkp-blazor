using Domain.Abstractions;
using Domain.Models;

namespace Infrastructure;

public class FakeCustomerRepository : ICustomerRepository
{
    public List<Customer> GetAll()
    {
        return new List<Customer>
        {
            new Customer { Id = 1, Name = "Lorem", Email="info@lorem.pl" },
            new Customer { Id = 2, Name = "Ipsum", Email="info@ipsum.pl" },
            new Customer { Id = 3, Name = "Acme", Email="office@domain.com" },
            new Customer { Id = 4, Name = "Example", Email="info@example.com" },
            new Customer { Id = 5, Name = "Pkp Informatyka", Email="info@pkp.pl" },
        };
    }
}
