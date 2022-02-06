using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DatabaseAccess.Models
{
    [Table("EndUser")]
    public partial class EndUser
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Citizenship { get; set; }
        public string CountryOfBirth { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Postcode { get; set; }
        public string Phone { get; set; }

        private string loginToken;

        public string LoginToken
        {
            get
            {
                if(loginToken == null)
                {
                    //generate login token
                }
                return loginToken;
            }
            set
            {
                loginToken = value;
            }
        }

        [Column(TypeName = "datetime2")]
        public DateTime LoginTokenExpiry { get; set; }

        [Column(TypeName ="datetime2")]
        public DateTime LastLogin { get; set; }
    }
}
