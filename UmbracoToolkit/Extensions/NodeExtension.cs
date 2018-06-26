﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.XPath;
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
        public static IEnumerable<Link> GetRelatedLinks(this IPublishedContent node, string relatedLinkPropertyName)
        {
            if (node == null || string.IsNullOrWhiteSpace(relatedLinkPropertyName))
                return null;

            var relatedLinks = node.GetPropertyValue<RelatedLinks>(relatedLinkPropertyName);
            if (relatedLinks == null || !relatedLinks.Any())
                return null;

            return relatedLinks.Select(x => new Link
            {
                Url = x.Link,
                Name = x.Caption,
                IsNewWindow = x.NewWindow
            });
        }

        /// <summary>
        /// Selects the navigator.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context">The context.</param>
        /// <param name="xpath">The xpath.</param>
        /// <param name="select">The select.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="skip">The skip.</param>
        /// <param name="take">The take.</param>
        /// <returns></returns>
        public static List<T> SelectNavigator<T>(this UmbracoContext context,
            string xpath,
            Func<XPathNavigator, T> select,
            Func<XPathNavigator, object> orderBy = null,
            int? skip = 0,
            int? take = int.MaxValue
            )
        {
            var navigator = context.ContentCache.GetXPathNavigator();
            var nodes = navigator.Select(xpath)
                .Cast<XPathNavigator>()
                .OrderByDescending(orderBy ?? (x => true))
                .Skip(skip ?? 0)
                .Take(take ?? int.MaxValue)
                .Select(select);

            return nodes.ToList();
        }
    }
}
