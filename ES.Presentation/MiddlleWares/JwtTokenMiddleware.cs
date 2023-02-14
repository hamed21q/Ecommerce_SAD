using ES.Presentation.Utility;

namespace ES.Presentation.MiddlleWares
{
    public class JwtTokenMiddleware : IMiddleware
    {
        private readonly RequestDelegate next;
        private readonly IJwtUtils jwtUtils;

        public JwtTokenMiddleware(IJwtUtils jwtUtils)
        {
            this.jwtUtils = jwtUtils;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var user = jwtUtils.ValidateToken(token);
            if (user != null)
            {
                // attach user to context on successful jwt validation
                context.User = user;
            }
            await next(context);
        }
    }
}
