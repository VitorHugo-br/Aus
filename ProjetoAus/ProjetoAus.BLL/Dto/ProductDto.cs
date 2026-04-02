using ProjetoAus.Models;

namespace ProjetoAus.BLL.Dto;

public class ProductDto
{
    public string? ProductName { get; set; }
    public string? ProductDescription { get; set; }
    public decimal? ProductPrice { get; set; }
    public int? ProductQuantity { get; set; }
    
}