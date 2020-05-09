	//----------TasksQz开始----------
    


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
	/// TasksQzServices
	/// </summary>	
	public class TasksQzServices : BaseServices<TasksQz>, ITasksQzServices
    {
	
        ITasksQzRepository dal;
        public TasksQzServices(ITasksQzRepository dal)
        {
            this.dal = dal;
            base.baseDal = dal;
        }
       
    }
}

	//----------TasksQz结束----------
	