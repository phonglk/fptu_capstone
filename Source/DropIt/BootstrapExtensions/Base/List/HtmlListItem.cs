using System.Web;

namespace BootstrapExtensions.Base
{
    public class HtmlListItem : IHtmlString
    {
        private bool _active;
        private bool _divider;
        private readonly string _contents = "";

        public HtmlListItem(){}

        public HtmlListItem(string contents)
        {
            _contents = contents;
        }

        public HtmlListItem(IHtmlString contents)
        {
            _contents = contents.ToHtmlString();
        }

        public string ToHtmlString()
        {
            return _divider
                       ? "<li class=\"divider-vertical\"></li>" // TODO: Select divider based on list type; not always vertical
                       : string.Format("<li{0}>{1}</li>", _active ? " class=\"active\"" : "", _contents);
        }

        public HtmlListItem Active(bool condition = true)
        {
            _active = condition;
            return this;
        }

        public HtmlListItem Divider(bool divider = true)
        {
            _divider = divider;
            return this;
        }
    }
}