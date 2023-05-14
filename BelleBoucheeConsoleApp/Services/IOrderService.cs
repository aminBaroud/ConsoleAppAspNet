using BelleBoucheeConsoleApp.Models;

namespace BelleBoucheeConsoleApp.Services
{
    public interface IOrderService
    {
        bool canPayOrder();
        Order getOrder();
        Order initOrder(Client client);
        Order payOrder(Client client);
    }
}