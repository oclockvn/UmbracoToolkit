using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Umbraco.Core.Models;
using Umbraco.Web;
using Umbraco.Web.Mvc;
using UmbracoToolkit.Extensions;
using UmbracoToolkit.Models;

namespace UmbracoToolkit.Controllers
{
    public class BaseController : SurfaceController
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
        public IPublishedContent HomeNode => _homeNode ?? (_homeNode = CurrentPage?.GetHomeNode(HomeDocumentTypeAlias));

        /// <summary>
        /// Gets the home node.
        /// </summary>
        /// <param name="currentPageId">The current page identifier.</param>
        /// <returns></returns>
        public IPublishedContent GetHomeNode(int currentPageId) => _homeNode ?? (_homeNode = Umbraco.GetHomeNode(currentPageId, HomeDocumentTypeAlias));

        /// <summary>
        /// Gets the menu items.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <param name="menuLevel">The menu level.</param>
        /// <param name="level">The level.</param>
        /// <returns>A list of type <see cref="Menu"/></returns>
        private List<Menu> GetMenuItems(IPublishedContent node, int menuLevel, int level = 0, int? currentPageId = null)
        {
            if (level > menuLevel)
                return null;
            
            var currentLevel = level + 1;
            //var currentPage = currentPageId.HasValue && currentPageId > 0 ? Umbraco.TypedContent(currentPageId) : CurrentPage;

            return node
                ?.Children(x => x.IsVisible())
                ?.Select(x => new Menu
                {
                    Name = x.Name,
                    Id = x.Id,
                    IsActive = CurrentPage != null && x.IsAncestorOrSelf(CurrentPage),
                    Url = x.Url,
                    Chilren = x.GetPropertyValue<bool>(ShowSubMenuAlias) ? GetMenuItems(x, menuLevel, currentLevel) : null
                })
                .ToList()
                ;
        }

        /// <summary>
        /// Gets the main menu.
        /// </summary>
        /// <param name="maxDepth">The maximum depth. Default is 2 level.</param>
        /// <param name="currentPageId">The current page identifier.</param>
        /// <returns>
        /// A list of type <see cref="Menu" />
        /// </returns>
        /// <value>
        /// The main menu.
        /// </value>
        public List<Menu> GetMainMenu(int maxDepth = 2, int? currentPageId = null) => GetMenuItems(currentPageId.HasValue ? GetHomeNode(currentPageId.Value) : HomeNode, maxDepth, 0, currentPageId);

        /// <summary>
        /// Gets the breadcrumb.
        /// </summary>
        /// <value>
        /// The breadcrumb.
        /// </value>
        public virtual Breadcrumb Breadcrumb
        {
            get
            {
                var homeNodeId = HomeNode.Id;
                return new Breadcrumb
                {
                    //IsHomepage = CurrentPage.Id == HomeNode.Id,
                    Current = new CmsBreadcrumbItem { Name = CurrentPage.Name },
                    Parts = CurrentPage
                        ?.Ancestors()
                        ?.OrderBy(x => x.Level)
                        .Select(x => new CmsBreadcrumbItem
                        {
                            Name = x.Name,
                            Url = x.Url,
                            IsHomepage = x.Id == homeNodeId
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
        public virtual List<Models.Language> Languages
        {
            get
            {
                var homeNodeId = HomeNode.Id;
                return Umbraco
                    .TypedContentAtRoot()
                    ?.Select(x => new Models.Language
                    {
                        Name = x.Name,
                        Url = x.Url,
                        IsActive = !string.IsNullOrWhiteSpace(homeNodeId + string.Empty) && x.Path.Contains(homeNodeId + string.Empty)
                    }).ToList()
                    ;
            }
        }

        /// <summary>
        /// Ensures the no view extension.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception">View name is not valid!</exception>
        private string EnsureNoViewExtension(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new Exception("View name is not valid!");

            return !name.EndsWith(".cshtml") ? name : name.Substring(0, name.Length - 7); // ".cshtml".Length == 7
        }

        /// <summary>
        /// Maps the view path.
        /// </summary>
        /// <param name="viewName">Name of the view.</param>
        /// <param name="viewFolder">The view folder.</param>
        /// <returns></returns>
        protected string MapViewPath(string viewName, string viewFolder)
        {
            return string.IsNullOrWhiteSpace(viewFolder) 
                ? $"~/Views/{EnsureNoViewExtension(viewName)}.cshtml"
                : $"~/Views/{viewFolder.TrimEnd('/')}/{EnsureNoViewExtension(viewName)}.cshtml";
        }

        /// <summary>
        /// return the partial with given folder and view name
        /// </summary>
        /// <param name="viewName">Name of the view.</param>
        /// <param name="model">The model.</param>
        /// <param name="viewFolder">The view folder.</param>
        /// <param name="useSharedFolderIfNoSpecifyViewFolder">if set to <c>true</c> [use shared folder if no specify view folder].</param>
        /// <returns></returns>
        protected ActionResult CmsPartial(string viewName, object model = null, string viewFolder = null, bool useSharedFolderIfNoSpecifyViewFolder = true)
        {
            if (string.IsNullOrWhiteSpace(viewFolder) && useSharedFolderIfNoSpecifyViewFolder)
                viewFolder = "Shared";

            return model == null ? PartialView(MapViewPath(viewName, viewFolder)) : PartialView(MapViewPath(viewName, viewFolder), model);
        }
    }
}
