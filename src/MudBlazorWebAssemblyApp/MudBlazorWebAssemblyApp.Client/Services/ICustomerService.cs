using Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace MudBlazorWebAssemblyApp.Client.Services;

public interface ICustomerService
{
    Task<List<Customer>?> GetAllAsync();
    Task<Customer?> GetByIdAsync(int id);
    Task AddAsync(Customer customer);
    Task DeleteAsync(int id);
}

// Primary Constructor
public class CustomerService(HttpClient _http) : ICustomerService
{
    public async Task AddAsync(Customer customer)
    {
        var response = await _http.PostAsJsonAsync("api/customers", customer);

        Customer? result = await response.Content.ReadFromJsonAsync<Customer>();

        customer.Id = result.Id;
    }

    public async Task DeleteAsync(int id)
    {
        await _http.DeleteAsync($"api/customers/{id}");
    }

    public Task<List<Customer>?> GetAllAsync() => _http.GetFromJsonAsync<List<Customer>>("api/customers");
    public Task<Customer?> GetByIdAsync(int id) => _http.GetFromJsonAsync<Customer>($"api/customers/{id}");
}
