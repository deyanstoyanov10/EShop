namespace EShop.Infrastructure.Filters
{
    using Common;
    using Common.ApiResponse;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;

    internal class ModelStateValidationFilter : ActionFilterAttribute
    {
        public override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                if (context.ModelState.Count == 0 || context.ModelState == null)
                {
                    var error = new List<Error>() { new Error("Empty model") };

                    context.Result = new BadRequestObjectResult(new ApiResponse<object>(error));
                }
                else
                {
                    var errors = new List<Error>();

                    foreach (var element in context.ModelState)
                    {
                        foreach (var error in element.Value.Errors)
                        {
                            errors.Add(new Error(error.ErrorMessage));
                        }
                    }

                    context.Result = new BadRequestObjectResult(new ApiResponse<object>(errors));
                }
            }

            return base.OnActionExecutionAsync(context, next);
        }
    }
}
