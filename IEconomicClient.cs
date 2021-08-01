using APIClientForEconomic.Models;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace APIClientForEconomic
{
    public interface IEconomicClient
    {
        Task<EconomicCustomer> GetEconomicCustomer(int economicId);
        Task<List<Contact>> GetContacts(int economicId);
        Task<List<InvoiceBooked>> GetBookedInvoices(int economicId);
        Task<List<AccountEntry>> GetAccountEntries(int year, int customerNumber);
        Task<Stream> GetPDFforInvoice(int bookedInvoiceNumber);
        Task<CustomerGroup> GetCustomerGroupName(int customerGroupNumber);
    }
}
