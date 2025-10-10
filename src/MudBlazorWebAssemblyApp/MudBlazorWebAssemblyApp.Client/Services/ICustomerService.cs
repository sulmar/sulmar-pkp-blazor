using Domain.Models;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace MudBlazorWebAssemblyApp.Client.Services;

public interface ICustomerService
{
    Task<List<Customer>?> GetAllAsync();
    Task<Customer?> GetByIdAsync(int id);
    Task AddAsync(Customer customer);
}

// Primary Constructor
public class CustomerService(HttpClient _http) : ICustomerService
{
    public Task AddAsync(Customer customer)
    {
       return _http.PostAsJsonAsync("api/customers", customer);
    }

    public Task<List<Customer>?> GetAllAsync() => _http.GetFromJsonAsync<List<Customer>>("api/customers");
    public Task<Customer?> GetByIdAsync(int id) => _http.GetFromJsonAsync<Customer>($"api/customers/{id}");
}
