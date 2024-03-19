
using System.Text.Json.Serialization;

namespace BaseLibrary.Entities
{
    public class Department : BaseEntity
    {
        // many to one relationship
        public GeneralDepartment? GeneralDepartment { get; set; }
        public int GeneralDepartmentId { get; set; }


		//one to many relationship
		[JsonIgnore]
		public List<Branch>? Branches { get; set; }
    }
}
