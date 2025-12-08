using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Sakila.ConsoleApp;
using Sakila.Infrastructure;

Console.WriteLine("Hello, EF Core!");

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

// 2. Pobierz klientow, imie, nazwisko i adres email
var query1 = context.Customers
    .Select(c => new { c.FirstName, c.LastName, c.Email }) // Typ anonimowy
    .ToList();


query1.Dump("Lista wszystkich klientow");

// 3. Filtrowanie
var query2 = context.Customers
    .Where(c => c.Active == "1")
    .Select(c => new { c.FirstName, c.LastName, c.Email })
    .ToList();

// SQL:
// SELECT first_name, last_name, email
// FROM dbo.customer
// WHERE active = '1'

query2.Dump("Lista aktywnych klientow");

// 4. Stronicowanie
var query4 = context.Customers
    .Skip(10)  // Ilosc pominietych OFFSET
    .Take(20) // Ilosc pobranych TOP(n)
    .Select(c => new { c.FirstName, c.LastName, c.Email })
    .ToList();

query4.Dump("Stronicowanie");

// 5. Sortowanie
var query5 = context.Customers
    //.OrderBy(c => c.CreateDate) // ORDER BY CreateDate ASC
    // .OrderByDescending(c => c.CreateDate) // ORDER BY CreateDate DESC
    .OrderBy(c => c.FirstName)
        .ThenBy(c => c.LastName)    // ORDER BY first_name, last_name
    .Select(c => new { c.FirstName, c.LastName, c.Email })
    .ToList();


query5.Dump("Sortowanie");

// 6. Filtrowanie
var query6 = context.Customers
    .Where(c => c.FirstName.StartsWith("A")) // WHERE first_name LIKE 'A%' 
    .Select(c => new { c.FirstName, c.LastName, c.Email })
    .ToList();


query6.Dump("Filtrowanie na A*");

// 7. Pobranie obiektu po kluczu PK
var query7 = context.Customers.Find(1);

Console.WriteLine(query7);

// 8. Pobranie obiektu po kryterium
var query8 = context.Customers.SingleOrDefault(c => c.Email == "BOB.SMITH@sakilacustomer.org");

var query9 = context.Customers.FirstOrDefault(c => c.StoreId == 1);

Console.WriteLine(query8);

// zachlanne pobieranie danych (Eager Loading)

var query10 = context.Customers
    .Where(c => c.FirstName.StartsWith("A"))
     /// .Include(c => c.Address) // wykona lewe zlaczenie (inner outer join) do tabeli Address
     .Include(c => c.Address.City.Country) // wykona lewe zlaczenia (inner join) do tabeli Address, City i Country
                                           //.Include(c => c.Rentals)
     .Include(c => c.Payments)
        .ThenInclude(p => p.Rental) // Zagniezdzenie stosowane wraz z Collection
    .ToList();

foreach (var customer in query10)
{
    Console.WriteLine($"{customer.FirstName} {customer.LastName} {customer.Address.Address1} {customer.Address.City}");

    foreach (var payment in customer.Payments)
    {
        Console.WriteLine(payment.PaymentDate);

        foreach (var rental in customer.Rentals)
        {
            Console.WriteLine($"{rental.RentalDate} {rental.ReturnDate}");
        }
    }
}

// Filtrowanie powiazanych zbiorow
var lastPaymentsQuery = context.Customers
    .Include(c => c.Payments
                    .Where(p => p.Amount > 10)
                    .OrderByDescending(p => p.PaymentDate)
                    .Take(5))
    .ToList();

lastPaymentsQuery.Dump();


Console.WriteLine("Split Query");

// Split Query
var query12 = context.Customers
    .Where(c => c.FirstName.StartsWith("A"))
     /// .Include(c => c.Address) // wykona lewe zlaczenie (inner outer join) do tabeli Address
     .Include(c => c.Address.City.Country) // wykona lewe zlaczenia (inner join) do tabeli Address, City i Country
                                           //.Include(c => c.Rentals)
     .Include(c => c.Payments)
        .ThenInclude(p => p.Rental) // Zagniezdzenie stosowane wraz z Collection
    .AsSplitQuery()
    .ToList();


var sql = "SELECT * FROM [customer] WHERE first_name LIKE 'A%'";

var query11 = context.Customers.FromSqlRaw(sql).ToList();

query11.Dump();

// AutoInclude  -> patrz SakilaContext.Custom.cs

var query13 = context.Customers.ToList();

foreach (var customer in query13)
{
    Console.WriteLine($"{customer.FirstName} {customer.LastName} {customer.Address}");
}

// Lokalne wylaczenie AutoInclude
var query14 = context.Customers
    .IgnoreAutoIncludes()
    .ToList();   


/*

var sql2 = "EXEC GetCities"; // SELECT Name, Region INTO @query FROM City; RETURN @query

var query12 = context.Cities.FromSqlRaw(sql2).ToList();

await foreach(var city in context.Cities.FromSqlRaw(sql2).AsAsyncEnumerable())
{
    Console.WriteLine(city);
}

// SELECT * FROM GetCities(country) // Table Value Functions (TVF)


using var connection = context.Database.GetDbConnection();
await connection.OpenAsync();

using var cmd = connection.CreateCommand();
cmd.CommandText = "dbo.GetCityQuery";
cmd.CommandType = System.Data.CommandType.StoredProcedure;

var output = cmd.CreateParameter();
output.ParameterName = "@query";
output.DbType = System.Data.DbType.String;
output.Direction = System.Data.ParameterDirection.ReturnValue;
cmd.Parameters.Add(output);

await cmd.ExecuteNonQueryAsync();

string result = (string)output.Value;


*/



// leniwe pobieranie danych (Lazy Loading)



// TODO: modyfikacja rekordow (wspolbieznosc)





