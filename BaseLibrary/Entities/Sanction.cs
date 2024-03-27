﻿

using System.ComponentModel.DataAnnotations;

namespace BaseLibrary.Entities
{
    public class Sanction : OtherBaseEntity
    {
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Punishment { get; set; } = string.Empty;
        [Required]
        public DateTime PunishmentDate { get; set; }

        // many to one relationship
        public SanctionType? SanctionType { get; set; }
        public int SanctionTypeId { get; set; }
        
    }
}
