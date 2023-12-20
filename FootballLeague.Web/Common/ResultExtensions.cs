namespace FootballLeague.Web.Common;

using Application;
using Microsoft.AspNetCore.Mvc;

//extension methods to convert objects into HTTP action results
public static class ResultExtensions
{
    public static async Task<ActionResult<TData>> ToActionResult<TData>(this Task<TData> resultTask)
    {
        var result = await resultTask;

        if (result == null)
        {
            return new NotFoundResult();
        }

        return result;
    }

    public static async Task<ActionResult>? ToActionResult(this Task<Result> resultTask)
    {
        var result = await resultTask;

        if (!result.Succeeded)
        {
            return new BadRequestObjectResult(result.Errors);
        }
            
        return new OkResult();
    }

    public static async Task<ActionResult<TData>> ToActionResult<TData>(this Task<Result<TData>> resultTask)
    {
        var result = await resultTask;

        if (!result.Succeeded)
        {
            return new BadRequestObjectResult(result.Errors);
        }

        return result.Data;
    }
}