	//----------sysUserInfo开始----------
    

using DNet.Core.IServices.BASE;
using DNet.Core.Model.Models;
using System.Threading.Tasks;

namespace DNet.Core.IServices
{	
	/// <summary>
	/// sysUserInfoServices
	/// </summary>	
    public interface ISysUserInfoServices :IBaseServices<sysUserInfo>
	{

		Task<sysUserInfo> SaveUserInfo(string loginName, string loginPwd);
		Task<string> GetUserRoleNameStr(string loginName, string loginPwd);
	}
}

	//----------sysUserInfo结束----------
	