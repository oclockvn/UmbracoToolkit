using System;
using Umbraco.Core.Models;
using Umbraco.Web;
using Umbraco.Web.Models;

namespace UmbracoToolkit.Extensions
{
    public static class MediaExtension
    {
        /// <summary>
        /// Gets the cropped media.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="cropAlias">The cropAlias.</param>
        /// <param name="noimage">Fallback image in case crop image not found.</param>
        /// <returns></returns>
        public static Models.CmsMedia GetCroppedMedia(this IPublishedContent node, string propertyName, string cropAlias, string noimage)
            => GetCroppedMedia(node, propertyName, cropAlias, noimage, string.Empty, string.Empty);

        /// <summary>
        /// Gets the cropped media.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="cropAlias">The cropAlias.</param>
        /// <param name="noimage">Fallback image in case crop image not found.</param>
        /// <param name="alt">The alt.</param>
        /// <param name="altPropertyName">Name of the alt property.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <returns></returns>
        public static Models.CmsMedia GetCroppedMedia(this IPublishedContent node, string propertyName, string cropAlias, string noimage, string alt, string altPropertyName, int width = 0, int height = 0)
        {
            if (node == null || string.IsNullOrWhiteSpace(propertyName))
                throw new NullReferenceException("Node content not found");
            
            var media = node.GetPropertyValue<ImageCropDataSet>(propertyName);
            if (media == null)
            {
                return new Models.CmsMedia
                {
                    Url = noimage,
                    Alt = alt,
                    Width = width,
                    Height = height
                };
            }

            return new Models.CmsMedia
            {
                Url = media.Src + (string.IsNullOrWhiteSpace(cropAlias) ? string.Empty : media.GetCropUrl(cropAlias)),
                Alt = string.IsNullOrWhiteSpace(alt) ? node.GetPropertyValue<string>(altPropertyName) ?? string.Empty : alt,
                Width = width,
                Height = height,
                Id = node.Id
            };
        }

        /// <summary>
        /// Gets the uploaded file.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <param name="helper">The helper.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns></returns>
        public static Models.CmsMedia GetUploadedFile(this IPublishedContent node, UmbracoHelper helper, string propertyName)
        {
            if (node == null)
                return new Models.CmsMedia();

            var uploadId = node.GetPropertyValue<int>(propertyName);
            var uploadFile = helper.TypedMedia(uploadId);

            return new Models.CmsMedia
            {
                Url = uploadFile?.Url,
                Alt = string.Empty,
                Height = uploadFile?.GetPropertyValue<int>("umbracoWidth") ?? 0,
                Width = uploadFile?.GetPropertyValue<int>("umbracoHeight") ?? 0,
                Id = uploadFile?.Id ?? 0
            };
        }
    }
}
