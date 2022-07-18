using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WiredBrainCoffeeAdmin.Data;

namespace WiredBrainCoffeeAdmin.Pages.Products
{
    public class ViewAllProductsModel : PageModel
    {
        private IProductRepository productRepo;
        public List<Product> Products { get; set; } 
        public ViewAllProductsModel(IProductRepository productRepository)
        {
            this.productRepo = productRepository;
        }
        public void OnGet()
        {
            Products = productRepo.GetAll(); 
        }
    }
}
