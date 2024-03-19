using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebAPIDemo.Models.Repositories;

namespace WebAPIDemo.Filters.ExceptionFilters;

public class ShirtHandleUpdateExceptionsFilterAttribute: ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        base.OnException(context);

        var strShirtId = context.RouteData.Values["id"] as string;
        if (int.TryParse(strShirtId, out int shirtId))
        {
            if (!ShirtRepository.ShirtExist(shirtId))
            {
                context.ModelState.AddModelError("ShirtId", "Shirt doesn't exist anymore.");

                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status404NotFound
                };
                context.Result = new NotFoundObjectResult(problemDetails);
            }
        }
    }
}