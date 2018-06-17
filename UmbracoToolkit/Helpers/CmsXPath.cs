namespace UmbracoToolkit.Helpers
{
    public class CmsXPath
    {
        public string XPath { get; set; }

        public static CmsXPath Begin => new CmsXPath();
    }

    public class CmsXPathPredicater
    {
        public string Predicate { get; set; }
    }
}
