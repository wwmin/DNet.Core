using DNet.Core.Services.BASE;
using DNet.Core.Model.Models;
using DNet.Core.IRepository;
using DNet.Core.IServices;

namespace DNet.Core.Services
{	
	/// <summary>
	/// ModuleServices
	/// </summary>	
	public class ModuleServices : BaseServices<Module>, IModuleServices
    {
	
        IModuleRepository _dal;
        public ModuleServices(IModuleRepository dal)
        {
            this._dal = dal;
            base.BaseDal = dal;
        }
       
    }
}
