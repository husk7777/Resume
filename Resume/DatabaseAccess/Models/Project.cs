using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DatabaseAccess.Models
{
    [Table("Project")]
    public partial class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [ForeignKey("CandidateId")]
        public int CandidateId { get; set; }
        public virtual Candidate Candidate { get; set; }
        public virtual ICollection<ProjectOutcome> ProjectOutcomes { get; set; }    
    }
}
