using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using BootstrapExtensions.Base;
using BootstrapExtensions.Common;

namespace BootstrapExtensions.Components.Progress
{
    public static class ProgressBarExtensions
    {
        public static ProgressBar ProgressBar(this HtmlHelper html, Action<ProgressBarBuilder> progressBarBuilder = null, object htmlAttributes = null)
        {
            return new ProgressBar(progressBarBuilder, htmlAttributes);
        }
        public static ProgressBar ProgressBar(this HtmlHelper html, int percentage, object htmlAttributes = null)
        {
            return new ProgressBar(b => b.Bar(percentage), htmlAttributes);
        }
    }

    public class ProgressBar : HtmlContainer
    {
        private readonly Action<ProgressBarBuilder> _progressBarBuilder;
        public readonly List<BarPart> Bars = new List<BarPart>();  
        public readonly HtmlAttributes CommonBarAttributes = new HtmlAttributes();

        public ProgressBar(Action<ProgressBarBuilder> progressBarBuilder, object htmlAttributes)
        {
            _progressBarBuilder = progressBarBuilder;
            HtmlAttributes = new HtmlAttributes(htmlAttributes);
        }

        public override string ToHtmlString()
        {
            if (_progressBarBuilder != null) _progressBarBuilder(new ProgressBarBuilder(this, CommonBarAttributes));
            InnerHtml = string.Join("", Bars.Select(x => x.ToHtmlString()));
            return base.ToHtmlString();
        }

        protected override string StartHtml()
        {
            HtmlAttributes["class"] = "progress";
            return string.Format("<div {0}>", HtmlAttributes);
        }

        protected override string EndHtml()
        {
            return "</div>";
        }

        public ProgressBar Striped()
        {
            HtmlAttributes["class"] = "progress-striped";
            return this;
        }

        public ProgressBar Animated()
        {
            HtmlAttributes["class"] = "progress-striped";
            HtmlAttributes["class"] = "active";
            return this;
        }

        public ProgressBar Info()
        {
            CommonBarAttributes["class"] = "bar-info";
            return this;
        }

        public ProgressBar Success()
        {
            CommonBarAttributes["class"] = "bar-success";
            return this;
        }

        public ProgressBar Warning()
        {
            CommonBarAttributes["class"] = "bar-warning";
            return this;
        }

        public ProgressBar Danger()
        {
            CommonBarAttributes["class"] = "bar-danger";
            return this;
        }
    }

    public class ProgressBarBuilder
    {
        private readonly ProgressBar _progressBar;
        private readonly HtmlAttributes _commonAttributes;

        public ProgressBarBuilder(ProgressBar progressBar, HtmlAttributes commonAttributes)
        {
            _progressBar = progressBar;
            _commonAttributes = commonAttributes;
        }

        public BarPart Bar(int percentage)
        {
            var bar = new BarPart(percentage, _commonAttributes);
            _progressBar.Bars.Add(bar);
            return bar;
        }
    }

    public class BarPart : HtmlContainer
    {
        public BarPart(int percentage, HtmlAttributes commonAttributes)
        {
            HtmlAttributes = commonAttributes.Clone();
            HtmlTag = "div";
            HtmlAttributes["class"] = "bar";
            HtmlAttributes["style"] = "width:" + percentage + "%";
        }

        public BarPart Info()
        {
            HtmlAttributes["class"] = "bar-info";
            return this;
        }

        public BarPart Success()
        {
            HtmlAttributes["class"] = "bar-success";
            return this;
        }

        public BarPart Warning()
        {
            HtmlAttributes["class"] = "bar-warning";
            return this;
        }

        public BarPart Danger()
        {
            HtmlAttributes["class"] = "bar-danger";
            return this;
        }
    }
}
