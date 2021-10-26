using System;
using System.Threading.Tasks;
using Grpc.Core;
using OzonEdu.MerchandiseService.Grpc;
using OzonEdu.MerchandiseService.Services.Interfaces;

namespace OzonEdu.MerchandiseService.GrpcServices
{
    public class MerchApiGrpcService : MerchApiGrpc.MerchApiGrpcBase
    {
        private readonly IMerchandiseService _merchandiseService;
        
        public MerchApiGrpcService(IMerchandiseService merchandiseService)
        {
            _merchandiseService = merchandiseService;
        }

        public override Task<RequestMerchResponse> RequestMerch(RequestMerchRequest request, ServerCallContext context)
        {
            throw new NotImplementedException();
        }

        public override Task<GetRetrieveInformationResponse> GetRetrieveInformation(GetRetrieveInformationRequest request, ServerCallContext context)
        {
            throw new NotImplementedException();
        }
    }
}