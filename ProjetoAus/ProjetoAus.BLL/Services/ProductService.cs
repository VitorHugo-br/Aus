using ProjetoAus.BLL.Dto;
using ProjetoAus.Data.interfaces;
using ProjetoAus.Models;

namespace ProjetoAus.BLL.Services;

public class ProductService(IProductRepository productRepository)
{
    public async Task<Product?> CreateAsync(RegisterProductDto productDto)
    {
        if (string.IsNullOrWhiteSpace(productDto.ProductName)) return null;
        if (string.IsNullOrWhiteSpace(productDto.ProductDescription)) return null;

        var newProduct = new Product
        {
            Id = Guid.NewGuid(),
            ProductName = productDto.ProductName.Trim(),
            ProductDescription = productDto.ProductDescription,
            ProductPrice = productDto.ProductPrice,
            ProductQuantity = productDto.ProductQuantity
        };
        await productRepository.CreateAsync(newProduct);
        return newProduct;
    }

    public async Task<IEnumerable<Product>> GetAllAsync(int page, int pageSize)
    {
        return await productRepository.GetAllAsync(page: page, pageSize: pageSize);
    }

    public async Task<Product?> GetByIdAsync(Guid id)
    {
        return await productRepository.GetByIdAsync(id);
    }

    public async Task<Product?> UpdateAsync(Guid id, ProductDto dto)
    {
        var existingProduct = await productRepository.GetByIdAsync(id);
        if (existingProduct == null) return null;

        if (!string.IsNullOrWhiteSpace(dto.ProductName))
            existingProduct.ProductName = dto.ProductName;

        if (!string.IsNullOrWhiteSpace(dto.ProductDescription))
            existingProduct.ProductDescription = dto.ProductDescription;

        if (dto.ProductPrice is > 0)
            existingProduct.ProductPrice = dto.ProductPrice.Value;

        if (dto.ProductQuantity is >= 0)
            existingProduct.ProductQuantity = dto.ProductQuantity.Value;

        await productRepository.UpdateAsync(existingProduct);
        return existingProduct;
    }

    public async Task<Product?> DeleteAsync(Guid id)
    {
        var existingProduct = await productRepository.GetByIdAsync(id); 
        if(existingProduct == null) return null;
        await productRepository.DeleteAsync(existingProduct);
        return existingProduct;
    }
    
}