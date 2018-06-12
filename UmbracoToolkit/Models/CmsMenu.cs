using System.Collections.Generic;

namespace UmbracoToolkit.Models
{
    /// <summary>
    /// Represent cms menu
    /// </summary>
    /// <seealso cref="UmbracoToolkit.Models.CmsDocumentBase" />
    public class CmsMenu : CmsDocumentBase
    {
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the sub menu.
        /// </summary>
        /// <value>
        /// The sub menu.
        /// </value>
        public List<CmsMenu> Chilren { get; set; }

        /// <summary>
        /// Gets a value indicating whether this instance has child.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has child; otherwise, <c>false</c>.
        /// </value>
        public bool HasChild => Chilren != null && Chilren.Count > 0;
    }
}
