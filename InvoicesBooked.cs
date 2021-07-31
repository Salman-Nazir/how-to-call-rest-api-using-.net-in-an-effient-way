using System;
using System.Collections.Generic;

namespace APIClientForEconomic.Models
{
    public class InvoiceBooked
    {
        public int BookedInvoiceNumber { get; set; }
        public DateTime Date { get; set; }
    }

    public class InvoicesBooked
    {
        public List<InvoiceBooked> Collection { get; set; }
    }
}
