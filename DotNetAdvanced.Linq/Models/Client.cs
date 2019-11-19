using System.Collections.Generic;

namespace DotNetAdvanced.Linq.Models
{
    public class Client
    {
        public long Id { get; set; }
        public bool IsBussiness { get; set; }
        public List<Car> Cars { get; set; }
    }
}
