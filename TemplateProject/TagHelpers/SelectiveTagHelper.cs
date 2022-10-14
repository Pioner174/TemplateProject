using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TemplateProject.TagHelpers
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement("div", Attributes ="show-when-gt, for")]
    public class SelectiveTagHelper : TagHelper
    {
        public decimal ShowWhenGt { get; set; }

        public ModelExpression For { get; set; }


        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if(For.Model.GetType() == typeof(decimal) && (decimal)For.Model <= ShowWhenGt)
            {
                output.SuppressOutput();
            }
            
        }
    }
}
