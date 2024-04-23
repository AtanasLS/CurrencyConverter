using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace api.transferModels.HistoryDto
{
    public class HistoryDto
    {
        [Required, NotNull]
        [MinLength (3), MaxLength(40)]
        public string? SourceCurrency { get; set; }
        [Required, NotNull]
        [MinLength(3), MaxLength(40)]
        public string? TargetCurrency { get; set; }
        [Required, NotNull]
        public decimal ValueCurrency { get; set; }

    }
}