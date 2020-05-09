	//----------TasksQz开始----------
    

using DNet.Core.Model.Models;
using DNet.Core.IRepository;
using DNet.Core.IRepository.UnitOfWork;
namespace DNet.Core.Repository
{	
	/// <summary>
	/// TasksQzRepository
	/// </summary>	
	public class TasksQzRepository : BaseRepository<TasksQz>, ITasksQzRepository
    {
		public TasksQzRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
       
    }
}

	//----------TasksQz结束----------
	