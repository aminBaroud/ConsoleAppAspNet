using BelleBoucheeConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelleBoucheeConsoleApp.Services
{
    public class OrderService : IOrderService
    {
        public Order _order;
        public int _id = 1;
        public Order initOrder(Client client)
        {
            _order = new Order()
            {
                Id = _id,
                Client = client,
                CreationDate = DateTime.Now,
                Total = 0,
                SubTotal = 0,
                TPS = 0,
                TVQ = 0,
            };

            return _order;
        }

        public Order getOrder()
        {

            return _order;
        }

        public bool canPayOrder()
        {
            if (_order.Total > 100)
            {
                return false;
            }
            return true;
        }

        public Order payOrder(Client client)
        {
            _id++;
            _order = new Order()
            {
                Id = 1,
                Client = client,
                CreationDate = DateTime.Now,
                Total = 0,
                SubTotal = 0,
                TPS = 0,
                TVQ = 0,
            };

            return _order;
        }
    }
}
