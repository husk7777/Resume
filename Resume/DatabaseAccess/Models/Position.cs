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

        public string Description { get; set; }

        public ICollection<Responsibility> Responsibilities { get; set; }

        public virtual EndUser EndUser { get; set; }
        public virtual PositionType PositionType { get; set; }

    }
}
