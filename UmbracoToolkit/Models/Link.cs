namespace UmbracoToolkit.Models
{
    /// <summary>
    /// Represent cms related link
    /// </summary>
    /// <seealso cref="DocumentBase" />
    public class Link : DocumentBase
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
