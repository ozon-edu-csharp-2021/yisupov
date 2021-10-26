using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace OzonEdu.MerchandiseService.Infrastructure.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var resultObject = new
            {
                ExceptionType = context.Exception.GetType().FullName,
                StackTrace = context.Exception.StackTrace,
            };

            context.Result = new JsonResult(resultObject)
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };
        }
    }
}
