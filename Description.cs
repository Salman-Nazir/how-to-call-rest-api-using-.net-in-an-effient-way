namespace APIClientForEconomic.Models
{
    public class Description
    {
        public int BookedInvoiceNumber { get; set; }
        public Line[] Lines { get; set; }
    }

    public class Line
    {
        public string Description { get; set; }
    }
}
