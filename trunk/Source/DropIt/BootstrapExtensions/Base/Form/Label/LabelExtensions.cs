using System.Web;
using System.Web.Mvc;

namespace BootstrapExtensions.Base.Form.Label
{
    public static class LabelExtensions
    {
        public static LabelAndControl LabelAndControl(this HtmlHelper html, IHtmlString control)
        {
            return LabelAndControl(html, "", "", control);
        }

        public static LabelAndControl LabelAndControl(this HtmlHelper html, string labelFor, IHtmlString control)
        {
            return LabelAndControl(html, labelFor, labelFor, control);
        }

        public static LabelAndControl LabelAndControl(this HtmlHelper html, string labelFor, string labelText, IHtmlString control)
        {
            return new LabelAndControl(html.ViewContext, labelFor, labelText, control);
        }
    }
}
