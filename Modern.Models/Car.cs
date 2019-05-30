using System;

namespace Modern.Models
{
    public class Car
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public EngineInfo Engine { get; set; }

        public Manufacturer Manufacturer { get; set; }
    }
}
