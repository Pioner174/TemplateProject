using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace TemplateProject.TagHelpers
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement("tablehead")]
    public class TableHeadTagHelper : TagHelper
    {
        public string BgColor { get; set; } = "light"; 
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "thead";
            
            output.TagMode = TagMode.StartTagAndEndTag;

            output.Attributes.SetAttribute("class", $"bg-{BgColor} text-white text-centr");

            string content  = (await output.GetChildContentAsync()).GetContent();

            output.Content.SetHtmlContent($"<tr><th colspan=\"2\">{content}</th></tr>");


        }
    }
}
