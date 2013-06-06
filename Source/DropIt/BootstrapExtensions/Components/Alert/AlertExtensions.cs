using System.Web.Mvc;
using BootstrapExtensions.Base.Button;

namespace BootstrapExtensions.Components.Alert
{
    public static class AlertExtensions
    {
        // TODO: Alert is not yet implemented! This is just a placeholder as it is used in the docs
        public static MvcHtmlString Alert(this HtmlHelper html, string title, string contents, Category category)
        {
            return MvcHtmlString.Create(string.Format("<div class=\"alert alert-{0}\"><strong>{1}</strong> {2}</div>",
                category.ToString().ToLower(), title, contents));
        }
    }
}
