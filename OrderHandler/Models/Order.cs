using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderHandler.Models
{
    [Table("Order")]
    public class Order
    {
        [Key]
        public long OrderId { get; set; }
        [Range(0, 1, ErrorMessage = "Please specify a number between {1} and {2}")]
        public double TotalRabatt { get; set; } = 0;
        [ForeignKey("Id")]
        public long Id { get; set; }
    }
}