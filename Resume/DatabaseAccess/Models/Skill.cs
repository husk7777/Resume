using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Models
{
    public partial class Skill
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int CandidateId { get; set; }
    }
}
