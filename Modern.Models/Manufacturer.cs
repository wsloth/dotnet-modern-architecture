using System;
using System.Collections.Generic;

namespace Modern.Models
{
    public class Manufacturer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Car> Cars { get; set; }
    }
}
