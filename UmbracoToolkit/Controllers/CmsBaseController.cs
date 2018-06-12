using System.Collections.Generic;
using System.Linq;
using Umbraco.Core.Models;
using Umbraco.Web;
using Umbraco.Web.Mvc;
using UmbracoToolkit.Extensions;
using UmbracoToolkit.Models;

namespace UmbracoToolkit.Controllers
{
    public class CmsBaseController : SurfaceController
    {
        private IPublishedContent _homeNode;

        /// <summary>
        /// Gets the home document type alias.
        /// </summary>
        /// <value>
        /// The home document type alias.
        /// </value>
        protected virtual string HomeDocumentTypeAlias => "homeDocument";

        /// <summary>
        /// Gets the show sub menu alias.
        /// </summary>
        /// <value>
        /// The show sub menu alias.
        /// </value>
        protected virtual string ShowSubMenuAlias => "showSubMenu";

        /// <summary>
        /// Gets the home node.
        /// </summary>
        /// <value>
        /// The home node.
        /// </value>
        public IPublishedContent HomeNode => _homeNode ?? (_homeNode = CurrentPage.GetHomeNode(HomeDocumentTypeAlias));

        /// <summary>
        /// Gets the menu items.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <param name="menuLevel">The menu level.</param>
        /// <param name="level">The level.</param>
        /// <returns>A list of type <see cref="CmsMenu"/></returns>
        private List<CmsMenu> GetMenuItems(IPublishedContent node, int menuLevel, int level = 0)
        {
            if (level > menuLevel)
                return null;

            var currentLevel = level + 1;

            return node
                ?.Children(x => x.IsVisible())
                ?.Select(x => new CmsMenu
                {
                    Name = x.Name,
                    Id = x.Id,
                    IsActive = x.IsAncestorOrSelf(CurrentPage),
                    Url = x.Url,
                    Chilren = x.GetPropertyValue<bool>(ShowSubMenuAlias) ? GetMenuItems(x, menuLevel, currentLevel) : null
                })
                .ToList()
                ;
        }

        /// <summary>
        /// Gets the main menu.
        /// </summary>
        /// <param name="maxDepth">The maximum depth. Default is 3 level.</param>
        /// <returns>A list of type <see cref="CmsMenu"/></returns>
        /// <value>
        /// The main menu.
        /// </value>
        public List<CmsMenu> GetMainMenu(int maxDepth = 3) => GetMenuItems(HomeNode, maxDepth);

        /// <summary>
        /// Gets the breadcrumb.
        /// </summary>
        /// <value>
        /// The breadcrumb.
        /// </value>
        public virtual CmsBreadcrumb Breadcrumb
        {
            get
            {
                return new CmsBreadcrumb
                {
                    IsHomepage = CurrentPage.Id == HomeNode.Id,
                    Current = new CmsDocumentBase { Name = CurrentPage.Name },
                    Parts = CurrentPage
                        ?.Ancestors()
                        ?.OrderBy(x => x.Level)
                        .Select(x => new CmsDocumentBase
                        {
                            Name = x.Name,
                            Url = x.Url
                        }).ToList()
                };
            }
        }

        /// <summary>
        /// Gets the languages in case your site is using multiple languages. If so, language node is the root node of all child nodes
        /// </summary>
        /// <value>
        /// The languages.
        /// </value>
        public virtual List<CmsLanguage> Languages
        {
            get
            {
                return Umbraco
                    .TypedContentAtRoot()
                    ?.Select(x => new CmsLanguage
                    {
                        Name = x.Name,
                        Url = x.Url,
                        IsActive = !string.IsNullOrWhiteSpace(HomeNode.Id + string.Empty) && x.Path.Contains(HomeNode.Id + string.Empty)
                    }).ToList()
                    ;
            }
        }
    }
}
