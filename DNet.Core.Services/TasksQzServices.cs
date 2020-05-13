
using DNet.Core.IRepository;
using DNet.Core.IServices;
using DNet.Core.Model.Models;
using DNet.Core.Services.BASE;

namespace DNet.Core.Services
{
    public partial class TasksQzServices : BaseServices<TasksQz>, ITasksQzServices
    {
        ITasksQzRepository _dal;
        public TasksQzServices(ITasksQzRepository dal)
        {
            this._dal = dal;
            base.BaseDal = dal;
        }

    }
}
                    