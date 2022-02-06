using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseAccess.Models
{
    [Table("PositionType")]
    public partial class PositionType
    {
        public int Id { get; set; }
        public string Type { get; set; }

    }
}
