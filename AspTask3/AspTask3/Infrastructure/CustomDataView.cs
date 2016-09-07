using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspTask3.Infrastructure
{
    public class CustomDataView : IView
    {
        public void Render(ViewContext viewContext, TextWriter writer)
        {
            Write(writer, "Routing data");
            foreach (string key in viewContext.RouteData.Values.Keys)
            {
                Write(writer, "Key: {0}, value: {0}", key,viewContext.RouteData.Values[key]);
            }
            Write(writer, "View Data");

            foreach (string key in viewContext.RouteData.Values.Keys)
            {
                Write(writer, "Key: {0}, value: {0}", key, viewContext.ViewData[key]);
            }
        }


        private void Write(TextWriter writer, string template, params object[] values)
        {
            writer.Write(string.Format(template, values) + "<p/>");
        }
    }
}