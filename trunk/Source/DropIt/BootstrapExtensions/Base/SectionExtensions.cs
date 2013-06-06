using System.Linq;
using System.Web.Mvc;

namespace BootstrapExtensions.Base
{
    public static class SectionExtensions
    {
        public static CloseableHtml Section(this HtmlHelper html, string title, object htmlAttributes = null)
        {
            return Section(html, title, null, htmlAttributes);
        }

        public static CloseableHtml Section(this HtmlHelper html, string title, string subTitle = null, object htmlAttributes = null)
        {
            var dictionary = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes ?? new{});
            html.ViewContext.Writer.Write("<section " +
                string.Join(" ", dictionary.Select(x => string.Format("{0}=\"{1}\"", x.Key, x.Value))) +
                "><div class=\"page-header\"><h1>" + title + "</h1></div>");
            return new CloseableHtml(html.ViewContext, "</section>");
        }
    }
}