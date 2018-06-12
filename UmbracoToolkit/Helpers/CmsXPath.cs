using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmbracoToolkit.Helpers
{
    public class CmsXPath
    {
        public string XPath { get; set; }

        public static CmsXPath Begin => new CmsXPath();
    }
}
