using System.ComponentModel.DataAnnotations;

namespace DapperImplementation.Data.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        ///<summary>
        ///Foreign Key for Address.
        ///</summary>
        public int AddressId { get; set; }
        
        /// <summary>
        /// Navigational Property for Address.
        /// </summary>
        public Address Address { get; set; }
    }
    /*CREATE TABLE `users` (
      `id` int PRIMARY KEY,
      `name` string,
      `surname` string,
      `email` string,
      `address_id` int
        );
     */
}