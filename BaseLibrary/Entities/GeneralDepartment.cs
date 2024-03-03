

namespace BaseLibrary.Entities
{
    public class GeneralDepartment : BaseEntity
    {
        // one to many relationship
        public List<Department>? Departments { get; set; }
    }
}
