using customTagBuilder.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace customTagBuilder.TagBuilders
{
 
     
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PageLinkBuilder : TagHelper
    {
        public PagingInfo PageModel { get; set; }
        public string PageAction { get; set; }

        IUrlHelperFactory urlHelperFactory;

        public PageLinkBuilder(IUrlHelperFactory helperFactory)
        {
            urlHelperFactory = helperFactory;
        }
        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {

/* <div>
  <ul class="pagination pagination-lg">
    <li class="page-item active" aria-current="page">
      <span class="page-link">1</span>
    </li>
    <li class="page-item"><a class="page-link" href="#">2</a></li>
    <li class="page-item"><a class="page-link" href="#">3</a></li>
  </ul>
</div>
*/

            TagBuilder div = new TagBuilder("div");
            TagBuilder ul = new TagBuilder("ul");
            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);

            ul.AddCssClass("pagination");
            ul.AddCssClass("pagination-lg");

            for (int i = 1; i <= PageModel.PageCount; i++)
            {
                TagBuilder li = new TagBuilder("li");
                li.AddCssClass("page-item");
                if (i== PageModel.CurrentPage)
                {
                   li.AddCssClass("active");
                }
                TagBuilder a = new TagBuilder("a");
                a.Attributes["href"] = urlHelper.Action(PageAction, new { page = i });
                a.AddCssClass("page-link");                
                a.InnerHtml.Append(i.ToString());
                li.InnerHtml.AppendHtml(a);
                ul.InnerHtml.AppendHtml(li);
            }
            div.InnerHtml.AppendHtml(ul);

            output.Content.AppendHtml(div);   
        }

    }
}
