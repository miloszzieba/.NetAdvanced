namespace DotNetAdvanced.Reflection.Models
{
    [MyAttribute(Name = "xD")]
    public class Product
    {
        public long Id { get; set; }
        private readonly string name = "zwykła nazwa";
    }
}
