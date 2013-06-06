using System;
using System.Web.Mvc;

namespace BootstrapExtensions.Base
{
    public static class ListExtensions
    {
        public static HtmlList List(this HtmlHelper html)
        {
            return new HtmlList(null);
        }

        public static HtmlList List(this HtmlHelper html, Action<HtmlListBuilder> listBuilder)
        {
            return new HtmlList(listBuilder);
        }

        public static HtmlList List(this HtmlHelper html, Action<HtmlListBuilder> listBuilder, object htmlAttributes)
        {
            return new HtmlList(listBuilder, htmlAttributes);
        }
    }
}
