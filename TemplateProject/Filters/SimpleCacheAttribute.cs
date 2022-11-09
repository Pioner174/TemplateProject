using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;

namespace TemplateProject.Filters
{
    public class SimpleCacheAttribute : Attribute, IResourceFilter
    {
        private Dictionary<PathString, IActionResult> CashedResponses = new Dictionary<PathString, IActionResult>();

        

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            PathString path = context.HttpContext.Request.Path;

            if (CashedResponses.ContainsKey(path))
            {
                context.Result = CashedResponses[path];

                CashedResponses.Remove(path);
            }
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            CashedResponses.Add(context.HttpContext.Request.Path, context.Result);
        }
    }
}
