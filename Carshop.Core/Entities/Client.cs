namespace Carshop.Core.Entities
{
    public class Client : BaseEntity
    {
        public string Name { get; set; }
        public string SocialNumber { get; set; }
        public ICollection<Car> Cars { get; set; } = new List<Car>();
    }
}
