
namespace BaseLibrary.Entities
{
    public class Branch : BaseEntity
    {
        // many to one relationship 
        public Department? Department { get; set; }
        public int DepartmentId { get; set; }

        // one to many relationship
        public List<Employee>? Employees { get; set; }

    }
}
