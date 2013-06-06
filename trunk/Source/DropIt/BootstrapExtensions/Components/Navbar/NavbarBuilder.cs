using System;
using BootstrapExtensions.Base;

namespace BootstrapExtensions.Components.Navbar
{
    public class NavbarBuilder
    {
        private readonly Navbar _navbar;
        private readonly string _activeLink;

        public NavbarBuilder(Navbar navbar, string activeLink = null)
        {
            _navbar = navbar;
            _activeLink = activeLink;
        }

        /// <summary>
        /// A simple link to show your brand or project name
        /// </summary>
        /// <param name="title"></param>
        /// <param name="link"></param>
        public void Brand(string title, string link = null)
        {
            _navbar.InnerHtml += string.Format("<a class=\"brand\" href=\"{1}\">{0}</a>", title, link ?? "#");
        }

        /// <summary>
        /// Display text in navbar
        /// </summary>
        /// <param name="text"></param>
        public void Text(string text)
        {
            _navbar.InnerHtml += string.Format("<p class=\"navbar-text\">{0}</p>", text);
        }

        /// <summary>
        /// Display arbitrary html in navbar
        /// </summary>
        /// <param name="text"></param>
        public void Html(string html)
        {
            _navbar.InnerHtml += html;
        }

        /// <summary>
        /// Navigation links
        /// </summary>
        /// <param name="links">An unordered list of links</param>
        public void Links(Action<HtmlListBuilder> links)
        {
            var list = new HtmlList(links, string.IsNullOrEmpty(_activeLink)
                ? (object)new { @class = "nav" }
                : new { @class = "nav", data_activelink = _activeLink });
            _navbar.InnerHtml += list.ToHtmlString();
        }
    }
}