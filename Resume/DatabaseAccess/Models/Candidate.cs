using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DatabaseAccess.Models
{
    public partial class Candidate
    {
        [Key]
        public int EndUserId { get;set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DateOfBirth { get; set; }
        public string Citizenship { get; set; }
        public string CountryOfBirth { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Postcode { get; set; }
        public string Phone { get; set; }
        public ICollection<Skill> Skills { get; set; }
        public ICollection<Position> Positions { get; set; }
    }
}
