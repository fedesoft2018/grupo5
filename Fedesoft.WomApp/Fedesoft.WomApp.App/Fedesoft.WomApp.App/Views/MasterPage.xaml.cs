//-----------------------------------------------------------------------
// <copyright file="MasterPage.xaml.cs" company="Fedesoft">
//     Copyright (c) Fedesoft. All rights reserved.
// </copyright>
// <author>Ricardo Linares Correa</author>
//-----------------------------------------------------------------------

namespace Fedesoft.WomApp.App.Views
{
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    /// <summary>
    /// Defines the <see cref="MasterPage" />
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterPage : MasterDetailPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MasterPage"/> class.
        /// </summary>
        public MasterPage()
        {
            this.InitializeComponent();
        }
    }
}
