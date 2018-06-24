using System;
using System.Web;
using System.Web.Mvc;

namespace UmbracoToolkit.Extensions
{
    public static class ViewExtension
    {
        /// <summary>
        /// Time ago html helper.
        /// </summary>
        /// <param name="helper">The helper.</param>
        /// <param name="time">The time.</param>
        /// <param name="format">The format.</param>
        /// <returns></returns>
        public static IHtmlString TimeAgo(this HtmlHelper helper, DateTime time, string format = "MM/dd/yyyy hh:mm:ss tt")
        {
            return new HtmlString($@"<time datetime='{time.ToString(format, System.Globalization.CultureInfo.InvariantCulture)}' class='timeago'></time>");
        }
    }
}
