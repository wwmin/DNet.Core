	//----------OperateLog开始----------
    

using DNet.Core.Model.Models;
using DNet.Core.IRepository;
using DNet.Core.IRepository.UnitOfWork;
namespace DNet.Core.Repository
{	
	/// <summary>
	/// OperateLogRepository
	/// </summary>	
	public class OperateLogRepository : BaseRepository<OperateLog>, IOperateLogRepository
    {
		public OperateLogRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
       
    }
}

	//----------OperateLog结束----------
	