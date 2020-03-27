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
        private IConfiguration _configuration;
        public DataAccess(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public List<Person> GetPeople()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal(_configuration, "DefaultConnection")))
            {
                return connection.Query<Person>($"select * from dummyusers").ToList();
            }
        }

        public void InsertPerson(Person person)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal(_configuration, "DefaultConnection")))
            {
                List<Person> list = new List<Person>();
                list.Add(person);
                //
                connection.Execute($"insert into dummyusers (Name, Surname, Password, Phone) VALUES (@Name, @Surname, @Password, @Phone)", list);
            }
        }
        
        public void InsertPeopleRange(IEnumerable<Person> people)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal(_configuration, "DefaultConnection")))
            {
                connection.Execute($"insert into dummyusers (Name, Surname, Password, Phone) VALUES (@Name, @Surname, @Password, @Phone)", people);
            }
        }
    }
}