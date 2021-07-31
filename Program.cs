using APIClientForEconomic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace APIClientForEconomic
{
    class Program
    {
        static HttpClient httpClient = new HttpClient();

        static async Task Main()
        {
            var economicClient = new EconomicClient(httpClient, "demo", "demo");

            var customer = await economicClient.GetEconomicCustomer(1);
            Console.WriteLine(customer);
            Console.WriteLine("Convert JSON string to C# Object for Customer");
            Console.WriteLine("EconomidId = " + customer.CustomerNumber);
            Console.WriteLine("EconomicGroup = " + customer.CustomerGroup.CustomerGroupNumber);
            Console.WriteLine("Name = " + customer.Name);
            Console.WriteLine("CoRegNo = " + customer.CorporateIdentificationNumber);
            Console.WriteLine("address = " + customer.Address);
            Console.WriteLine("City = " + customer.City);
            Console.WriteLine("Zip = " + customer.Zip);
            Console.WriteLine("Country = " + customer.Country);
            Console.WriteLine("PaymentTermsNumber = " + customer.PaymentTerms.PaymentTermsNumber);
            Console.WriteLine("VatZoneNumber = " + customer.VatZone.VatZoneNumber);
            Console.WriteLine("Currency = " + customer.Currency);

            var contacts = await economicClient.GetContacts(1);
            Console.WriteLine("contacts = " + contacts);
            foreach (var contact in contacts)
            {
                Console.WriteLine("Convert JSON string to C# Object for Contacts");
                Console.WriteLine("CustomerContactNumber = " + contact.CustomerContactNumber);
                Console.WriteLine("Name = " + contact.Name);
                Console.WriteLine("Email = " + contact.Email);
            }

            var bookedInvoices = await economicClient.GetBookedInvoices(1);
            Console.WriteLine("all bookedInvoices = " + bookedInvoices.Count());
            Console.WriteLine("bookedInvoices = " + bookedInvoices);
            foreach (var transaction in bookedInvoices)
            {
                Console.WriteLine("Convert JSON string to C# Object for Transtions");
                Console.WriteLine("Date = " + transaction.Date);
                Console.WriteLine("BookedInvoiceNumber = " + transaction.BookedInvoiceNumber);
            }

            List<AccountEntry> accEntry = new List<AccountEntry>();

            if (bookedInvoices.Any())
            {
                var minDate = bookedInvoices.Min(x => x.Date);
                var maxDate = DateTime.Now;

                foreach (var transaction in bookedInvoices)
                {
                    Console.WriteLine("Convert JSON string to C# Object for Transtions");
                    Console.WriteLine("Date = " + transaction.Date);
                    Console.WriteLine("BookedInvoiceNumber = " + transaction.BookedInvoiceNumber);
                }

                for (var year = minDate.Year; year <= maxDate.Year; year++)
                {
                    accEntry.AddRange(await economicClient.GetAccountEntries(year, 1494));
                    Console.WriteLine("year = " + year);
                    Console.WriteLine("minDate = " + minDate);
                    Console.WriteLine("maxDate = " + maxDate);
                }
            }
        }
    }
}