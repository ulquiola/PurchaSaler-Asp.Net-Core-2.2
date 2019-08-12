using System.Collections.Generic;

namespace PurchaSaler.Models
{
    public class Address
    {
        public Address()
        {
            UserAddresses =new List<UserAddress>();
        }
        public int AddressID { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string AddressDetail { get; set; }
        public int IsDefault { get; set; }

        public List<UserAddress> UserAddresses { get; set; }
    }
}