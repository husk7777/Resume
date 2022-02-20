using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DatabaseAccess.Models
{
    [Table("Position")]
    public partial class Position
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Organisation { get; set; }


        [Column(TypeName = "datetime2")]
        public DateTime StartDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? EndDate { get; set; }

        public ICollection<Responsibility> Responsibilities { get; set; }

        [ForeignKey("CandidateId")]
        public int CandidateId { get; set; }
        public virtual Candidate Candidate { get; set; }

        [ForeignKey("PositionTypeId")]
        public int PositionTypeId { get; set; }
        public virtual PositionType PositionType { get; set; }

    }
}
