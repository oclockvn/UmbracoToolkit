namespace UmbracoToolkit.Models
{
    /// <summary>
    /// Represent an image cropper or an upload file
    /// </summary>
    /// <seealso cref="DocumentBase" />
    public class Media : DocumentBase
    {
        /// <summary>
        /// Gets or sets the alt.
        /// </summary>
        /// <value>
        /// The alt.
        /// </value>
        public string Alt { get; set; }

        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        /// <value>
        /// The width.
        /// </value>
        public int Width { get; set; }

        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        /// <value>
        /// The height.
        /// </value>
        public int Height { get; set; }
    }
}
