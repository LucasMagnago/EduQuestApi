using EduQuest.Communication.Responses;
using EduQuest.Exception.ExceptionsBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EduQuest.Api.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            // Handle the exception here
            // For example, log the exception and return a custom error response

            if (context.Exception is EduQuestException)
            {
                HandleProjectException(context);
            }
            else
            {
                ThrowUnkownError(context);
            }
        }


        private void HandleProjectException(ExceptionContext context)
        {
            var eduQuestException = (EduQuestException)context.Exception;
            var errorResponse = new ResponseErrorJson(eduQuestException.GetErrors());

            context.HttpContext.Response.StatusCode = eduQuestException.StatusCode;
            context.Result = new ObjectResult(errorResponse);
        }

        private void ThrowUnkownError(ExceptionContext context)
        {
            var errorResponse = new ResponseErrorJson("Unkown error");

            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Result = new BadRequestObjectResult(errorResponse);
        }
    }
}
