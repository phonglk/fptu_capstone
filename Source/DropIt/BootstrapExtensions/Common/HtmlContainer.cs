using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BootstrapExtensions.Common
{
    public abstract class HtmlContainer : IHtmlString
    {
        public bool SelfClosing { get; set; }
        public string HtmlTag { get; set; }
        public HtmlAttributes HtmlAttributes = new HtmlAttributes();

        protected HtmlContainer()
        {
            InnerHtml = "";
        }

        protected virtual string StartHtml()
        {
            return string.Format("<{0} {1}>", HtmlTag, HtmlAttributes);
        }

        public string InnerHtml { get; set; }

        protected virtual string EndHtml()
        {
            return string.Format("</{0}>", HtmlTag);
        }

        /// <summary>
        /// Insert any html content
        /// </summary>
        /// <param name="html"></param>
        public void Element(string html)
        {
            InnerHtml += html;
        }
        /// <summary>
        /// Insert any html content
        /// </summary>
        /// <param name="html"></param>
        public void Element(IHtmlString html)
        {
            InnerHtml += html;
        }

        public virtual string ToHtmlString()
        {
            if (SelfClosing && string.IsNullOrEmpty(InnerHtml))
                return string.Format("<{0} {1}/>", HtmlTag, HtmlAttributes);
            return StartHtml() + InnerHtml + EndHtml();
        }
    }

    public class HtmlAttributes
    {
        private readonly IDictionary<string, object> _attributes = new Dictionary<string, object>();

        public HtmlAttributes() {}

        public HtmlAttributes(IDictionary<string,object> htmlAttributes)
        {
            _attributes = htmlAttributes;
        }

        public HtmlAttributes(object htmlAttributes)
        {
            _attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
        }

        public string this[string attribute]
        {
            get { return _attributes.ContainsKey(attribute) ? _attributes[attribute].ToString() : null; }
            set
            {
                if (_attributes.ContainsKey(attribute))
                    _attributes[attribute] += " " + value;
                else
                    _attributes.Add(new KeyValuePair<string, object>(attribute, value));
            }
        }

        protected void SetAttribute(string attribute, string value, bool overwrite = false)
        {
            if (_attributes.ContainsKey(attribute))
            {
                if (overwrite) _attributes[attribute] = " " + value;
                else _attributes[attribute] += " " + value;
            }
            else
            {
                _attributes.Add(new KeyValuePair<string, object>(attribute, value));
            }
        }

        public override string ToString()
        {
            return string.Join(" ", _attributes.Select(x => x.Key + "=\"" + x.Value + "\""));
        }

        public HtmlAttributes Clone()
        {
            return new HtmlAttributes(_attributes.ToDictionary(x => x.Key, x => x.Value));
        }
    }
}
