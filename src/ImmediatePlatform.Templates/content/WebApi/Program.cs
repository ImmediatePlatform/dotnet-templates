using ImmediatePlatform.Empty;
using Immediate.Handlers.Shared;
using Immediate.Validations.Shared;

[assembly: Behaviors(
	typeof(ValidationBehavior<,>)
)]

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddImmediatePlatformEmptyHandlers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapImmediatePlatformEmptyEndpoints();

app.Run();
