using DataModels.Models;
using Syncfusion.Blazor;
using Syncfusion.Blazor.Data;
using System.Threading.Tasks;

namespace BlazorApp.Services
{
    public class CustomerAdaptor : DataAdaptor
    {
        private readonly IFrontEndService frontEndService;

        public CustomerAdaptor(IFrontEndService _frontEndService)
        {
            frontEndService = _frontEndService;
        }
        public async override Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string key = null)
        {
          CustomerResults result = await frontEndService.getCustomers(dataManagerRequest.Skip, dataManagerRequest.Take);
            DataResult dataResult = new DataResult()
            {
                Result = result.Results,
                Count = result.Count
            };
            return dataResult;
        }
    }
}
