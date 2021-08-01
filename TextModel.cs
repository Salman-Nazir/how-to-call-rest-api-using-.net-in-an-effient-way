using System;
using System.Collections.Generic;

namespace APIClientForEconomic.Models
{
    public class AccountEntry
    {
        public int InvoiceNumber { get; set; }
        public int VoucherNumber { get; set; }
        public string EntryType { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }
        public decimal Amount { get; set; }
        public decimal Balance { get; set; }
        public string Currency { get; set; }
    }

    public class BookedInvoice
    {
        public int BookedInvoiceNumber { get; set; }
    }
    public class AccountEntries
    {
        public List<AccountEntry> Collection { get; set; }
    }

    public class Customer
    {
        public int CustomerNumber { get; set; }
    }
}
