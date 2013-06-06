using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BootstrapExtensions.Common;

namespace BootstrapExtensions.Base.Form.Label
{
    public class LabelAndControl : HtmlContainer
    {
        private static readonly string HorizontalTemplate = "<div {3}><label class=\"control-label\" for=\"{0}\">{1}</label>    <div class=\"controls\">{2}</div></div>";
        private static readonly string DefaultTemplate = "<label for=\"{0}\">{1}</label> {2}";

        private readonly string _labelFor;
        private readonly string _labelText;
        private IHtmlString _control;
        private readonly string _formLayout;

        private readonly List<IHtmlString> _prepend = new List<IHtmlString>();
        private readonly List<IHtmlString> _append = new List<IHtmlString>();

        public LabelAndControl(ViewContext viewContext, string labelFor, string labelText, IHtmlString control)
        {
            _labelFor = labelFor;
            _labelText = labelText;
            _control = control;
            _formLayout = viewContext.TempData["BootstrapFormLayout"].ToString();
            HtmlAttributes["class"] = "control-group";
        }

        public override string ToHtmlString()
        {
            return string.Format(
                _formLayout == "Horizontal" ? HorizontalTemplate : DefaultTemplate, 
                _labelFor, _labelText,
                ControlHtml(),
                HtmlAttributes
                );
        }

        private string ControlHtml()
        {
            if (_append.Count == 0 && _prepend.Count == 0) return _control.ToHtmlString();
            return string.Format("<div class=\"{0}\">{1}{2}{3}</div>", 
                string.Format("{0} {1}", _prepend.Count > 0 ? "input-prepend" : "", _append.Count > 0 ? "input-append" : ""),
                string.Join("", _prepend.Select(x => x.ToHtmlString())),
                _control,
                string.Join("", _append.Select(x => x.ToHtmlString()))
                );
        }

        public LabelAndControl Prepend(string text)
        {
            _prepend.Add(MvcHtmlString.Create("<span class=\"add-on\">" + text + "</span>"));
            return this;
        }

        public LabelAndControl Prepend(IHtmlString html)
        {
            _prepend.Add(html);
            return this;
        }

        public LabelAndControl Append(string text)
        {
            _append.Add(MvcHtmlString.Create("<span class=\"add-on\">" + text + "</span>"));
            return this;
        }

        public LabelAndControl Append(IHtmlString html)
        {
            _append.Add(html);
            return this;
        }

        public LabelAndControl HelpText(string text, bool inline = true)
        {
            var helpCode = string.Format("<span class=\"{0}\">{1}</span>", inline ? "help-inline" : "help-block", text);
            _control = MvcHtmlString.Create(_control + helpCode);
            return this;
        }

        public LabelAndControl Warning(bool condition = true)
        {
            if (condition) HtmlAttributes["class"] = "warning";
            return this;
        }

        public LabelAndControl Error(bool condition = true)
        {
            if (condition) HtmlAttributes["class"] = "error";
            return this;
        }

        public LabelAndControl Info(bool condition = true)
        {
            if (condition) HtmlAttributes["class"] = "info";
            return this;
        }

        public LabelAndControl Success(bool condition = true)
        {
            if (condition) HtmlAttributes["class"] = "success";
            return this;
        }
    }
}