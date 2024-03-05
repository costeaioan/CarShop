using System.ComponentModel.DataAnnotations.Schema;

namespace Carshop.Core.Entities
{
    public class Car : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ProductionYear { get; set; }
        public string Color { get; set; }
        public double HorsePower { get; set; }
        [ForeignKey("ClientId")]
        public Client Client{ get; set; }
        public int ClientId { get; set; }
    }
}
