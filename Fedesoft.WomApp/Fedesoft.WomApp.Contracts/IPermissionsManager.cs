//-----------------------------------------------------------------------
// <copyright file="IPermissionsManager.cs" company="Fedesoft">
//     Copyright (c) Fedesoft. All rights reserved.
// </copyright>
// <author>Ricardo Linares Correa</author>
//-----------------------------------------------------------------------

namespace Fedesoft.WomApp.Contracts
{
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="IPermissionsManager" />
    /// </summary>
    public interface IPermissionsManager
    {
        /// <summary>
        /// The CheckLocationPermissions
        /// </summary>
        /// <returns>The <see cref="Task{bool}"/></returns>
        Task<bool> CheckLocationPermissions();
    }
}
