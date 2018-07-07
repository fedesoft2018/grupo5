//-----------------------------------------------------------------------
// <copyright file="ViewModelBase.cs" company="Fedesoft">
//     Copyright (c) Fedesoft. All rights reserved.
// </copyright>
// <author>Ricardo Linares Correa</author>
//-----------------------------------------------------------------------

namespace Fedesoft.WomApp.App.ViewModels.Base
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Defines the <see cref="ViewModelBase" />
    /// </summary>
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        /// <summary>
        /// Defines the PropertyChanged
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// The OnPropertyChanged
        /// </summary>
        /// <param name="propertyName">The propertyName<see cref="string"/></param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// The SetProperty
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="storage">The storage<see cref="T"/></param>
        /// <param name="value">The value<see cref="T"/></param>
        /// <param name="propertyName">The propertyName<see cref="string"/></param>
        /// <returns>The <see cref="bool"/></returns>
        protected virtual bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
            {
                return false;
            }

            storage = value;
            this.OnPropertyChanged(propertyName);
            return true;
        }
    }
}
