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
        #endregion

        #endregion
    }
}
