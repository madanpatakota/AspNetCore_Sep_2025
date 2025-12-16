namespace TestApp.API.Models
{
    public class AccountDTO
    {
        public int AccountId {  get; set; }
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public int CustomerId { get; set; }
        public bool IsActive { get; set; }
    }
}
