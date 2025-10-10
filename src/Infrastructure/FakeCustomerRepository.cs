using Domain.Abstractions;
using Domain.Models;

namespace Infrastructure;

public class FakeCustomerRepository : ICustomerRepository
{
    private List<Customer> customers;

    public FakeCustomerRepository()
    {
        customers = new List<Customer>
        {
            new Customer { Id = 1, Name = "Lorem", Email="info@lorem.pl" },
            new Customer { Id = 2, Name = "Ipsum", Email="info@ipsum.pl" },
            new Customer { Id = 3, Name = "Acme", Email="office@domain.com" },
            new Customer { Id = 4, Name = "Example", Email="info@example.com" },
            new Customer { Id = 5, Name = "Pkp Informatyka", Email="info@pkp.pl" },
        };
    }

    public void Add(Customer customer)
    {
        int id = customers.Max(c => c.Id);
        id++;
        customer.Id = id;

        customers.Add(customer);
    }

    public List<Customer> GetAll()
    {
        // Thread.Sleep(5000); // Symulacja opoznienia

        return customers;
    }

    public Customer GetById(int id)
    {
        // LINQ 
        return customers.Where(customer => customer.Id == id).FirstOrDefault();
    }

    /*
    public Customer GetById(int id)
    {

        // SQL: SELECT * FROM customers WHERE id = @id
        foreach (var customer in customers)
        {
            if (customer.Id == id)
            {
                return customer;
            }
        }
        return null;
    }

    */


}
