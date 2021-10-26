using System.Threading.Tasks;
using OzonEdu.MerchandiseService.HttpModels;

namespace OzonEdu.MerchandiseService.Services.Interfaces
{
    public interface IMerchandiseService
    {
        Task<bool> RequestMerch(MerchItem item);
        Task<MerchRetrieveModel> GetMerchRetrieveInfo(long retrieverId);
    }
}