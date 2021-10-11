using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatagridTest.Models
{
    public class Users
    {
        public Users(int id, string firstname, string lastname, string fullName)
        {
            Id = id;
            this.firstname = firstname;
            this.lastname = lastname;
            this.fullName = fullName;
        }

        public int Id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string fullName { get; set; }
        //public string image { get; set; }
    }
}
