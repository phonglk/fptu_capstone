using System;
using BootstrapExtensions.Common;

namespace BootstrapExtensions.Components.Navbar
{
    public sealed class Navbar : HtmlContainer
    {
        private bool _responsive;

        public Navbar(Action<NavbarBuilder> navbarBuilder, object htmlAttributes = null, string activeLink = null)
        {
            if (htmlAttributes != null) HtmlAttributes = new HtmlAttributes(htmlAttributes);
            if (navbarBuilder != null) navbarBuilder(new NavbarBuilder(this, activeLink));
        }

        protected override string StartHtml()
        {
            HtmlAttributes["class"] = "navbar";
            return string.Format("<div {0}><div class=\"navbar-inner\">{1}",
                                 HtmlAttributes,
                                 _responsive ? "<div class=\"container\"><a class=\"btn btn-navbar\" data-toggle=\"collapse\" data-target=\".nav-collapse\"><span class=\"icon-bar\"></span><span class=\"icon-bar\"></span><span class=\"icon-bar\"></span></a>" : ""
                );
        }

        protected override string EndHtml()
        {
            return string.Format("{0}</div></div>", _responsive ? "</div>" : "");
        }

        /// <summary>
        /// Modifies the look of the navbar
        /// </summary>
        /// <returns></returns>
        public Navbar Inverse()
        {
            HtmlAttributes["class"] = "navbar-inverse";
            return this;
        }

        /// <summary>
        /// Fixes the navbar to the top or bottom of the viewport
        /// </summary>
        /// <param name="top">Fixes to the top if true, bottom if false. Defaults top</param>
        /// <returns></returns>
        public Navbar Fixed(bool top = true)
        {
            HtmlAttributes["class"] = "navbar-fixed-" + (top ? "top" : "bottom");
            return this;
        }

        /// <summary>
        /// Creates a full-width navbar that scrolls away with the page
        /// </summary>
        /// <returns></returns>
        public Navbar Static()
        {
            HtmlAttributes["class"] = "navbar-static-top";
            return this;
        }

        /// <summary>
        /// Makes the navbar responsive, collapsing on smaller screens (ie. phones/tablets)
        /// </summary>
        /// <returns></returns>
        public Navbar Responsive()
        {
            _responsive = true;
            return this;
        }


    }
}