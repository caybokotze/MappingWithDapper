using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.PortableExecutable;
using DapperImplementation.Data.Models;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace DapperImplementation.Data
{
    public class DataAccess 
    {

        public List<Person> GetPeople()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal()))
            {
                return connection.Query<Person>($"select * from dummyusers").ToList();
            }
        }
        
        public Person MapPersonAndAddress(int personId)
        {
            using(IDbConnection cnn = new System.Data.SqlClient.SqlConnection(Helper.CnnVal()))
            {
                var param = new
                {
                    Id = personId
                };
                //This SqlCommand returns a person with the address of that person.
                var sql = @"select u.*, a.* from `USERS` u 
                left join ADDRESSES a 
                on u.address_id = a.Id WHERE u.Id = @Id";
                
                //This is a dapper command that takes in two generic parameter objects and the last one will be the one that is mapped to, which in this case is the same model
                var people = cnn.Query<Person, Address, Person>(sql, (person, address) =>
                    {
                        person.Address = address;
                        return person;
                    }, 
                    param
                );
                return people.FirstOrDefault();
            }
        }

        public void InsertPerson(Person person)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal()))
            {
                List<Person> list = new List<Person>();
                list.Add(person);
                //
                connection.Execute($"INSERT INTO `users` (name, surname, email, addressId) VALUES (@Name, @Surname, @Email, @AddressId)", list);
            }
        }
        
        public void InsertPeopleRange(IEnumerable<Person> people)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal()))
            {
                connection.Execute($"INSERT INTO `users` (name, surname, email, addressId) VALUES (@Name, @Surname, @Email, @AddressId)", people);
            }
        }

        public void InsertAddress(Address address)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal()))
            {
                List<Address> list = new List<Address>();
                list.Add(address);
                connection.Execute($"INSERT INTO addresses (street_name, house_number) VALUES (@StreetName, @HouseNumber)", list);
            }
        }
    }
}