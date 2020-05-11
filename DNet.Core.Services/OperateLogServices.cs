	//----------OperateLog开始----------
    


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
	/// OperateLogServices
	/// </summary>	
	public class OperateLogServices : BaseServices<OperateLog>, IOperateLogServices
    {
	
        IOperateLogRepository dal;
        public OperateLogServices(IOperateLogRepository dal)
        {
            this.dal = dal;
            base.BaseDal = dal;
        }
       
    }
}

	//----------OperateLog结束----------
	