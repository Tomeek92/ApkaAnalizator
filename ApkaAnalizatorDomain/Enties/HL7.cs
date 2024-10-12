﻿using System.ComponentModel.DataAnnotations;

namespace ApkaAnalizatorDomain.Enties
{
    public class HL7
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string NameClient { get; set; } = null!;
        public DateTime? Created { get; set; } = DateTime.Now;
    }
}
