namespace PurchaSaler.Models
{
    public class UserAddress
    {
        public int id {get;set;}

        public int UserId { get; set; }
        public int AddressId { get; set; }

        public User User { get; set; }
        public Address Address { get; set; }
        
    }
}