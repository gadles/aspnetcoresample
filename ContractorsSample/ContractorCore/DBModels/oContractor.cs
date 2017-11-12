using AutoMapper;
using ContractorCore.Helpers;
using ContractorCore.Services;
using System;

namespace ContractorCore.DBModels
{
    public class oContractor : oBaseObj
    {
        #region Propertis
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string CompanyName { get; set; }
        public string NIP { get; set; }
        public string NIPEU { get; set; }
        public string Pesel { get; set; }
        public bool IsNaturalPerson { get; set; }
        public oContractorAddress Address { get; set; }
        public oContractorBankAccount BankAccount { get; set; }

        #region ReadOnly
        public string BankName
        {
            get
            {
                return BankAccount != null ? BankAccount.BankName : string.Empty;
            }
        }

        public string BankNumber
        {
            get
            {
                return BankAccount != null ? BankAccount.BankNumber : string.Empty;
            }
        }

        public string Phone
        {
            get
            {
                return Address != null ? Address.PhoneNumber : string.Empty;
            }
        }

        public string FullAddress
        {
            get
            {
                return Address != null ? $"{Address.City} {Environment.NewLine} " +
                    $"{Address.PostCode} {Address.PostOffice} {Environment.NewLine} " +
                    $"{Address.Street} {Address.HouseNumber} {Address.ApartamentNumber}" : string.Empty;
            }
        }

        public static bool SaveContractorFromViewModel<T>(IApiContractorConsumer contractorConsumer, IMapper mapper, T contractor)
        {
            try
            {
                if (contractorConsumer == null || mapper == null || contractor == null)
                    return false;
                using (oContractor mapped = mapper.Map<T, oContractor>(contractor))
                {
                    var res = contractorConsumer.CreateContractor(mapped);
                    if (res.IsSuccessStatusCode)
                        return true;
                    return false;
                }
            }
            catch (Exception ex)
            {
                LogInfo.LogMessage(enumLogInfoType.Error, ex);
                return false;
            }
        }

        public static T GetUserById<T>(IApiContractorConsumer contractorConsumer, IMapper mapper, int id)
        {
            try
            {
                if (contractorConsumer == null || mapper == null)
                    return default(T);
                var usr = contractorConsumer.GetContractor(id);
                if (usr == null)
                    return default(T);
                var mapped = mapper.Map<oContractor, T>(usr);
                return mapped;
            }
            catch (Exception ex)
            {
                LogInfo.LogMessage(enumLogInfoType.Error, ex);
                return default(T);
            }
        }

        public static bool DeleteUserFromId(IApiContractorConsumer contractorConsumer, int id)
        {
            try
            {
                if (contractorConsumer == null)
                    return false;
                var usr = contractorConsumer.GetContractor(id);
                if (usr == null)
                    return false;
                var result = contractorConsumer.DeleteContractor(usr);
                if (result.IsSuccessStatusCode)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                LogInfo.LogMessage(enumLogInfoType.Error, ex);
                return false;
            }
        }
        #endregion

        #endregion
    }
}
