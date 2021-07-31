namespace APIClientForEconomic.Models
{
    //data structure for mapping
    public class EconomicCustomer
    {
        public int CustomerNumber { get; set; }
        public CustomerGroup CustomerGroup { get; set; }
        public string CorporateIdentificationNumber { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public PaymentTerms PaymentTerms { get; set; }
        public VatZone VatZone { get; set; }
        public string Currency { get; set; }
    }
}
