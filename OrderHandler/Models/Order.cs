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
        [DataType(DataType.Currency)]
        public int TotalRabatt { get; set; } = 0;
        [ForeignKey("Id")]
        public long Id { get; set; }
    }
}