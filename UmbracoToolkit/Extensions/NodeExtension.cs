using System.Collections.Generic;
using System.Linq;
using Umbraco.Core.Models;
using Umbraco.Web;
using Umbraco.Web.Models;
using UmbracoToolkit.Models;

namespace UmbracoToolkit.Extensions
{
    public static class NodeExtension
    {
        /// <summary>
        /// Gets the home node.
        /// </summary>
        /// <param name="currentPage">The current page.</param>
        /// <param name="homeAlias">The home alias.</param>
        /// <returns></returns>
        public static IPublishedContent GetHomeNode(this IPublishedContent currentPage, string homeAlias) => currentPage?.Site()?.DescendantOrSelf(homeAlias);

        /// <summary>
        /// Gets the home node.
        /// </summary>
        /// <param name="helper">The helper.</param>
        /// <param name="currentPageId">The current page identifier.</param>
        /// <param name="homeAlias">The home alias.</param>
        /// <returns></returns>
        public static IPublishedContent GetHomeNode(this UmbracoHelper helper, int currentPageId, string homeAlias) => GetHomeNode(helper.TypedContent(currentPageId), homeAlias);

        /// <summary>
        /// Gets the related links.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <param name="relatedLinkPropertyName">Name of the related link property.</param>
        /// <returns></returns>
        public static IEnumerable<CmsLink> GetRelatedLinks(this IPublishedContent node, string relatedLinkPropertyName)
        {
            if (node == null || string.IsNullOrWhiteSpace(relatedLinkPropertyName))
                return null;

            var relatedLinks = node.GetPropertyValue<RelatedLinks>(relatedLinkPropertyName);
            if (relatedLinks == null || !relatedLinks.Any())
                return null;

            return relatedLinks.Select(x => new CmsLink
            {
                Url = x.Link,
                Name = x.Caption,
                IsNewWindow = x.NewWindow
            });
        }
    }
}
