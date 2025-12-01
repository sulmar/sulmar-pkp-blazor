using Microsoft.EntityFrameworkCore;
using Sakila.ConsoleApp;
using Sakila.Infrastructure;

Console.WriteLine("Hello, EF Core!");

string connectionString = "Server=(localdb)\\efcore-demo;Database=sakila;Trusted_Connection=True;";

// var connectionString = builder.Configuration.GetConnectionString("SakilaConnection"); 

// 0. Przygotowanie parametrów polaczenia do bazy danych
var options = new DbContextOptionsBuilder<SakilaContext>()
    .UseSqlServer(connectionString)
    .Options;

// 1. Utworzenie instancji DbContext
SakilaContext context = new SakilaContext(options);

// 2. Pobierz klientow, imie, nazwisko i adres email
var query1 = context.Customers
    .Select(c => new { c.FirstName, c.LastName, c.Email } ) // Typ anonimowy
    .ToList();


query1.Dump("Lista wszystkich klientow");

// 3. Filtrowanie
var query2 = context.Customers
    .Where(c => c.Active == "1")
    .Select(c => new { c.FirstName, c.LastName, c.Email})    
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

var query9 = context.Customers.FirstOrDefault(c=>c.StoreId == 1);

Console.WriteLine(query8);

// TODO: zachlanne pobieranie danych

// TODO: modyfikacja rekordow (wspolbieznosc)





