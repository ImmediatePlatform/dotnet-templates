using Immediate.Cache;
using Immediate.Handlers.Shared;
using Microsoft.Extensions.Caching.Memory;

namespace MyNamespace;

// Register this class as a singleton in your DI container.
public sealed class GetTodoCache(
	IMemoryCache memoryCache,
	Owned<IHandler<GetTodo.Request, GetTodo.Response>> ownedGetTodo
) : ApplicationCacheBase<GetTodo.Request, GetTodo.Response>(
	memoryCache,
	ownedGetTodo
)
{
	protected override string TransformKey(GetTodo.Request request)
    {
        // Use this method to create a unique cache key based on the request.
        throw new NotImplementedException();
    }
}

[Handler]
public static partial class GetTodo
{
	public sealed record Request
	{
		
	}

    public sealed record Response
    {
        
    }

	private static async ValueTask<Response> HandleAsync(Request request, CancellationToken token)
    {
        throw new NotImplementedException();
    }
}