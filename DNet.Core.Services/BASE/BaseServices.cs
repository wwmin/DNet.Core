    
	//----------开始----------
	

using System;
using System.Threading.Tasks;
using DNet.Core.Common;
using DNet.Core.IRepository;
using DNet.Core.IRepository.UnitOfWork;
using DNet.Core.IServices;
using DNet.Core.Model.Models;
using DNet.Core.Services.BASE;
namespace DNet.Core.Services.BASE
{	
	/// <summary>
	/// IBaseRepository
	/// </summary>	
	public class BaseServices<TEntity> : IBaseServices<TEntity> where TEntity : class, new()
    {
		public IBaseRepository<TEntity> baseDal;
       
    }
}

	//----------结束----------
	