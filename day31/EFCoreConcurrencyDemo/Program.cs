using EFCoreConcurrencyDemo.Data;
using EFCoreConcurrencyDemo.Repositories;
using EFCoreConcurrencyDemo.Services;


class Program
{
  static async Task Main(string[] args)
  {
    using var context = new AppDbContext();
    context.Database.EnsureCreated();

    var repository = new ProductRepository(context);

    var service = new ProductService(repository);

    await service.AddProductAsync("Telefon", 1000);

    await service.ShowAllProductsAsync();

    await service.UpdateProductAsync(1, 1200);

    await service.ShowAllProductsAsync();
  }
}
