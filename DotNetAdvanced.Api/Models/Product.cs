using System.ComponentModel.DataAnnotations;

namespace DotNetAdvanced.Api.Models
{
    public class Product
    {
        [Key]
        public long Id { get; set; }

        public string Name { get; set; }
    }
}