using Microsoft.AspNetCore.Mvc.Razor.TagHelpers;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.Logging;

namespace TemplateProject.TagHelpers
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement("table")]
    public class TableFooterSelector : TagHelperComponentTagHelper
    {
        public TableFooterSelector(ITagHelperComponentManager manager, ILoggerFactory loggerFactory) : base(manager, loggerFactory)
        {
        }
    }



    public class TableFooterTagHelperComponent : TagHelperComponent
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {

            if(output.TagName == "table")
            {

                TagBuilder cell = new TagBuilder("td");
                cell.Attributes.Add("colspan", "2");
                cell.Attributes.Add("class", "bg-dark text-white text-center");
                cell.InnerHtml.Append("Table Footer");

                TagBuilder row = new TagBuilder("tr");
                row.InnerHtml.AppendHtml(cell);

                TagBuilder footer = new TagBuilder("tfoot");
                footer.InnerHtml.AppendHtml(row);

                output.PostContent.AppendHtml(footer);
            }

        }
    }
}
