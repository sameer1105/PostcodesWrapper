using PostcodesWrapper.Models;
using static PostcodesWrapper.Models.Postcode;

namespace PostcodesWrapper.Services
{
    public interface IPostcodeService
    {
        Task<Root> GetPostcode(string postcode);
        Task<AutoCompletePostcode> GetPostcodeOptions(string postcode);

    }
}
