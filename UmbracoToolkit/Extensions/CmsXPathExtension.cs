using UmbracoToolkit.Helpers;

namespace UmbracoToolkit.Extensions
{
    public static class CmsXPathExtension
    {
        //public static CmsXPath WithRoot(this CmsXPath xpath)
        //{
        //    xpath.XPath = "/";
        //    return xpath;
        //}

        public static CmsXPath WithChild(this CmsXPath xpath, string child)
        {
            xpath.XPath += "/" + child;

            return xpath;
        }

        public static CmsXPath WithDescendant(this CmsXPath xpath, string descendant)
        {
            xpath.XPath += "//" + descendant;

            return xpath;
        }

        public static CmsXPath Where(this CmsXPath xpath, string condition)
        {
            xpath.XPath = xpath.XPath.TrimEnd() + " [" + condition.Trim('[', ']').Trim() + "]";
            return xpath;
        }
    }
}
