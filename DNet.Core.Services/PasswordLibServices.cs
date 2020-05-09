	//----------PasswordLib开始----------
    


using System;
using System.Threading.Tasks;
using DNet.Core.Common;
using DNet.Core.IRepository;
using DNet.Core.IRepository.UnitOfWork;
using DNet.Core.IServices;
using DNet.Core.Model.Models;
using DNet.Core.Services.BASE;
namespace DNet.Core.Services
{	
	/// <summary>
	/// PasswordLibServices
	/// </summary>	
	public class PasswordLibServices : BaseServices<PasswordLib>, IPasswordLibServices
    {
	
        IPasswordLibRepository dal;
        public PasswordLibServices(IPasswordLibRepository dal)
        {
            this.dal = dal;
            base.baseDal = dal;
        }
       
    }
}

	//----------PasswordLib结束----------
	