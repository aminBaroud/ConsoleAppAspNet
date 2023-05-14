using BelleBoucheeConsoleApp.Models;

namespace BelleBoucheeConsoleApp.Services
{
    public interface IProductService
    {
        List<Product> getProducts();
        List<Product> initProducts();
        bool productExist(string id);
        Product getProductById(string id);
        bool productQuantityExist(string id, string quantity);
        List<Product> updateProductList(Product prod, string quantity , string action);
    }
}