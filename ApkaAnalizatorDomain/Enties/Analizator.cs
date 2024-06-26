﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApkaAnalizatorDomain.Enties
{
    public class Analizator
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string NameClient { get; set; } = null!;
        public DateTime? Created { get; set; } = DateTime.Now;
    }
}
