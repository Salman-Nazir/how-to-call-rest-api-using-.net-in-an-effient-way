using System.Collections.Generic;

namespace APIClientForEconomic.Models
{
    public class ContactResponse
    {
        public List<Contact> Collection { get; set; }
    }

    public class Contact
    {
        public int CustomerContactNumber { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
