using ContractorCore.DBModels;
using System.Collections.Generic;
using System.Net.Http;

namespace ContractorCore.Services
{
    public interface IApiContractorConsumer
    {
        IEnumerable<oContractor> GetContractorList();
        oContractor GetContractor(int id);
        HttpResponseMessage CreateContractor(oContractor concontractor);
        HttpResponseMessage UpdateContractor(oContractor contractor);
        HttpResponseMessage DeleteContractor(oContractor contractor);
    }
}
