using System;
using System.Web.Mvc;

namespace BootstrapExtensions.Components.Navbar
{
    public static class NavbarExtensions
    {
        public static Navbar Navbar(this HtmlHelper html)
        {
            return new Navbar(null);
        }

        public static Navbar Navbar(this HtmlHelper html, Action<NavbarBuilder> navbarBuilder, object htmlAttributes = null)
        {
            return new Navbar(navbarBuilder, htmlAttributes);
        }

        public static Navbar Navbar(this HtmlHelper html, string activeLink, Action<NavbarBuilder> navbarBuilder, object htmlAttributes = null)
        {
            return new Navbar(navbarBuilder, htmlAttributes, activeLink);
        }
    }
}
