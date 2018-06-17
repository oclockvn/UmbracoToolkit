using System.Collections.Generic;

namespace UmbracoToolkit.Models
{
    /// <summary>
    /// Represent cms breadcrumb
    /// </summary>
    /// <seealso cref="UmbracoToolkit.Models.CmsDocumentBase" />
    public class CmsBreadcrumb
    {
        /// <summary>
        /// Gets or sets the parts.
        /// </summary>
        /// <value>
        /// The parts.
        /// </value>
        public List<CmsBreadcrumbItem> Parts { get; set; }

        /// <summary>
        /// Gets or sets the current.
        /// </summary>
        /// <value>
        /// The current.
        /// </value>
        public CmsBreadcrumbItem Current { get; set; }
    }

    public class CmsBreadcrumbItem : CmsDocumentBase
    {
        /// <summary>
        /// Gets or sets a value indicating whether this instance is homepage.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is homepage; otherwise, <c>false</c>.
        /// </value>
        public bool IsHomepage { get; set; }
    }
}
