using BootstrapExtensions.Common;

namespace BootstrapExtensions.Base
{
    public class HtmlListBuilder
    {
        private readonly HtmlList _list;

        public HtmlListBuilder(HtmlList list)
        {
            _list = list;
        }

        public void Item(string text)
        {
            _list.ListItems.Add(new HtmlListItem(text));
        }

        public HtmlListItem Link(string text, string url, string identifier = null)
        {
            return Link(text, url, null, identifier);
        }

        public HtmlListItem Link(string text, string url, object htmlAttributes, string identifier = null)
        {
            var attrs = new HtmlAttributes(htmlAttributes);
            var link = new HtmlListItem(string.Format("<a href=\"{0}\" {2}>{1}</a>", url, text, attrs));
            var currActive = _list.HtmlAttributes["data-activeLink"];
            if (!string.IsNullOrEmpty(identifier) && currActive == identifier) link.Active();
            _list.ListItems.Add(link);
            return link;
        }

        /*/// <summary>
    /// Returns an anchor element (a element) that contains the virtual path of the specified action.
    /// </summary>
    /// 
    /// <returns>
    /// An anchor element (a element).
    /// </returns>
    /// <param name="htmlHelper">The HTML helper instance that this method extends.</param><param name="linkText">The inner text of the anchor element.</param><param name="actionName">The name of the action.</param><exception cref="T:System.ArgumentException">The <paramref name="linkText"/> parameter is null or empty.</exception>
    public static MvcHtmlString ActionLink(this HtmlHelper htmlHelper, string linkText, string actionName)
    {
      return LinkExtensions.ActionLink(htmlHelper, linkText, actionName, (string) null, new RouteValueDictionary(), (IDictionary<string, object>) new RouteValueDictionary());
    }

    /// <summary>
    /// Returns an anchor element (a element) that contains the virtual path of the specified action.
    /// </summary>
    /// 
    /// <returns>
    /// An anchor element (a element).
    /// </returns>
    /// <param name="htmlHelper">The HTML helper instance that this method extends.</param><param name="linkText">The inner text of the anchor element.</param><param name="actionName">The name of the action.</param><param name="routeValues">An object that contains the parameters for a route. The parameters are retrieved through reflection by examining the properties of the object. The object is typically created by using object initializer syntax.</param><exception cref="T:System.ArgumentException">The <paramref name="linkText"/> parameter is null or empty.</exception>
    public static MvcHtmlString ActionLink(this HtmlHelper htmlHelper, string linkText, string actionName, object routeValues)
    {
      return LinkExtensions.ActionLink(htmlHelper, linkText, actionName, (string) null, new RouteValueDictionary(routeValues), (IDictionary<string, object>) new RouteValueDictionary());
    }

    /// <summary>
    /// Returns an anchor element (a element) that contains the virtual path of the specified action.
    /// </summary>
    /// 
    /// <returns>
    /// An anchor element (a element).
    /// </returns>
    /// <param name="htmlHelper">The HTML helper instance that this method extends.</param><param name="linkText">The inner text of the anchor element.</param><param name="actionName">The name of the action.</param><param name="routeValues">An object that contains the parameters for a route. The parameters are retrieved through reflection by examining the properties of the object. The object is typically created by using object initializer syntax.</param><param name="htmlAttributes">An object that contains the HTML attributes for the element. The attributes are retrieved through reflection by examining the properties of the object. The object is typically created by using object initializer syntax.</param><exception cref="T:System.ArgumentException">The <paramref name="linkText"/> parameter is null or empty.</exception>
    public static MvcHtmlString ActionLink(this HtmlHelper htmlHelper, string linkText, string actionName, object routeValues, object htmlAttributes)
    {
      return LinkExtensions.ActionLink(htmlHelper, linkText, actionName, (string) null, new RouteValueDictionary(routeValues), (IDictionary<string, object>) HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
    }

    /// <summary>
    /// Returns an anchor element (a element) that contains the virtual path of the specified action.
    /// </summary>
    /// 
    /// <returns>
    /// An anchor element (a element).
    /// </returns>
    /// <param name="htmlHelper">The HTML helper instance that this method extends.</param><param name="linkText">The inner text of the anchor element.</param><param name="actionName">The name of the action.</param><param name="routeValues">An object that contains the parameters for a route.</param><exception cref="T:System.ArgumentException">The <paramref name="linkText"/> parameter is null or empty.</exception>
    public static MvcHtmlString ActionLink(this HtmlHelper htmlHelper, string linkText, string actionName, RouteValueDictionary routeValues)
    {
      return LinkExtensions.ActionLink(htmlHelper, linkText, actionName, (string) null, routeValues, (IDictionary<string, object>) new RouteValueDictionary());
    }

    /// <summary>
    /// Returns an anchor element (a element) that contains the virtual path of the specified action.
    /// </summary>
    /// 
    /// <returns>
    /// An anchor element (a element).
    /// </returns>
    /// <param name="htmlHelper">The HTML helper instance that this method extends.</param><param name="linkText">The inner text of the anchor element.</param><param name="actionName">The name of the action.</param><param name="routeValues">An object that contains the parameters for a route.</param><param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param><exception cref="T:System.ArgumentException">The <paramref name="linkText"/> parameter is null or empty.</exception>
    public static MvcHtmlString ActionLink(this HtmlHelper htmlHelper, string linkText, string actionName, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes)
    {
      return LinkExtensions.ActionLink(htmlHelper, linkText, actionName, (string) null, routeValues, htmlAttributes);
    }

    /// <summary>
    /// Returns an anchor element (a element) that contains the virtual path of the specified action.
    /// </summary>
    /// 
    /// <returns>
    /// An anchor element (a element).
    /// </returns>
    /// <param name="htmlHelper">The HTML helper instance that this method extends.</param><param name="linkText">The inner text of the anchor element.</param><param name="actionName">The name of the action.</param><param name="controllerName">The name of the controller.</param><exception cref="T:System.ArgumentException">The <paramref name="linkText"/> parameter is null or empty.</exception>
    public static MvcHtmlString ActionLink(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName)
    {
      return LinkExtensions.ActionLink(htmlHelper, linkText, actionName, controllerName, new RouteValueDictionary(), (IDictionary<string, object>) new RouteValueDictionary());
    }

    /// <summary>
    /// Returns an anchor element (a element) that contains the virtual path of the specified action.
    /// </summary>
    /// 
    /// <returns>
    /// An anchor element (a element).
    /// </returns>
    /// <param name="htmlHelper">The HTML helper instance that this method extends.</param><param name="linkText">The inner text of the anchor element.</param><param name="actionName">The name of the action.</param><param name="controllerName">The name of the controller.</param><param name="routeValues">An object that contains the parameters for a route. The parameters are retrieved through reflection by examining the properties of the object. The object is typically created by using object initializer syntax.</param><param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param><exception cref="T:System.ArgumentException">The <paramref name="linkText"/> parameter is null or empty.</exception>
    public static MvcHtmlString ActionLink(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName, object routeValues, object htmlAttributes)
    {
      return LinkExtensions.ActionLink(htmlHelper, linkText, actionName, controllerName, new RouteValueDictionary(routeValues), (IDictionary<string, object>) HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
    }

    /// <summary>
    /// Returns an anchor element (a element) that contains the virtual path of the specified action.
    /// </summary>
    /// 
    /// <returns>
    /// An anchor element (a element).
    /// </returns>
    /// <param name="htmlHelper">The HTML helper instance that this method extends.</param><param name="linkText">The inner text of the anchor element.</param><param name="actionName">The name of the action.</param><param name="controllerName">The name of the controller.</param><param name="routeValues">An object that contains the parameters for a route.</param><param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param><exception cref="T:System.ArgumentException">The <paramref name="linkText"/> parameter is null or empty.</exception>
    public static MvcHtmlString ActionLink(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes)
    {
      if (string.IsNullOrEmpty(linkText))
        throw new ArgumentException(MvcResources.Common_NullOrEmpty, "linkText");
      else
        return MvcHtmlString.Create(HtmlHelper.GenerateLink(htmlHelper.ViewContext.RequestContext, htmlHelper.RouteCollection, linkText, (string) null, actionName, controllerName, routeValues, htmlAttributes));
    }

    /// <summary>
    /// Returns an anchor element (a element) that contains the virtual path of the specified action.
    /// </summary>
    /// 
    /// <returns>
    /// An anchor element (a element).
    /// </returns>
    /// <param name="htmlHelper">The HTML helper instance that this method extends.</param><param name="linkText">The inner text of the anchor element.</param><param name="actionName">The name of the action.</param><param name="controllerName">The name of the controller.</param><param name="protocol">The protocol for the URL, such as "http" or "https".</param><param name="hostName">The host name for the URL.</param><param name="fragment">The URL fragment name (the anchor name).</param><param name="routeValues">An object that contains the parameters for a route. The parameters are retrieved through reflection by examining the properties of the object. The object is typically created by using object initializer syntax.</param><param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param><exception cref="T:System.ArgumentException">The <paramref name="linkText"/> parameter is null or empty.</exception>
    public static MvcHtmlString ActionLink(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName, string protocol, string hostName, string fragment, object routeValues, object htmlAttributes)
    {
      return LinkExtensions.ActionLink(htmlHelper, linkText, actionName, controllerName, protocol, hostName, fragment, new RouteValueDictionary(routeValues), (IDictionary<string, object>) HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
    }

    /// <summary>
    /// Returns an anchor element (a element) that contains the virtual path of the specified action.
    /// </summary>
    /// 
    /// <returns>
    /// An anchor element (a element).
    /// </returns>
    /// <param name="htmlHelper">The HTML helper instance that this method extends.</param><param name="linkText">The inner text of the anchor element.</param><param name="actionName">The name of the action.</param><param name="controllerName">The name of the controller.</param><param name="protocol">The protocol for the URL, such as "http" or "https".</param><param name="hostName">The host name for the URL.</param><param name="fragment">The URL fragment name (the anchor name).</param><param name="routeValues">An object that contains the parameters for a route.</param><param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param><exception cref="T:System.ArgumentException">The <paramref name="linkText"/> parameter is null or empty.</exception>
    public static MvcHtmlString ActionLink(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName, string protocol, string hostName, string fragment, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes)
    {
      if (string.IsNullOrEmpty(linkText))
        throw new ArgumentException(MvcResources.Common_NullOrEmpty, "linkText");
      else
        return MvcHtmlString.Create(HtmlHelper.GenerateLink(htmlHelper.ViewContext.RequestContext, htmlHelper.RouteCollection, linkText, (string) null, actionName, controllerName, protocol, hostName, fragment, routeValues, htmlAttributes));
    }*/

        public void Divider()
        {
            _list.ListItems.Add(new HtmlListItem().Divider());
        }
    }
}