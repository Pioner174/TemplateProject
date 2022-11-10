using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace TemplateProject.Filters
{
    public class ChangePageArgs : Attribute, IPageFilter
    {
        public void OnPageHandlerExecuted(PageHandlerExecutedContext context)
        {
            
        }

        public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            if (context.HandlerArguments.ContainsKey("message1"))
            {
                context.HandlerArguments["message1"] = "New message";
            }
        }

        public void OnPageHandlerSelected(PageHandlerSelectedContext context)
        {
            
        }
    }
}
