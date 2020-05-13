
using DNet.Core.IRepository;
using DNet.Core.IRepository.UnitOfWork;
using DNet.Core.Model.Models;
using DNet.Core.Repository.Base;

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
                    