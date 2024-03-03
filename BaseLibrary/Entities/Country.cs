

namespace BaseLibrary.Entities
{
    public class Country : BaseEntity
    {
        //one to many relatioship
        public List<City> Cities { get; set; }
    }
}
