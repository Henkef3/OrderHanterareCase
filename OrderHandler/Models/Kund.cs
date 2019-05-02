using OrderHandler.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OrderHandler.Models
{
    [Table("Kund")]
    public class Kund
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage = "Name krävs för en kund")]
        [StringLength(50, MinimumLength = 1)]
        public string Namn { get; set; }

        [Required(ErrorMessage = "Typ krävs för en kund")]
        [StringRange(AllowableValues = new[] { "LitetFöretag", "StortFöretag", "Privat" }, ErrorMessage = "Typ måste vara antigen 'LitetFöretag', 'StortFöretag' eller 'Privat' ")]
        public string Typ { get; set; }


    }
}