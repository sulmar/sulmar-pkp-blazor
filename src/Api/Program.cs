var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/", () => "Hello World!");

app.MapGet("/api/customers", () => "Get customers!");
app.MapPost("/api/customers", () => "Created customer");
app.MapPut("/api/customers", () => "Updated customer");
app.MapDelete("/api/customers", () => "Deleted customer");


app.Run();

