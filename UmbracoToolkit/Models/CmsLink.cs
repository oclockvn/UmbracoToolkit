namespace UmbracoToolkit.Models
{
    /// <summary>
    /// Represent cms related link
    /// </summary>
    /// <seealso cref="UmbracoToolkit.Models.CmsDocumentBase" />
    public class CmsLink : CmsDocumentBase
    {
        /// <summary>
        /// Gets or sets a value indicating whether this instance is new window.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is new window; otherwise, <c>false</c>.
        /// </value>
        public bool IsNewWindow { get; set; }
    }
}
