//-----------------------------------------------------------------------
// <copyright file="RegisterPageViewModel.cs" company="Fedesoft">
//     Copyright (c) Fedesoft. All rights reserved.
// </copyright>
// <author>Ricardo Linares Correa</author>
//-----------------------------------------------------------------------

namespace Fedesoft.WomApp.App.ViewModels
{
    using Fedesoft.WomApp.App.ViewModels.Base;

    /// <summary>
    /// Defines the <see cref="RegisterPageViewModel" />
    /// </summary>
    public class RegisterPageViewModel : ViewModelBase
    {
        /// <summary>
        /// Defines the email
        /// </summary>
        private string email;

        /// <summary>
        /// Gets or sets the Email
        /// </summary>
        public string Email { get => this.email; set => this.SetProperty(ref this.email, value); }
    }
}
