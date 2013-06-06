using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace BootstrapExtensions.Base.Form
{
    public static class FormExtensions
    {
        private static MvcForm GenerateForm(this HtmlHelper htmlHelper, string formAction, FormMethod method, IDictionary<string, object> htmlAttributes, FormLayout layout)
        {
            var tagBuilder = new TagBuilder("form");
            tagBuilder.MergeAttributes(htmlAttributes);
            tagBuilder.MergeAttribute("action", formAction);
            tagBuilder.MergeAttribute("method", HtmlHelper.GetFormMethodString(method), true);

            if (layout != FormLayout.Default)
                tagBuilder.AddCssClass("form-" + layout.ToString().ToLower());
            htmlHelper.ViewContext.TempData["BootstrapFormLayout"] = layout;

            var flag = htmlHelper.ViewContext.ClientValidationEnabled && !htmlHelper.ViewContext.UnobtrusiveJavaScriptEnabled;
            if (flag) tagBuilder.GenerateId(GenerateId(htmlHelper.ViewContext));
            htmlHelper.ViewContext.Writer.Write(tagBuilder.ToString(TagRenderMode.StartTag));
            var mvcForm = new MvcForm(htmlHelper.ViewContext);
            if (flag) htmlHelper.ViewContext.FormContext.FormId = tagBuilder.Attributes["id"];
            return mvcForm;
        }

        private static string GenerateId(ViewContext viewContext)
        {
            var formCount = ((int?)viewContext.TempData["BootstrapFormCount"] ?? 0) + 1;
            viewContext.TempData["BootstrapFormCount"] = formCount;
            return "bootstrapForm" + formCount;
        }

        #region Default Form

        public static MvcForm Form(this HtmlHelper html)
        {
            var rawUrl = html.ViewContext.HttpContext.Request.RawUrl;
            return GenerateForm(html, rawUrl, FormMethod.Post, null, FormLayout.Default);
        }

        public static MvcForm Form(this HtmlHelper html, object routeValues)
        {
            return Form(html, new RouteValueDictionary(routeValues));
        }

        public static MvcForm Form(this HtmlHelper html, RouteValueDictionary routeValues)
        {
            var formAction = UrlHelper.GenerateUrl(null, null, null, routeValues, html.RouteCollection, html.ViewContext.RequestContext, true);
            return GenerateForm(html, formAction, FormMethod.Post, null, FormLayout.Default);
        }

        public static MvcForm Form(this HtmlHelper html, string actionName, string controllerName)
        {
            return Form(html, actionName, controllerName, new{});
        }

        public static MvcForm Form(this HtmlHelper html, string actionName, string controllerName, object routeVals)
        {
            return Form(html, actionName, controllerName, new RouteValueDictionary(routeVals));
        }

        public static MvcForm Form(this HtmlHelper html, string actionName, string controllerName, RouteValueDictionary routeVals)
        {
            return Form(html, actionName, controllerName, routeVals, FormMethod.Post, null);
        }

        public static MvcForm Form(this HtmlHelper html, string actionName, string controllerName, FormMethod formMethod)
        {
            return Form(html, actionName, controllerName, formMethod, new Dictionary<string, object>());
        }

        public static MvcForm Form(this HtmlHelper html, string actionName, string controllerName, object routeVals, FormMethod formMethod)
        {
            return Form(html, actionName, controllerName, new RouteValueDictionary(routeVals), formMethod);
        }

        public static MvcForm Form(this HtmlHelper html, string actionName, string controllerName, RouteValueDictionary routeVals, FormMethod formMethod)
        {
            return Form(html, actionName, controllerName, routeVals, formMethod, new{});
        }

        public static MvcForm Form(this HtmlHelper html, string actionName, string controllerName, FormMethod formMethod, object htmlAttributes)
        {
            return Form(html, actionName, controllerName, formMethod, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }
        
        public static MvcForm Form(this HtmlHelper html, string actionName, string controllerName, FormMethod formMethod, IDictionary<string, object> htmlAttributes)
        {
            var formAction = UrlHelper.GenerateUrl(null, actionName, controllerName, new RouteValueDictionary(), html.RouteCollection, html.ViewContext.RequestContext, true);
            return GenerateForm(html, formAction, formMethod, htmlAttributes, FormLayout.Default);
        }

        public static MvcForm Form(this HtmlHelper html, string actionName, string controllerName, object routeVals, FormMethod formMethod, object htmlAttributes)
        {
            return Form(html, actionName, controllerName, new RouteValueDictionary(routeVals), formMethod, htmlAttributes);
        }

        public static MvcForm Form(this HtmlHelper html, string actionName, string controllerName, RouteValueDictionary routeVals, FormMethod formMethod, object htmlAttributes)
        {
            return Form(html, actionName, controllerName, routeVals, formMethod, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcForm Form(this HtmlHelper html, string actionName, string controllerName, RouteValueDictionary routeVals, FormMethod formMethod, IDictionary<string, object> htmlAttributes)
        {
            var formAction = UrlHelper.GenerateUrl(null, actionName, controllerName, new RouteValueDictionary(routeVals), html.RouteCollection, html.ViewContext.RequestContext, true);
            return GenerateForm(html, formAction, formMethod, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes), FormLayout.Default);
        }

        #endregion

        #region Search Form

        public static MvcForm SearchForm(this HtmlHelper html)
        {
            var rawUrl = html.ViewContext.HttpContext.Request.RawUrl;
            return GenerateForm(html, rawUrl, FormMethod.Post, null, FormLayout.Search);
        }

        public static MvcForm SearchForm(this HtmlHelper html, object routeValues)
        {
            return SearchForm(html, new RouteValueDictionary(routeValues));
        }

        public static MvcForm SearchForm(this HtmlHelper html, RouteValueDictionary routeValues)
        {
            var formAction = UrlHelper.GenerateUrl(null, null, null, routeValues, html.RouteCollection, html.ViewContext.RequestContext, true);
            return GenerateForm(html, formAction, FormMethod.Post, null, FormLayout.Search);
        }

        public static MvcForm SearchForm(this HtmlHelper html, string actionName, string controllerName)
        {
            return SearchForm(html, actionName, controllerName, new{});
        }

        public static MvcForm SearchForm(this HtmlHelper html, string actionName, string controllerName, object routeVals)
        {
            return SearchForm(html, actionName, controllerName, new RouteValueDictionary(routeVals));
        }

        public static MvcForm SearchForm(this HtmlHelper html, string actionName, string controllerName, RouteValueDictionary routeVals)
        {
            return SearchForm(html, actionName, controllerName, routeVals, FormMethod.Post, null);
        }

        public static MvcForm SearchForm(this HtmlHelper html, string actionName, string controllerName, FormMethod formMethod)
        {
            return SearchForm(html, actionName, controllerName, formMethod, new Dictionary<string, object>());
        }

        public static MvcForm SearchForm(this HtmlHelper html, string actionName, string controllerName, object routeVals, FormMethod formMethod)
        {
            return SearchForm(html, actionName, controllerName, new RouteValueDictionary(routeVals), formMethod);
        }

        public static MvcForm SearchForm(this HtmlHelper html, string actionName, string controllerName, RouteValueDictionary routeVals, FormMethod formMethod)
        {
            return SearchForm(html, actionName, controllerName, routeVals, formMethod, new{});
        }

        public static MvcForm SearchForm(this HtmlHelper html, string actionName, string controllerName, FormMethod formMethod, object htmlAttributes)
        {
            return SearchForm(html, actionName, controllerName, formMethod, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }
        
        public static MvcForm SearchForm(this HtmlHelper html, string actionName, string controllerName, FormMethod formMethod, IDictionary<string, object> htmlAttributes)
        {
            var formAction = UrlHelper.GenerateUrl(null, actionName, controllerName, new RouteValueDictionary(), html.RouteCollection, html.ViewContext.RequestContext, true);
            return GenerateForm(html, formAction, formMethod, htmlAttributes, FormLayout.Search);
        }

        public static MvcForm SearchForm(this HtmlHelper html, string actionName, string controllerName, object routeVals, FormMethod formMethod, object htmlAttributes)
        {
            return SearchForm(html, actionName, controllerName, new RouteValueDictionary(routeVals), formMethod, htmlAttributes);
        }

        public static MvcForm SearchForm(this HtmlHelper html, string actionName, string controllerName, RouteValueDictionary routeVals, FormMethod formMethod, object htmlAttributes)
        {
            return SearchForm(html, actionName, controllerName, routeVals, formMethod, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcForm SearchForm(this HtmlHelper html, string actionName, string controllerName, RouteValueDictionary routeVals, FormMethod formMethod, IDictionary<string, object> htmlAttributes)
        {
            var formAction = UrlHelper.GenerateUrl(null, actionName, controllerName, new RouteValueDictionary(routeVals), html.RouteCollection, html.ViewContext.RequestContext, true);
            return GenerateForm(html, formAction, formMethod, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes), FormLayout.Search);
        }

        #endregion

        #region Inline Form

        public static MvcForm InlineForm(this HtmlHelper html)
        {
            var rawUrl = html.ViewContext.HttpContext.Request.RawUrl;
            return GenerateForm(html, rawUrl, FormMethod.Post, null, FormLayout.Inline);
        }

        public static MvcForm InlineForm(this HtmlHelper html, object routeValues)
        {
            return InlineForm(html, new RouteValueDictionary(routeValues));
        }

        public static MvcForm InlineForm(this HtmlHelper html, RouteValueDictionary routeValues)
        {
            var formAction = UrlHelper.GenerateUrl(null, null, null, routeValues, html.RouteCollection, html.ViewContext.RequestContext, true);
            return GenerateForm(html, formAction, FormMethod.Post, null, FormLayout.Inline);
        }

        public static MvcForm InlineForm(this HtmlHelper html, string actionName, string controllerName)
        {
            return InlineForm(html, actionName, controllerName, new{});
        }

        public static MvcForm InlineForm(this HtmlHelper html, string actionName, string controllerName, object routeVals)
        {
            return InlineForm(html, actionName, controllerName, new RouteValueDictionary(routeVals));
        }

        public static MvcForm InlineForm(this HtmlHelper html, string actionName, string controllerName, RouteValueDictionary routeVals)
        {
            return InlineForm(html, actionName, controllerName, routeVals, FormMethod.Post, null);
        }

        public static MvcForm InlineForm(this HtmlHelper html, string actionName, string controllerName, FormMethod formMethod)
        {
            return InlineForm(html, actionName, controllerName, formMethod, new Dictionary<string, object>());
        }

        public static MvcForm InlineForm(this HtmlHelper html, string actionName, string controllerName, object routeVals, FormMethod formMethod)
        {
            return InlineForm(html, actionName, controllerName, new RouteValueDictionary(routeVals), formMethod);
        }

        public static MvcForm InlineForm(this HtmlHelper html, string actionName, string controllerName, RouteValueDictionary routeVals, FormMethod formMethod)
        {
            return InlineForm(html, actionName, controllerName, routeVals, formMethod, new{});
        }

        public static MvcForm InlineForm(this HtmlHelper html, string actionName, string controllerName, FormMethod formMethod, object htmlAttributes)
        {
            return InlineForm(html, actionName, controllerName, formMethod, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }
        
        public static MvcForm InlineForm(this HtmlHelper html, string actionName, string controllerName, FormMethod formMethod, IDictionary<string, object> htmlAttributes)
        {
            var formAction = UrlHelper.GenerateUrl(null, actionName, controllerName, new RouteValueDictionary(), html.RouteCollection, html.ViewContext.RequestContext, true);
            return GenerateForm(html, formAction, formMethod, htmlAttributes, FormLayout.Inline);
        }

        public static MvcForm InlineForm(this HtmlHelper html, string actionName, string controllerName, object routeVals, FormMethod formMethod, object htmlAttributes)
        {
            return InlineForm(html, actionName, controllerName, new RouteValueDictionary(routeVals), formMethod, htmlAttributes);
        }

        public static MvcForm InlineForm(this HtmlHelper html, string actionName, string controllerName, RouteValueDictionary routeVals, FormMethod formMethod, object htmlAttributes)
        {
            return InlineForm(html, actionName, controllerName, routeVals, formMethod, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcForm InlineForm(this HtmlHelper html, string actionName, string controllerName, RouteValueDictionary routeVals, FormMethod formMethod, IDictionary<string, object> htmlAttributes)
        {
            var formAction = UrlHelper.GenerateUrl(null, actionName, controllerName, new RouteValueDictionary(routeVals), html.RouteCollection, html.ViewContext.RequestContext, true);
            return GenerateForm(html, formAction, formMethod, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes), FormLayout.Inline);
        }

        #endregion

        #region Horizontal Form

        public static MvcForm HorizontalForm(this HtmlHelper html)
        {
            var rawUrl = html.ViewContext.HttpContext.Request.RawUrl;
            return GenerateForm(html, rawUrl, FormMethod.Post, null, FormLayout.Horizontal);
        }

        public static MvcForm HorizontalForm(this HtmlHelper html, object routeValues)
        {
            return HorizontalForm(html, new RouteValueDictionary(routeValues));
        }

        public static MvcForm HorizontalForm(this HtmlHelper html, RouteValueDictionary routeValues)
        {
            var formAction = UrlHelper.GenerateUrl(null, null, null, routeValues, html.RouteCollection, html.ViewContext.RequestContext, true);
            return GenerateForm(html, formAction, FormMethod.Post, null, FormLayout.Horizontal);
        }

        public static MvcForm HorizontalForm(this HtmlHelper html, string actionName, string controllerName)
        {
            return HorizontalForm(html, actionName, controllerName, new{});
        }

        public static MvcForm HorizontalForm(this HtmlHelper html, string actionName, string controllerName, object routeVals)
        {
            return HorizontalForm(html, actionName, controllerName, new RouteValueDictionary(routeVals));
        }

        public static MvcForm HorizontalForm(this HtmlHelper html, string actionName, string controllerName, RouteValueDictionary routeVals)
        {
            return HorizontalForm(html, actionName, controllerName, routeVals, FormMethod.Post, null);
        }

        public static MvcForm HorizontalForm(this HtmlHelper html, string actionName, string controllerName, FormMethod formMethod)
        {
            return HorizontalForm(html, actionName, controllerName, formMethod, new Dictionary<string, object>());
        }

        public static MvcForm HorizontalForm(this HtmlHelper html, string actionName, string controllerName, object routeVals, FormMethod formMethod)
        {
            return HorizontalForm(html, actionName, controllerName, new RouteValueDictionary(routeVals), formMethod);
        }

        public static MvcForm HorizontalForm(this HtmlHelper html, string actionName, string controllerName, RouteValueDictionary routeVals, FormMethod formMethod)
        {
            return HorizontalForm(html, actionName, controllerName, routeVals, formMethod, new{});
        }

        public static MvcForm HorizontalForm(this HtmlHelper html, string actionName, string controllerName, FormMethod formMethod, object htmlAttributes)
        {
            return HorizontalForm(html, actionName, controllerName, formMethod, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }
        
        public static MvcForm HorizontalForm(this HtmlHelper html, string actionName, string controllerName, FormMethod formMethod, IDictionary<string, object> htmlAttributes)
        {
            var formAction = UrlHelper.GenerateUrl(null, actionName, controllerName, new RouteValueDictionary(), html.RouteCollection, html.ViewContext.RequestContext, true);
            return GenerateForm(html, formAction, formMethod, htmlAttributes, FormLayout.Horizontal);
        }

        public static MvcForm HorizontalForm(this HtmlHelper html, string actionName, string controllerName, object routeVals, FormMethod formMethod, object htmlAttributes)
        {
            return HorizontalForm(html, actionName, controllerName, new RouteValueDictionary(routeVals), formMethod, htmlAttributes);
        }

        public static MvcForm HorizontalForm(this HtmlHelper html, string actionName, string controllerName, RouteValueDictionary routeVals, FormMethod formMethod, object htmlAttributes)
        {
            return HorizontalForm(html, actionName, controllerName, routeVals, formMethod, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcForm HorizontalForm(this HtmlHelper html, string actionName, string controllerName, RouteValueDictionary routeVals, FormMethod formMethod, IDictionary<string, object> htmlAttributes)
        {
            var formAction = UrlHelper.GenerateUrl(null, actionName, controllerName, new RouteValueDictionary(routeVals), html.RouteCollection, html.ViewContext.RequestContext, true);
            return GenerateForm(html, formAction, formMethod, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes), FormLayout.Horizontal);
        }

        #endregion

    }
}
