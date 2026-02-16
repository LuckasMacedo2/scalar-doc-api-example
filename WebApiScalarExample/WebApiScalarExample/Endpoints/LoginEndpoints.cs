using WebApiScalarExample.Models.User;
using WebApiScalarExample.Services;

namespace WebApiScalarExample.Endpoints
{
    public static class LoginEndpoints
    {
        public static RouteGroupBuilder MapLoginEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/");

            group.MapPost("/login", Login);

            return group;
        }

        private static IResult Login(UserLogin login, LoginService loginService)
        {
            return Results.Ok(loginService.GetToken(login));
        }

    }
}
