using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fedesoft.WomApp.Contracts
{
    public interface IPermissionsManager
    {
        Task<bool> CheckLocationPermissions();
    }
}
