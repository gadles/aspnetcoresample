namespace ContractorCore.DBModels
{
    public class oContractorAddress : oBaseObj
    {
        #region Propertis
        public string PostCode { get; set; }
        public string PostOffice { get; set; }
        public string City { get; set; }
        public string Commune { get; set; }
        public string District { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string ApartamentNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string WWW { get; set; }
        #endregion
    }
}
