using BootstrapExtensions.Common;

namespace BootstrapExtensions.Base.Button
{
    public class Button : HtmlContainer
    {
        private readonly string _text;
        private readonly ButtonSettings _settings;

        public Button(string text, ButtonSettings settings, object htmlAttributes)
        {
            _text = text;
            _settings = settings ?? new ButtonSettings();
            HtmlAttributes = new HtmlAttributes(htmlAttributes);
            _settings.UpdateAttributes(HtmlAttributes);
            HtmlAttributes["class"] = "btn";
            if (_settings.Tag == Tag.Input)
            {
                HtmlTag = "input";
                HtmlAttributes["value"] = text;
            } else
            {
                HtmlTag = _settings.Tag.ToString().ToLower();
                InnerHtml = text;
            }
        }
    }
}