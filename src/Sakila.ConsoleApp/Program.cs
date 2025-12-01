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





