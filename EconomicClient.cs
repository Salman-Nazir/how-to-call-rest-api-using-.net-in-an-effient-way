using APIClientForEconomic.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace APIClientForEconomic
{
    public class EconomicClient
    {
        private const string URL = "https://restapi.e-conomic.com/"; // URL for your or external web api 
        private readonly string _secretToken; // Secret or api key for your or external web api
        private readonly string _grantToken; // Access or api key for your or external web api

        private readonly HttpClient _httpClient;

        public EconomicClient(HttpClient httpClient, string secretToken, string grantToken)
        {
            _secretToken = secretToken;
            _grantToken = grantToken;

            _httpClient = httpClient;

            _httpClient.BaseAddress = new Uri(URL);
            _httpClient.DefaultRequestHeaders.Add("X-AppSecretToken", _secretToken); // Request headers for your or external web api
            _httpClient.DefaultRequestHeaders.Add("X-AgreementGrantToken", _grantToken); // Request headers for your or external web api
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        // Call to get a customer from economic api via economic id 
        public async Task<EconomicCustomer> GetEconomicCustomer(int economicId)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"customers/{economicId}?demo=true");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            EconomicCustomer economicClient = JsonConvert.DeserializeObject<EconomicCustomer>(responseBody);
            return economicClient;
        }

        // Call to get contacts of a customer from economic api via economic id 
        public async Task<List<Contact>> GetContacts(int economicId)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"customers/{economicId}/contacts?demo=true");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            var contactResponse = JsonConvert.DeserializeObject<ContactResponse>(responseBody);
            return contactResponse.Collection;
        }

        // Call to get invoices of a customer from economic api via economic id 
        public async Task<List<InvoiceBooked>> GetBookedInvoices(int economicId)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"customers/{economicId}/invoices/booked?skippages=0&pagesize=1000&demo=true");

            if (response.StatusCode == HttpStatusCode.InternalServerError)
            {
                throw new Exception("An unexpected error has occured. Please try again. If the problem continues do contact our support team.");
            }

            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            var bookedInvoicesResponse = JsonConvert.DeserializeObject<InvoicesBooked>(responseBody);
            return bookedInvoicesResponse.Collection;
        }

        // Call to get enteries for invoices with respect to year for a customer from economic api via year and customer number 
        public async Task<List<AccountEntry>> GetAccountEntries(int year, int customerNumber)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"accounting-years/{year}/entries??demo=true&skippages=0&pagesize=1000&filter=customer.customerNumber$eq:{customerNumber}$and:entryType$ne:systemEntry&sort=date");
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return new List<AccountEntry>();
            }

            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            var accountEntryResponse = JsonConvert.DeserializeObject<AccountEntries>(responseBody);
            return accountEntryResponse.Collection;
        }

        // Call to get pdf of a invoice for a customer from economic api via booked invoiced number
        public async Task<Stream> GetPDFforInvoice(int bookedInvoiceNumber)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"invoices/booked/{bookedInvoiceNumber}?demo=true");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            var invoicePdf = JsonConvert.DeserializeObject<InvoicePDF>(responseBody);

            var pdfResponse = await _httpClient.GetAsync(invoicePdf.Pdf.Download);
            return await pdfResponse.Content.ReadAsStreamAsync();
        }

        // Call to get customer group of a customer from economic api via customer group number
        public async Task<CustomerGroup> GetCustomerGroupName(int customerGroupNumber)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"customer-groups/{customerGroupNumber}?demo=true");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            CustomerGroup customerGroup = JsonConvert.DeserializeObject<CustomerGroup>(responseBody);
            return customerGroup;
        }
    }
}
