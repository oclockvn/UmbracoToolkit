using System.Collections.Generic;

namespace UmbracoToolkit.Models
{
    public class CmsBreadcrumb : CmsModelBase
    {
        /// <summary>
        /// Gets or sets a value indicating whether this instance is homepage.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is homepage; otherwise, <c>false</c>.
        /// </value>
        public bool IsHomepage { get; set; }

        /// <summary>
        /// Gets or sets the parts.
        /// </summary>
        /// <value>
        /// The parts.
        /// </value>
        public List<CmsModelBase> Parts { get; set; }

        /// <summary>
        /// Gets or sets the current.
        /// </summary>
        /// <value>
        /// The current.
        /// </value>
        public CmsModelBase Current { get; set; }
    }
}
