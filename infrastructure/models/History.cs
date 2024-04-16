using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace infrastructure.models
{
    public class History
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string? SourceCurrency { get; set; }
        public string? TargetCurrency { get; set; }
        public int ValueCurrency { get; set; }
        public decimal Result { get; set; }
    }
}