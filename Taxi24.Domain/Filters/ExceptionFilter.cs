using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi24.Domain.Filters
{
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            //Just for evaluation puporse

            var msg = context.Exception.GetBaseException().Message;
            string stack = context.Exception.StackTrace;

            context.HttpContext.Response.StatusCode = 500;
           
            context.Result = new JsonResult(context.Exception.GetBaseException());

            base.OnException(context);
        }
    }
}
