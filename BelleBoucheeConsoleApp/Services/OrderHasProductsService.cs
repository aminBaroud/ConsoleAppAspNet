using BelleBoucheeConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BelleBoucheeConsoleApp.Services
{
    public class OrderHasProductsService : IOrderHasProductsService
    {
        public List<OrderHasProducts> _orderHasProducts;
        public int _id = 1;
        public void initList()
        {
            _orderHasProducts = new List<OrderHasProducts>();
        }

        public List<OrderHasProducts> getOrderHasProductsList()
        {
            if (_orderHasProducts == null)
            {
                initList();
            }
            return _orderHasProducts;
        }
        public void updateProductOrder(Order order, Product product, string quantity , string action )
        {

            var quant  = Int32.Parse(quantity);
            if(action == "add")
            {
            var item = new OrderHasProducts()
            {
                Id = _id,
                Product = product,
                Order = order,
                Quantity = quant
            };
            _id++;
            _orderHasProducts.Add(item);
            }
            else
            {
                var item = _orderHasProducts.Single(x => x.Product.Id == product.Id);
                if(_orderHasProducts.Single(x => x.Product.Id == product.Id).Quantity - quant == 0)
                {
                    _orderHasProducts.Remove(item);
                }
                else
                {
                    _orderHasProducts.Single(x => x.Product.Id == product.Id).Quantity -= quant;
                }
                
            }
            double orderSubTotale = 0;


            foreach(var line in _orderHasProducts)
            {
                orderSubTotale = (double)(orderSubTotale + line.Product.Price * line.Quantity);
            }
            order.SubTotal = orderSubTotale;
            order.TVQ = orderSubTotale * 8.5/100;
            order.TPS = order.TVQ * 5 / 100;
            order.Total = order.SubTotal + order.TVQ + order.TPS;


        }

        public void removeProductOrder(Product product)
        {
            var item = _orderHasProducts.Where(x => x.Product.Id == product.Id).FirstOrDefault();
            _orderHasProducts.Remove(item);
            _id--;
        }
    }
}
