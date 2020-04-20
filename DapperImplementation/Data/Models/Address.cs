namespace DapperImplementation.Data.Models
{
    public class Address{
        
        public int Id { get; set; }
        
        public string StreetName { get; set; }
        
        public string HouseNumber { get; set; }
    }
    
    /*
    CREATE TABLE `addresses` (
      `id` int PRIMARY KEY,
      `street_name` string,
      `number` string,
      `post_code` string,
      `city` string
    );
     */
}