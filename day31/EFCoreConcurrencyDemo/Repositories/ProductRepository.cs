using EFCoreConcurrencyDemo.Data;
using EFCoreConcurrencyDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreConcurrencyDemo.Repositories
{
    public class ProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task AddProductAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProductAsync(Product product)
        {
            try
            {
                _context.Products.Update(product);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                Console.WriteLine("⚠️ Concurrency muammo: boshqa foydalanuvchi yozuvni yangilagan.");

                foreach (var entry in ex.Entries)
                {
                    if (entry.Entity is Product)
                    {
                        var databaseValues = await entry.GetDatabaseValuesAsync();
                        if (databaseValues == null)
                        {
                            Console.WriteLine("❌ Yozuv o‘chirilgan.");
                        }
                        else
                        {
                            var dbProduct = (Product)databaseValues.ToObject();
                            Console.WriteLine($"Bazadagi narx: {dbProduct.Price}, Siz kiritgan narx: {product.Price}");
                            // qaror: qayta urinish yoki foydalanuvchidan tasdiq olish
                        }
                    }
                }
            }
        }
    }
}
