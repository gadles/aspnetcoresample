using AutoMapper;
using ContractorCore.DBModels;
using ContractorWeb.Models.Contractors;

namespace ContractorWeb.Helpers
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<oContractor, mContractor>();
            CreateMap<oContractorAddress, mContractorAddress>();
            CreateMap<oContractorBankAccount, mContractorBankAccount>();
            CreateMap<mContractor, oContractor>();
            CreateMap<mContractorAddress, oContractorAddress>();
            CreateMap<mContractorBankAccount, oContractorBankAccount>();
        }
    }
}
