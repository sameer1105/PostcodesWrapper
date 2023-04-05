using Microsoft.AspNetCore.Mvc;
using PostcodesWrapper.Models;
using PostcodesWrapper.Services;

namespace PostcodesWrapper.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostcodesController : ControllerBase
    {
        
        private readonly IPostcodeService postcodeService;
        public PostcodesController(IPostcodeService _postcodeService)
        {
            postcodeService = _postcodeService;
        }

        [HttpGet(Name = "GetPostcodesLookup")]
        public async Task<Postcode.Root> Get(string postcode)
        {   
            return await postcodeService.GetPostcode(postcode);
        }


        [HttpGet("{postcode}/autocomplete")]
        public async Task<AutoCompletePostcode> GetPostcodeOptions(string postcode)
        {
            
            if (!String.IsNullOrEmpty(postcode))
            {
                return await postcodeService.GetPostcodeOptions(postcode);
            }
            return null;
        }

    }
}