using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;
using testAPI.Utility;

namespace testAPI.Filters
{
    public class ContactExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            if (!(actionExecutedContext.Exception is ContactException)) return;
            //The Response Message Set by the Action During Ececution
            var res = actionExecutedContext.Exception.Message;

            //Define the Response Message
            var response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent(res),
                ReasonPhrase = res
            };

            //Create the Error Response

            actionExecutedContext.Response = response;
        }
    }
}