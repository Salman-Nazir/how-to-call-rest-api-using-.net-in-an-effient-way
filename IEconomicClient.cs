using APIClientForEconomic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QueueIT.SelfService
{
    public interface IEconomicClient
    {
        Task<EconomicCustomer> GetEconomicCustomer(int economicId);
        Task<List<Contact>> GetContacts(int economicId);
        Task<List<BookedInvoice>> GetTransactions(int economicId);
    }
}