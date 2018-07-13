//-----------------------------------------------------------------------
// <copyright file="NewsItem.cs" company="Fedesoft">
//     Copyright (c) Fedesoft. All rights reserved.
// </copyright>
// <author>Ricardo Linares Correa</author>
//-----------------------------------------------------------------------

namespace Fedesoft.WomApp.Domain
{
    /// <summary>
    /// Defines the <see cref="NewsItem" />
    /// </summary>
    public class NewsItem
    {
        /// <summary>
        /// Gets or sets the ImageUrl
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// Gets or sets the Lead
        /// </summary>
        public string Lead { get; set; }

        /// <summary>
        /// Gets or sets the Title
        /// </summary>
        public string Title { get; set; }
    }
}
