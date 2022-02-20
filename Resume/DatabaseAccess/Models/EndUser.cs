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

        public virtual Candidate Candidate { get; set; }

        public virtual UserType UserType { get; set; }

        private string loginToken;

        public string? LoginToken
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
        public DateTime? LoginTokenExpiry { get; set; }

        [Column(TypeName ="datetime2")]
        public DateTime? LastLogin { get; set; }
    }
}
