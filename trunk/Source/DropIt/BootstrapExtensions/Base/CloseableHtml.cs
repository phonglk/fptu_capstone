using System;
using System.Web.Mvc;

namespace BootstrapExtensions.Base
{
    public class CloseableHtml : IDisposable
    {
        private readonly ViewContext _viewContext;
        private readonly string _closingHtml;

        public CloseableHtml(ViewContext viewContext, string closingHtml)
        {
            _viewContext = viewContext;
            _closingHtml = closingHtml;
        }

        public void Dispose()
        {
            _viewContext.Writer.Write(_closingHtml);
        }
    }
}