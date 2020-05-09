	//----------Topic开始----------
    


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
	/// TopicServices
	/// </summary>	
	public class TopicServices : BaseServices<Topic>, ITopicServices
    {
	
        ITopicRepository dal;
        public TopicServices(ITopicRepository dal)
        {
            this.dal = dal;
            base.baseDal = dal;
        }
       
    }
}

	//----------Topic结束----------
	