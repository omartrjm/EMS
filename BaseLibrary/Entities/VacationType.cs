

namespace BaseLibrary.Entities
{
    public class VacationType
    {
        // many to one
        public List<Vacation> Vacations { get; set; }
    }
}
