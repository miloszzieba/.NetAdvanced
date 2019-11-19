namespace DotNetAdvanced.Linq.Models
{
    public class Car
    {
        public Car()
        {
        }

        public long ClientId { get; set; }
        public int ProductionYear { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}