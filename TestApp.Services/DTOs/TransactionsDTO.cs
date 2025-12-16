using Microsoft.Identity.Client;

namespace TestApp.API.Models
{

    public class TransactionDTO
    {
        public int ID { get; set; }

        public int AccountID {  get; set; }

        public int TxType { get; set; }

        public decimal Amount {  get; set; }

        public DateTime PerformedAt { get; set; }

    }
}
