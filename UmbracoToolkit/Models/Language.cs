namespace UmbracoToolkit.Models
{
    /// <summary>
    /// Represent content node at root
    /// </summary>
    /// <seealso cref="DocumentBase" />
    public class Language : DocumentBase
    {
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }
    }
}
