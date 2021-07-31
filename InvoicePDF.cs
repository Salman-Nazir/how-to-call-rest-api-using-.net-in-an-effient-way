namespace APIClientForEconomic.Models
{
    public class InvoicePDF
    {
        public PDF Pdf { get; set; }
    }

    public class PDF
    {
        public string Download { get; set; }
    }
}
