using Microsoft.EntityFrameworkCore;

namespace WiredBrainCoffeeAdmin.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly WiredContext wiredContext;
        public ProductRepository(WiredContext context)
        {
            wiredContext = context;
        }

        public void Add(Product product)
        {
            this.wiredContext.Products.Add(product);
            this.wiredContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var deleteItem = this.wiredContext.Products.First(x => x.Id == id);
            wiredContext.Products.Remove(deleteItem);
            wiredContext.SaveChanges();
        }

        public List<Product> GetAll()
        {
            return wiredContext.Products.ToList();
        }

        public Product GetById(int id)
        {
            return this.wiredContext.Products.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Product product)
        {
            wiredContext.Entry(product).State = EntityState.Modified;
            wiredContext.SaveChanges();
        }
    }
}
