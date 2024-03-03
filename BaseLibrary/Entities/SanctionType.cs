

namespace BaseLibrary.Entities
{
    public class SanctionType
    {
        // many to one relationship
        public List<Sanction>? Sanctions { get; set; }
    }
}
