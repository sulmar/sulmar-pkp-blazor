using Api.Endpoints;
using Domain.Abstractions;
using Infrastructure;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("SakilaConnection");

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Rejestracja w kontenerze wstrzykiwania zaleznosci (Dependency Injection)
builder.Services.AddSingleton<ICustomerRepository, FakeCustomerRepository>();

builder.Services.AddCors(options => options.AddDefaultPolicy(
    policy => policy.WithOrigins("https://localhost:7049", "https://localhost:7118")
                        .WithMethods("GET", "POST", "DELETE")
                        .AllowAnyHeader()
    
    ));

// dotnet add package EE
builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
    .AddNegotiate();

// Rejetracja polityki VIP
builder.Services.AddAuthorization(options => options.AddPolicy("VIP", builder => builder
        .RequireAuthenticatedUser()
        .RequireClaim("scope", "read")
        .RequireRole("foo")
        ));

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

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

