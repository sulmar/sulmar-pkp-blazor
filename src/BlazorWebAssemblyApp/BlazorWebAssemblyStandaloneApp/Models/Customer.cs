namespace BlazorWebAssemblyStandaloneApp.Models;

public class Customer
{
    public int Id { get; set; }

    public string Name { get; set; }

    public Address WorkAddress { get; set; }

    public string Email { get; set; }
}
