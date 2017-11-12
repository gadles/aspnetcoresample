using System.ComponentModel.DataAnnotations;

namespace ContractorWeb.Models.Contractors
{
    public class mContractor : mBaseObj
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Second Name")]
        public string SecondName { get; set; }
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
        [Display(Name = "NIP")]
        public string NIP { get; set; }
        [Display(Name = "NIP EU")]
        public string NIPEU { get; set; }
        [Display(Name = "Pesel")]
        public string Pesel { get; set; }
        [Display(Name = "Is Natural Person")]
        public bool IsNaturalPerson { get; set; }
        public mContractorAddress Address { get; set; }
        public mContractorBankAccount BankAccount { get; set; }
    }
}
