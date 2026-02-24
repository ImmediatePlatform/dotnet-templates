using Immediate.Apis.Shared;
using Immediate.Handlers.Shared;
using Immediate.Validations.Shared;

namespace ImmediatePlatform.Empty.Features.WeatherForecast;

[Handler]
[MapGet("/weatherforecast")]
public static partial class GetWeatherForecasts
{
    [Validate]
    public sealed partial record Query : IValidationTarget<Query>
    {
        [MinLength(3)]
        public required string Location { get; init; }

        [GreaterThan(0), LessThanOrEqual(15)]
        public int? Days { get; init; }
    }

    public sealed record WeatherForecast(string Location, DateOnly Date, int TemperatureC, string? Summary)
    {
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }

    internal static void CustomizeEndpoint(RouteHandlerBuilder endpoint) => endpoint
        .WithName("GetWeatherForecasts");

    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private static ValueTask<WeatherForecast[]> HandleAsync(Query query, CancellationToken cancellationToken)
    {
        var forecast = Enumerable.Range(1, query.Days ?? 5).Select(index =>
            new WeatherForecast
            (
                query.Location,
                DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                Random.Shared.Next(-20, 55),
                Summaries[Random.Shared.Next(Summaries.Length)]
            ))
            .ToArray();

        return ValueTask.FromResult(forecast);
    }
}
