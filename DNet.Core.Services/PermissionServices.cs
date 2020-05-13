using DNet.Core.Services.BASE;
using DNet.Core.Model.Models;
using DNet.Core.IRepository;
using DNet.Core.IServices;

namespace DNet.Core.Services
{	
	/// <summary>
	/// PermissionServices
	/// </summary>	
	public class PermissionServices : BaseServices<Permission>, IPermissionServices
    {
	
        IPermissionRepository _dal;
        public PermissionServices(IPermissionRepository dal)
        {
            this._dal = dal;
            base.BaseDal = dal;
        }
       
    }
}
