using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TemplateProject.Filters
{
    public class SimpleCacheAttribute : Attribute, IAsyncResourceFilter
    {
        private Dictionary<PathString, IActionResult> CashedResponses = new Dictionary<PathString, IActionResult>();

        public async Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next)
        {
            PathString path = context.HttpContext.Request.Path;

            if(CashedResponses.ContainsKey(path))
            {
                context.Result= CashedResponses[path];
                CashedResponses.Remove(path);
            }
            else
            {
                ResourceExecutedContext execContext = await next();

                CashedResponses.Add(context.HttpContext.Request.Path, execContext.Result);
            }
        }
    }
}
