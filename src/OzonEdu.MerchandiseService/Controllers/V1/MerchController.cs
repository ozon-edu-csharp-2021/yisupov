using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OzonEdu.MerchandiseService.Services.Interfaces;

namespace OzonEdu.MerchandiseService.Controllers.V1
{
    [ApiController]
    [Route("v1/api/merch")]
    public class MerchController : ControllerBase
    {
        private readonly IMerchandiseService _merchandiseService;

        public MerchController(IMerchandiseService merchandiseService)
        {
            _merchandiseService = merchandiseService;
        }
        
        [HttpGet("request")]
        public Task<IActionResult> RequestMerch(CancellationToken token)
        {
            throw new NotImplementedException();
        }
        
        [HttpGet("get-retrieve-info/{id:long}")]
        public Task<IActionResult> GetRetrieveInformation(long id, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}