using Microsoft.Extensions.DependencyInjection;

namespace Core;
public static class DependencyInjection
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {

        return services; 
    }
}

