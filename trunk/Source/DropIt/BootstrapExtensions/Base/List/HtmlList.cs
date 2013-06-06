using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BootstrapExtensions.Common;

namespace BootstrapExtensions.Base
{
    public sealed class HtmlList : HtmlContainer
    {
        private bool _ordered;
        public readonly List<HtmlListItem> ListItems = new List<HtmlListItem>();

        public HtmlList(Action<HtmlListBuilder> listBuilder, object htmlAttributes = null)
        {
            HtmlAttributes = new HtmlAttributes(htmlAttributes);
            if (listBuilder != null) listBuilder(new HtmlListBuilder(this));
            InnerHtml = string.Join("", ListItems.Select(x => x.ToHtmlString()));
        }


        protected override string StartHtml()
        {
            return string.Format("<{0} {1}>", _ordered ? "ol" : "ul", HtmlAttributes);
        }

        protected override string EndHtml()
        {
            return string.Format("</{0}>", _ordered ? "ol" : "ul");
        }

        /// <summary>
        /// Uses numbers rather than bullets for list items
        /// </summary>
        /// <returns></returns>
        public HtmlList Ordered()
        {
            _ordered = true;
            return this;
        }

        /// <summary>
        /// A list of items with no list-style or additional left padding
        /// </summary>
        /// <returns></returns>
        public HtmlList Unstyled()
        {
            HtmlAttributes["class"] = "unstyled";
            return this;
        }
    }
}