using ProjetoAus.Models;

namespace ProjetoAus.BLL.Dto;

public class RegisterProductDto
{
    public required string ProductName { get; set; }
    public required string ProductDescription { get; set; }
    public decimal ProductPrice { get; set; }
    public int ProductQuantity { get; set; }
    
}