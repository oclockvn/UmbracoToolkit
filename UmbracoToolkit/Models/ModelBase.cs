using System;

namespace UmbracoToolkit.Models
{
    public class ModelBase
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

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }
        
        /// <summary>
        /// Gets or sets the creator identifier.
        /// </summary>
        /// <value>
        /// The creator identifier.
        /// </value>
        public int CreatorId { get; set; }

        /// <summary>
        /// Gets or sets the name of the creator.
        /// </summary>
        /// <value>
        /// The name of the creator.
        /// </value>
        public string CreatorName { get; set; }

        /// <summary>
        /// Gets or sets the create date.
        /// </summary>
        /// <value>
        /// The created date.
        /// </value>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Gets or sets the update date.
        /// </summary>
        /// <value>
        /// The updated date.
        /// </value>
        public DateTime UpdateDate { get; set; }
    }
}
