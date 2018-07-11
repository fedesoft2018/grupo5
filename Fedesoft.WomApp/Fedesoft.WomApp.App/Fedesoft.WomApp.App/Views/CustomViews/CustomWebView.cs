//-----------------------------------------------------------------------
// <copyright file="CustomWebView.cs" company="Fedesoft">
//     Copyright (c) Fedesoft. All rights reserved.
// </copyright>
// <author>Ricardo Linares Correa</author>
//-----------------------------------------------------------------------

namespace Fedesoft.WomApp.App.Views.CustomViews
{
    using System.Windows.Input;

    using Xamarin.Forms;

    /// <summary>
    /// Defines the <see cref="CustomWebView" />
    /// </summary>
    public class CustomWebView : WebView
    {
        /// <summary>
        /// Defines the NavigatedCommandProperty
        /// </summary>
        public static readonly BindableProperty NavigatedCommandProperty =
            BindableProperty.Create(nameof(NavigatedCommand), typeof(ICommand), typeof(CustomWebView), null);

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomWebView"/> class.
        /// </summary>
        public CustomWebView()
        {
            this.Navigated += (s, e) => this.ExecuteNavigatedCommand(e);
        }

        /// <summary>
        /// Gets or sets the NavigatedCommand
        /// </summary>
        public ICommand NavigatedCommand
        {
            get { return (ICommand)this.GetValue(NavigatedCommandProperty); }
            set { this.SetValue(NavigatedCommandProperty, value); }
        }

        /// <summary>
        /// The ExecuteNavigatedCommand
        /// </summary>
        /// <param name="e">The e<see cref="WebNavigatedEventArgs"/></param>
        private void ExecuteNavigatedCommand(WebNavigatedEventArgs e)
        {
            if (this.NavigatedCommand?.CanExecute(e) ?? false)
            {
                this.NavigatedCommand.Execute(e);
            }
        }
    }
}
