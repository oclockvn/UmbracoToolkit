namespace UmbracoToolkit.Models
{
    public class CmsDocumentBase
    {
        /// <summary>
        /// Gets or sets the identifier of document.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of document.
        /// </summary>
        /// <value>
        /// The document name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>
        /// The URL.
        /// </value>
        public string Url { get; set; }
    }
}
