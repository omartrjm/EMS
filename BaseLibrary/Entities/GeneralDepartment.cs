﻿

using System.Text.Json.Serialization;

namespace BaseLibrary.Entities
{
    public class GeneralDepartment : BaseEntity
    {
		// one to many relationship
		[JsonIgnore]
		public List<Department>? Departments { get; set; }
    }
}
