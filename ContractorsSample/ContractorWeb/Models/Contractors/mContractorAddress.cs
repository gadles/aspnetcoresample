using System.ComponentModel.DataAnnotations;

namespace ContractorWeb.Models.Contractors
{
    public class mContractorAddress : mBaseObj
    {
        [Required]
        [Display(Name = "Post Code")]
        public string PostCode { get; set; }
        [Required]
        [Display(Name = "Post Office")]
        public string PostOffice { get; set; }
        [Required]
        [Display(Name = "City")]
        public string City { get; set; }
        [Display(Name = "Commune")]
        public string Commune { get; set; }
        [Display(Name = "District")]
        public string District { get; set; }
        [Display(Name = "Province")]
        public string Province { get; set; }
        [Required]
        [Display(Name = "Country")]
        public string Country { get; set; }
        [Required]
        [Display(Name = "Street")]
        public string Street { get; set; }
        [Display(Name = "House Number")]
        public string HouseNumber { get; set; }
        [Display(Name = "Apartament Number")]
        public string ApartamentNumber { get; set; }
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "WWW")]
        public string WWW { get; set; }
    }
}
