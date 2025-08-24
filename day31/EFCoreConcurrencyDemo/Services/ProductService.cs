using EFCoreConcurrencyDemo.Models;
using EFCoreConcurrencyDemo.Repositories;

namespace EFCoreConcurrencyDemo.Services
{
  public class ProductService
  {
    private readonly ProductRepository _repository;

    public ProductService(ProductRepository repository)
    {
      _repository = repository;
    }

    public async Task AddProductAsync(string name, decimal price)
    {
      var product = new Product { Name = name, Price = price };

      await _repository.AddProductAsync(product);

      Console.WriteLine($"Mahsulot qo'shildi: {product.Name} - {product.Price}");
    }

    public async Task UpdateProductAsync(int id, decimal newPrice)
    {
      var product = await _repository.GetByIdAsync(id);

      if (product == null)
      {
        Console.WriteLine("Mahsulot topilmadi");
        return;
      }

      product.Price = newPrice;

      await _repository.UpdateProductAsync(product);
    }

    public async Task ShowAllProductsAsync()
    {
      var products = await _repository.GetAllAsync();

      foreach (var p in products)
      {
        Console.WriteLine($"{p.Id} - {p.Name} | Narx: {p.Price}");
      }
    }
  }

}

