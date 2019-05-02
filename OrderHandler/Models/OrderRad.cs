
using OrderHandler.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderHandler.Models
{
    [Table("Order rad")]
    public class OrderRad
    {
        [Key]
        public long OrderRadId { get; set; }
        [Required(ErrorMessage = "Artikel krävs för en kund")]
        [StringRange(AllowableValues = new[] { "Penna", "Block", "Papper", "Suddgummi" }, ErrorMessage = "Typ måste vara antigen 'Penna', 'Block', 'Papper', 'Suddgummi' ")]
        public string Artikel { get; set; }
        public int Antal { get; set; } = 0;
        [DataType(DataType.Currency)]
        public double Pris { get; set; } = 0;
        [Range(0,1, ErrorMessage = "Please specify a number between {1} and {2}")]
        public double TotalRabatt { get; set; } = 0;

        [ForeignKey("OrderId")]
        public long OrderId { get; set; }
    }
}
