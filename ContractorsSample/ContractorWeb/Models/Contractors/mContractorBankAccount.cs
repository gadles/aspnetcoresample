using System.ComponentModel.DataAnnotations;

namespace ContractorWeb.Models.Contractors
{
    public class mContractorBankAccount : mBaseObj
    {
        [Required]
        [Display(Name = "Bank Name")]
        public string BankName { get; set; }
        [Required]
        [Display(Name = "Bank Number")]
        public string BankNumber { get; set; }
        [Display(Name = "Bank Swift")]
        public string BankSwift { get; set; }
    }
}
