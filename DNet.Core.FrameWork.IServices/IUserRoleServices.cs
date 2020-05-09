using DNet.Core.IServices.BASE;
using DNet.Core.Model.Models;
using System.Threading.Tasks;

namespace DNet.Core.IServices
{	
	/// <summary>
	/// UserRoleServices
	/// </summary>	
    public interface IUserRoleServices :IBaseServices<UserRole>
	{

        Task<UserRole> SaveUserRole(int uid, int rid);
        Task<int> GetRoleIdByUid(int uid);
    }
}

