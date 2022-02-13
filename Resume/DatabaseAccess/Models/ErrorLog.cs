using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseAccess.Models
{
    public partial class ErrorLog
    {
        public ErrorLog()
        {

        }

        public int Id { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime Timestamp { get; set; }
    }
}
