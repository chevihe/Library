namespace Library.Api.Middleware
{
    public class ShabbatMiddleware
    {
        private readonly RequestDelegate _next; 
        public ShabbatMiddleware(RequestDelegate next) { 
           _next = next;
        }
        public async Task InvokeAsync(HttpContext context) 
        {
            if(DateTime.Today.DayOfWeek == DayOfWeek.Saturday) {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                return;
            }
            else { 
                await _next(context);
            }
           
        }
    }
}
