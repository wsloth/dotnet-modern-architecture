using System;

namespace Modern.Models
{
    public class EngineInfo
    {
        public Guid Id { get; set; }
        public float ZeroTo100Time { get; set; }
        public int Horsepower { get; set; }
        public int Cylinders { get; set; }
    }
}
