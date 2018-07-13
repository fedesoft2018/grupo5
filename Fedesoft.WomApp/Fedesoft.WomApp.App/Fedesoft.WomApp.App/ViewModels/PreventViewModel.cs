//-----------------------------------------------------------------------
// <copyright file="PreventViewModel.cs" company="Fedesoft">
//     Copyright (c) Fedesoft. All rights reserved.
// </copyright>
// <author>Ricardo Linares Correa</author>
//-----------------------------------------------------------------------

namespace Fedesoft.WomApp.App.ViewModels
{
    using Fedesoft.WomApp.Domain;
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="PreventViewModel" />
    /// </summary>
    public class PreventViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PreventViewModel"/> class.
        /// </summary>
        public PreventViewModel()
        {
            this.NewsItems = new List<NewsItem>
            {
                new NewsItem
                {
                    ImageUrl = "http://www.sdmujer.gov.co/images/noticias/posesion_consultivas_2018.jpg",
                    Title = "Posesión Consejeras Consultivas periodo 2018-2021",
                    Lead = "En el marco de la primera sesión ordinaria del Consejo Consultivo Ampliado de Mujeres, se llevó a cabo el reconocimiento público y posesión de las 41 consejeras consultivas que representarán los intereses de las mujeres ante la administración Distrital en el periodo 2018-2021."
                }
            };
        }

        /// <summary>
        /// Gets or sets the NewsItems
        /// </summary>
        public List<NewsItem> NewsItems { get; set; }
    }
}
