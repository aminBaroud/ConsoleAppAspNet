using BelleBoucheeConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelleBoucheeConsoleApp.Services
{
    public class ClientService : IClientService
    {
        public Client _client;
        public Client initClient()
        {
            _client = new Client()
            {
                ID = 1,
                Name = "Belle Bouchee",
                Email = "BelleBouchee@gmail.com"
            };

            return _client;
        }

        public Client getClient()
        {
            return _client;
        }
    }
}
