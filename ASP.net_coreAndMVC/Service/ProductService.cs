using ASP.net_coreAndMVC.Models;

namespace ASP.net_coreAndMVC.Service
{
    public interface IProductService
    {
        List<Product> getAll();
           
    }
    public class ProductService:IProductService
    {
        public List<Product> getAll() 
        {
            return new List<Product>
            {
                new Product {Id=1,Name="caphe"},
                new Product {Id=2,Name="banh"},
                new Product {Id=3,Name="tra"},
            };
        }
    }
}
