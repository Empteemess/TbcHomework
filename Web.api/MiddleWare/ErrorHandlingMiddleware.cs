using System.Net;
using Domain.CustomExceptions;
using Microsoft.EntityFrameworkCore;

namespace Web.api.MiddleWare;

public class ErrorHandlingMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next.Invoke(context);
        }
        catch (IdentityException exception)
        {
            context.Response.StatusCode = exception.StatusCode;
            await context.Response.WriteAsJsonAsync(new
            {
                Error = exception.Message
            });
        }
        catch (DbUpdateConcurrencyException exception)
        {
            context.Response.StatusCode = (int)HttpStatusCode.Conflict;
            await context.Response.WriteAsJsonAsync(new
            {
                Error = "A concurrency conflict occurred.",
                Details = exception.Message
            });
        }
        catch (DbUpdateException exception)
        {
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            await context.Response.WriteAsJsonAsync(new
            {
                Error = "A database update error occurred.",
                Details = exception.InnerException?.Message ?? exception.Message
            });
        }
        catch (NotFoundException exception)
        {
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            await context.Response.WriteAsJsonAsync(new
            {
                Error = "A database update error occurred.",
                Details = exception.InnerException?.Message ?? exception.Message
            });
        }
        catch (Exception exception)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await context.Response.WriteAsJsonAsync(new
            {
                Error = exception.Message
            });
        }
    }
}