using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApkaAnalizatorDomain.Enties
{
    public class ApkaKrzysztofa
    {
        [Key]
        public Guid Id { get; set; }
        public string InsertName { get; set; } = null!;
        public DateTime DateTimeInsert { get; set; }
        public int NumberProtocol { get; set; }
        public string? Description { get; set; } 
    }
}
