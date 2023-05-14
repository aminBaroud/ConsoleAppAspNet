using BelleBoucheeConsoleApp.Models;

namespace BelleBoucheeConsoleApp.Services
{
    public interface IClientService
    {
        Client getClient();
        Client initClient();
    }
}