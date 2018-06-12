using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UmbracoToolkit.Helpers;

namespace UmbracoToolkit.Extensions
{
    public static class CmsXPathExtension
    {
        public static CmsXPath WithRoot(this CmsXPath xpath)
        {
            xpath.XPath = "/";
            return xpath;
        }

        public static CmsXPath WithChild(this CmsXPath xpath, string child, string where = null)
        {
            xpath.XPath += child;

            return xpath;
        }
    }
}
