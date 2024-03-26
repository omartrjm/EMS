﻿

using System.Text.Json.Serialization;

namespace BaseLibrary.Entities
{
    public class VacationType : BaseEntity
    {
		// many to one
		[JsonIgnore]
		public List<Vacation> Vacations { get; set; }
    }
}
