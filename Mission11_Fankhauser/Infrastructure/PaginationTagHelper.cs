using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Mission11_Fankhauser.Models.ViewModels;

namespace Mission11_Fankhauser.Infrastructure;

// Set the target and attribute of the target so it connects to the div set up in the Index view
[HtmlTargetElement("div", Attributes = "page-model")]
public class PaginationTagHelper : TagHelper
{
    // Create a private instance of the urlHelperFactory
    private IUrlHelperFactory _urlHelperFactory;

    // Instantiate the instance of the urlHelperFactory in the constructor
    public PaginationTagHelper(IUrlHelperFactory temp)
    {
        _urlHelperFactory = temp;
    }
    
    // set a nullable ViewContext property that is not bound to HtmlAttributes
    [ViewContext]
    [HtmlAttributeNotBound]
    public ViewContext? ViewContext { get; set; }
    // The following will all be called in the div in the index page
    public string? PageAction { get; set; }
    public PaginationInfo PageModel { get; set; }

    public bool PageClassEnabled { get; set; } = false;
    public string PageClass { get; set; } = String.Empty;
    public string PageClassNormal { get; set; } = String.Empty;
    public string PageClassSelected { get; set; } = String.Empty;

    // Create this override Process that takes a context tag helper and outputs a tag helper
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        // If the ViewContext and PageModel aren't null...
        if (ViewContext != null && PageModel != null)
        {
            // Instantiate a urlHelper using the ViewContext property
            IUrlHelper urlHelper = _urlHelperFactory.GetUrlHelper(ViewContext);

            // Build a tag called result that is a div tag
            TagBuilder result = new TagBuilder("div");

            // For each page needed in the website...
            for (int i = 1; i <= PageModel.TotalNumPages; i++)
            {
                // Instantiate a new tag called tag that is an a tag
                TagBuilder tag = new TagBuilder("a");
                // Set the href sending us to whatever pageNum is at the time
                tag.Attributes["href"] = urlHelper.Action(PageAction, new { pageNum = i });
                // Add Css so that when you click on a page number, that number is highlighted
                if (PageClassEnabled)
                {
                    tag.AddCssClass(PageClass);
                    tag.AddCssClass(i == PageModel.CurrentPage ? PageClassSelected : PageClassNormal);
                }
                // Append the page number to the inner html of the a tag
                tag.InnerHtml.Append(i.ToString());

                // Append the newly created a tag into the div tag we called result
                result.InnerHtml.AppendHtml(tag);
            }

            // output the entire result with its innerHtml into the div in the index view
            output.Content.AppendHtml(result.InnerHtml);
        }
    }
}