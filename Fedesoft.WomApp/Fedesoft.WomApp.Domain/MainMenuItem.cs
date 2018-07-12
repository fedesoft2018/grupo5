//-----------------------------------------------------------------------
// <copyright file="MainMenuItem.cs" company="Fedesoft">
//     Copyright (c) Fedesoft. All rights reserved.
// </copyright>
// <author>Ricardo Linares Correa</author>
//-----------------------------------------------------------------------

namespace Fedesoft.WomApp.Domain
{
    using System;

    /// <summary>
    /// Defines the <see cref="MainMenuItem" />
    /// </summary>
    public class MainMenuItem
    {
        /// <summary>
        /// Gets or sets the Icon
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// Gets or sets the IconHeight
        /// </summary>
        public int IconHeight { get; set; }

        /// <summary>
        /// Gets or sets the IconWith
        /// </summary>
        public int IconWith { get; set; }

        /// <summary>
        /// Gets or sets the LineNumber
        /// </summary>
        public string LineNumber { get; set; }

        /// <summary>
        /// Gets or sets the MenuItemType
        /// </summary>
        public MenuItemType MenuItemType { get; set; }

        /// <summary>
        /// Gets or sets the TargetType
        /// </summary>
        public Type TargetType { get; set; }

        /// <summary>
        /// Gets or sets the Title
        /// </summary>
        public string Title { get; set; }
    }
}
