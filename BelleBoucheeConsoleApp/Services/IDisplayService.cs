using BelleBoucheeConsoleApp.Models;

namespace BelleBoucheeConsoleApp.Services
{
    public interface IDisplayService
    {
        void addProductToOrder();
        void addProductToOrderDoesntExist();
        void addProductToOrderQuantity();
        void addProductToOrderQuantityDoesntExist();
        void addProductToOrderSuccess();
        void mainMenu();
        void productsMenu(List<Product> list);
        void productsInventaire(List<Product> list);
        void displayFacturation(List<OrderHasProducts> list, Order order);
        void displaySelectedItems(List<OrderHasProducts> list);
        void displayOrderTotal(Order order);
        void displayHelp();
        void payOrder();
        void payOrderSuccess();
        void payOrderFail();
    }
}