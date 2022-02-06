using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DatabaseAccess.Models
{
    [Table("ProjectOutcome")]
    public partial class ProjectOutcome
    {
        public int Id { get; set; } 
        public int Description { get; set; }
        public virtual Project Project { get; set; }
    }
}
