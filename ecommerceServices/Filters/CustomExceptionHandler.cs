using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace ecommerceServices.Filters
{
    public class CustomExceptionHandler: ExceptionFilterAttribute
    {
       
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            ILog log = LogManager.GetLogger(actionExecutedContext.ActionContext.ControllerContext.ControllerDescriptor.ControllerName);
           string exceptionMessage = string.Empty;
            if (actionExecutedContext.Exception.InnerException == null)
            {
                exceptionMessage = actionExecutedContext.Exception.Message;
            }
            else
            {
                exceptionMessage = actionExecutedContext.Exception.InnerException.Message;
            }
            //logging error in Errorlog/logfile.txt
            log.Error(exceptionMessage);

            var response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent(exceptionMessage),  
                ReasonPhrase = "Internal Server Error.Please Contact your Administrator."
            };
            actionExecutedContext.Response = response;
        }
    }
}