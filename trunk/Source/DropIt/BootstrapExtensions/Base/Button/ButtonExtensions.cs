using System.Web;
using System.Web.Mvc;

namespace BootstrapExtensions.Base.Button
{
    public static class ButtonExtensions
    {
        public static Button Button(this HtmlHelper html, string text, ButtonSettings settings, object htmlAttributes = null)
        {
            return new Button(text, settings, htmlAttributes);
        }

        public static Button Button(this HtmlHelper html, string text, object htmlAttributes = null)
        {
            return new Button(text, null, htmlAttributes);
        }

        public static Button Button(this HtmlHelper html, string text, Category category, object htmlAttributes = null)
        {
            return new Button(text, new ButtonSettings { Category = category }, htmlAttributes);
        }

        public static Button Button(this HtmlHelper html, string text, string url, object htmlAttributes = null)
        {
            return new Button(text, new ButtonSettings { Url = url}, htmlAttributes);
        }

        public static Button Button(this HtmlHelper html, string text, Category category, string url, object htmlAttributes = null)
        {
            return new Button(text, new ButtonSettings { Category = category, Url = url}, htmlAttributes);
        }
    }
}
