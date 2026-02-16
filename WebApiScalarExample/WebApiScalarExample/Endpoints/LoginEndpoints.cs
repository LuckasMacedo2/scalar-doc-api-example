using WebApiScalarExample.Endpoints.Interface;
using WebApiScalarExample.Models.User;
using WebApiScalarExample.Services;

namespace WebApiScalarExample.Endpoints
{
    public class LoginEndpoints : IBaseEndpoints
    {
        public void Map(IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/");

            group.MapPost("/login", Login);

        }

        private IResult Login(UserLogin login, LoginService loginService)
        {
            return Results.Ok(loginService.GetToken(login));
        }

    }
}
