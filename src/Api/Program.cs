using Api.Endpoints;
using Domain.Abstractions;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Rejestracja w kontenerze wstrzykiwania zaleznosci (Dependency Injection)
builder.Services.AddScoped<ICustomerRepository, FakeCustomerRepository>();

builder.Services.AddCors(options => options.AddDefaultPolicy(
    policy => policy.WithOrigins("https://localhost:7049", "https://localhost:7118")
                        .WithMethods("GET")
                        .AllowAnyHeader()
    
    ));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCors(); // Dodajemy middleware (warstwa posrednia)

app.UseHttpsRedirection();

app.MapGet("/", () => "Hello World!");

app.MapGroup("/api/customers").MapCustomersApi();




app.Run();

