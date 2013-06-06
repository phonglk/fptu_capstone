using System.Linq;
using System.Web.Mvc;
using BootstrapExtensions.Base.Button;
using BootstrapExtensions.Common;

namespace BootstrapExtensions.Components.ButtonGroup
{
    public static class ButtonGroupExtensions
    {
        public static MvcHtmlString ButtonGroup(this HtmlHelper html, params Button[] buttons)
        {
            return ButtonGroup(html, null, false, buttons);
        }
        public static MvcHtmlString ButtonGroup(this HtmlHelper html, bool vertical, params Button[] buttons)
        {
            return ButtonGroup(html, null, vertical, buttons);
        }
        public static MvcHtmlString ButtonGroup(this HtmlHelper html, object htmlAttributes, params Button[] buttons)
        {
            return ButtonGroup(html, htmlAttributes, false, buttons);
        }
        public static MvcHtmlString ButtonGroup(this HtmlHelper html, object htmlAttributes, bool vertical, params Button[] buttons)
        {
            var attributes = new HtmlAttributes(htmlAttributes ?? new {});
            attributes["class"] = "btn-group";
            if (vertical) attributes["class"] = "btn-group-vertical";
            return MvcHtmlString.Create(string.Format(
                "<div {0}>{1}</div>",
                attributes,
                string.Join("", buttons.Select(x => x.ToHtmlString()))
            ));
        }

        public static MvcHtmlString Toolbar(this HtmlHelper html, params MvcHtmlString[] groups)
        {
            return Toolbar(html, null, groups);
        }

        public static MvcHtmlString Toolbar(this HtmlHelper html, object htmlAttributes, params MvcHtmlString[] groups)
        {
            var attributes = new HtmlAttributes(htmlAttributes ?? new {});
            attributes["class"] = "btn-toolbar";
            return MvcHtmlString.Create(string.Format(
                "<div {0}>{1}</div>",
                attributes,
                string.Join("", groups.Select(x => x.ToString())))
            );
        }
    }
}
