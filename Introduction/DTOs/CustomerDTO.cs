namespace Introduction.DTOs
{
  

    public class CustomerCreateDTO
    {
      
        public string CustomerName { get; set; }

        public string CustomerAddress { get; set; }

        public string CustomerCity { get; set; }
    }


    public class CustomerReadDTO
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }

        public string CustomerAddress { get; set; }

        public string CustomerCity { get; set; }
    }


    public class CustomerUpdateDTO
    {
        public string CustomerAddress { get; set; }

        public string CustomerCity { get; set; }
    }
}


//you have to think  Customer  ----->   CustomerDTO(will give this to DTO to request guy)
