using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoAus.Models;

public class Product : Entity
{
    [Column("product_name")]
    [StringLength(100)]
    public string ProductName { get; set; }
    
    [Column("product_description")]
    [StringLength(500)]
    public string ProductDescription { get; set; }
    
    [Column("product_price")]
    public decimal ProductPrice { get; set; }
    
    [Column("product_quantity")]
    public int ProductQuantity { get; set; }
}