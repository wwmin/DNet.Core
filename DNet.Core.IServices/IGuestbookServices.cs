using DNet.Core.IServices.BASE;
using DNet.Core.Model.Models;
using System.Threading.Tasks;

namespace DNet.Core.IServices
{
    public partial interface IGuestbookServices : IBaseServices<Guestbook>
    {
        Task<bool> TestTranInRepository();
        Task<bool> TestTranInRepositoryAOP();
    }
}
