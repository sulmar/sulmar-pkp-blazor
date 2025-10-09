using Domain.Models;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace MudBlazorWebAssemblyApp.Client.Services;

public interface ICustomerService
{
    Task<List<Customer>?> GetAllAsync();
}

public class CustomerService : ICustomerService
{
    private HttpClient _http;

    public CustomerService(HttpClient http)
    {
        _http = http;
    }

    public Task<List<Customer>?> GetAllAsync()
    {
        return _http.GetFromJsonAsync<List<Customer>>("api/customers");
    }
}
