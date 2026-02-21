#if UseApi
using Immediate.Apis.Shared;
#endif
using Immediate.Handlers.Shared;
#if UseValidations
using Immediate.Validations.Shared;
#endif

namespace MyNamespace;

[Handler]
#if UseApi
[MapHttpMethod("/immediatehandler")]
#endif
public static partial class ImmediateHandler
{
#if UseValidations
    [Validate]
    public sealed partial record Query : IValidationTarget<Query>
    {

    }
#else
    public sealed record Query
    {
        
    }
#endif

    public sealed record Response
    {
        
    }

#if (UseApi && UseCustomizeEndpoint)
    internal static void CustomizeEndpoint(RouteHandlerBuilder endpoint) => endpoint
        .WithName("ImmediateHandler")
        .Produces<Response>(StatusCodes.Status200OK);

#endif
    private static ValueTask<Response> HandleAsync(Query query, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
