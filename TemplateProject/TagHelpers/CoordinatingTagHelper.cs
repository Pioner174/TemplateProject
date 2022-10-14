using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TemplateProject.TagHelpers
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement("tr", Attributes ="theme")]
    public class RowTagHelper : TagHelper
    {
        public string Theme { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            context.Items["theme"] = Theme;
        }
    }

    [HtmlTargetElement("th")]
    [HtmlTargetElement("td")]
    public class CellTagHelper : TagHelper
    {

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (context.Items.ContainsKey("theme"))
            {
                output.Attributes.SetAttribute("class", $"bg-{context.Items["theme"]} text-white");
            }
        }
    }
}
