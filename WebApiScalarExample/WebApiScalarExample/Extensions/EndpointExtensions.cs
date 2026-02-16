using System.Reflection;
using WebApiScalarExample.Endpoints.Interface;

namespace WebApiScalarExample.Extensions
{
    public static class EndpointExtensions
    {
        public static void MapEndpoints(this IEndpointRouteBuilder app)
        {
            var endpointType = typeof(IBaseEndpoints);

            var endpoints = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => endpointType.IsAssignableFrom(t)
                            && !t.IsInterface
                            && !t.IsAbstract)
                .Select(Activator.CreateInstance)
                .Cast<IBaseEndpoints>();

            foreach (var endpoint in endpoints) endpoint.Map(app);
        }
    }
}
