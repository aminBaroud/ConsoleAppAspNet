using BelleBoucheeConsoleApp.Models;

namespace BelleBoucheeConsoleApp.Services
{
    public interface IOrderHasProductsService
    {
        void updateProductOrder(Order order, Product product, string quantity, string action);
        List<OrderHasProducts> getOrderHasProductsList();
        void initList();
        void removeProductOrder(Product product);
    }
}