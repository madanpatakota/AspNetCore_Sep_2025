namespace Introduction.DTOs
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }

        public string CustomerAddress { get; set; }
    }
}


//you have to think  Customer  ----->   CustomerDTO(will give this to DTO to request guy)
