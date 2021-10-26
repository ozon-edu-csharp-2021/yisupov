using System;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.HttpModels;
using OzonEdu.MerchandiseService.Services.Interfaces;

namespace OzonEdu.MerchandiseService.Services
{
    public class MerchandiseService : IMerchandiseService
    {
        public Task<bool> RequestMerch(MerchItem item)
        {
            throw new NotImplementedException();
        }

        public Task<MerchRetrieveModel> GetMerchRetrieveInfo(long retrieverId)
        {
            throw new NotImplementedException();
        }
    }
}