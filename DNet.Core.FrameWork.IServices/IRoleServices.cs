using DNet.Core.IServices.BASE;
using DNet.Core.Model.Models;
using System.Threading.Tasks;

namespace DNet.Core.IServices
{	
	/// <summary>
	/// RoleServices
	/// </summary>	
    public interface IRoleServices :IBaseServices<Role>
	{
        Task<Role> SaveRole(string roleName);
        Task<string> GetRoleNameByRid(int rid);

    }
}
