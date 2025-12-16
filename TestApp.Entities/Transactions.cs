using Microsoft.Identity.Client;

namespace TestApp.API.Models
{


    public enum TxType
    {  
        Credit = 1 , 
        Debit = 2
    }

    public class BankTransaction
    {
        public int ID { get; set; }

        public int AccountID {  get; set; }

        public int TxType { get; set; }

        public decimal Amount {  get; set; }

        public DateTime PerformedAt { get; set; }

    }
}
