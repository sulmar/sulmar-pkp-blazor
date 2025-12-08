using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Sakila.Infrastructure;

string connectionString = "Server=(localdb)\\efcore-demo;Database=sakila;Trusted_Connection=True;";

// var connectionString = builder.Configuration.GetConnectionString("SakilaConnection"); 

// 0. Przygotowanie parametrów polaczenia do bazy danych
var options = new DbContextOptionsBuilder<SakilaContext>()
    .UseSqlServer(connectionString)
    .EnableSensitiveDataLogging()
    .LogTo(Console.WriteLine, LogLevel.Information)
    .Options;

// 1. Utworzenie instancji DbContext
SakilaContext context = new SakilaContext(options);

// Change Tracker (sledzenie zmian)

var customer = await context.Customers.FindAsync(3);

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine(context.Entry(customer).State);
Console.WriteLine(context.Entry(customer).Property(p => p.FirstName).IsModified);
Console.WriteLine(context.Entry(customer).Property(p => p.LastName).IsModified);
Console.ResetColor();

Console.WriteLine(customer.FirstName);
Console.WriteLine(customer.LastName);

customer.FirstName = customer.FirstName.ToLower();
customer.LastName = customer.LastName.ToLower();

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine(context.Entry(customer).State);
Console.WriteLine(context.Entry(customer).Property(p => p.FirstName).IsModified);
Console.WriteLine(context.Entry(customer).Property(p => p.LastName).IsModified);
Console.ResetColor();

Console.WriteLine(customer.FirstName);
Console.WriteLine(customer.LastName);


await context.SaveChangesAsync();

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine(context.Entry(customer).State);
Console.WriteLine(context.Entry(customer).Property(p => p.FirstName).IsModified);
Console.WriteLine(context.Entry(customer).Property(p => p.LastName).IsModified);
Console.ResetColor();

// REST API
// json:
/*
{
    "firstname": "a",
    "lastname" : "b",
    "store": {
        "storeId": 1
    }

}

*/

 Store store = await context.Stores.FindAsync(1);
//Store store = new Store { StoreId = 1 }; // istniejacy sklep
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine(context.Entry(customer).State);
Console.WriteLine(context.Entry(store).State);
Console.ResetColor();

Customer newCustomer = new Customer {  FirstName = "a", LastName = "b", Store = store };
context.Customers.Add(newCustomer);

// Reczne zarzadzanie stanem obiektu
context.Entry(store).State = EntityState.Unchanged;

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine(context.Entry(newCustomer).State);
Console.WriteLine(context.Entry(store).State);
Console.ResetColor();




await context.SaveChangesAsync();
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine(context.Entry(customer).State);
Console.WriteLine(context.Entry(store).State);
Console.ResetColor();


// Wspolbieznosc

// UPDATE Customer SET firstname = 'b' WHERE CustomerId = 1
// AND firstname = 'a' AND lastname = 's' - concurrency token

// UPDATE Customer SET firstname = 'b' WHERE CustomerId = 1 AND rowversion = v3 - concurrency token z uzyciem rowversion

/*
 
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    foreach (var entityType in modelBuilder.Model.GetEntityTypes())
    {
        // pomijamy encje bez klucza (np. widoki)
        if (entityType.FindPrimaryKey() == null)
            continue;

        var builder = modelBuilder.Entity(entityType.ClrType);

        builder
            .Property<byte[]>("RowVersion")   // shadow property
            .IsRowVersion()                   // ustawia rowversion + concurrency token
            .ValueGeneratedOnAddOrUpdate();
    }
}

try
{
    await context.SaveChangesAsync();
}
catch (DbUpdateConcurrencyException ex)
{
    // tutaj np. pobierasz aktualne dane z bazy i pokazujesz użytkownikowi
    foreach (var entry in ex.Entries)
    {
        // entry.Entity – encja, która była w konflikcie
    }
}
*/




