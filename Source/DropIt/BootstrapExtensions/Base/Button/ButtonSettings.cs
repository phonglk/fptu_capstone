using BootstrapExtensions.Common;

namespace BootstrapExtensions.Base.Button
{
    public class ButtonSettings
    {
        public Size Size { get; set; }
        public bool BlockLevel { get; set; }
        public bool Disabled { get; set; }
        public Category? Category { get; set; }
        public Tag Tag { get; set; }
        public string Url { get; set; }

        public ButtonSettings()
        {
            Size = Size.Default;
            Tag = Tag.Button;
        }

        public void UpdateAttributes(HtmlAttributes htmlAttributes)
        {
            if (Category.HasValue) htmlAttributes["class"] = "btn-" + Category.ToString().ToLower();
            if (Size != Size.Default) htmlAttributes["class"] = "btn-" + Size.ToString().ToLower();
            if (BlockLevel) htmlAttributes["class"] = "btn-block";
            if (!string.IsNullOrEmpty(Url))
            {
                htmlAttributes["href"] = Url;
                Tag = Tag.A;
            }
            if (Tag != Tag.A) htmlAttributes["type"] = "button";
            if (Disabled) htmlAttributes[Tag == Tag.A ? "class" : "disabled"] = "disabled";
        }
    }
}