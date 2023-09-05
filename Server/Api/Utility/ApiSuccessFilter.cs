using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using vDomain.Dto;

namespace Api.Utility;
public class ApiSuccessFilter : IActionFilter
{
    public void OnActionExecuted(ActionExecutedContext context)
    {
        throw new NotImplementedException();
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        var result = (ObjectResult)context.Result; 
        result.Value = ApiResponse.GenerateSuccess(result.Value);   
    }
}
