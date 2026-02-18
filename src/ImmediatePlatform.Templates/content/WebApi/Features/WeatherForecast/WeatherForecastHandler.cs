using Immediate.Apis.Shared;
using Immediate.Handlers.Shared;

namespace ImmediatePlatform.Empty.Features.WeatherForecast;

[Handler]
[MapGet("/weatherforecast")]
public static partial class WeatherForecastHandler
{
    public record Query;

    public record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
    {
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }

    internal static void CustomizeEndpoint(RouteHandlerBuilder endpoint) => endpoint
        .WithName("GetWeatherForecast");

    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private static ValueTask<WeatherForecast[]> HandleAsync(Query _, CancellationToken cancellationToken)
    {
        var forecast = Enumerable.Range(1, 5).Select(index =>
            new WeatherForecast
            (
                DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                Random.Shared.Next(-20, 55),
                Summaries[Random.Shared.Next(Summaries.Length)]
            ))
            .ToArray();

        return ValueTask.FromResult(forecast);
    }
}
