using BelleBoucheeConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BelleBoucheeConsoleApp.Services
{
    public class ProductService : IProductService
    {

        public List<Product> _products;


        public List<Product> initProducts()
        {
            _products = new List<Product>()
            {
                new Product()
                {
                    Id =1 ,
                    Name = "Potage inspiration du marché",
                    Price = 5.99 ,
                    Quantity= 5

                },
                 new Product()
                {
                    Id =2 ,
                    Name = "Salade panachée aux noix de Grenoble",
                    Price = 7.998 ,
                    Quantity= 5

                },
                  new Product()
                {
                    Id =3 ,
                    Name = "Foie de canard",
                    Price = 15.97 ,
                    Quantity= 2

                },
                   new Product()
                {
                    Id =4 ,
                    Name = "Huîtres fraîches",
                    Price = 18.96 ,
                    Quantity= 7

                },
                    new Product()
                {
                    Id =5 ,
                    Name = "Royal chocolat",
                    Price = 5.95 ,
                    Quantity= 8

                },
                    new Product()
                {
                    Id =5 ,
                    Name = "Crème brûlée",
                    Price = 6.94  ,
                    Quantity= 2

                }

            };
            return _products;
        }

        public List<Product> getProducts()
        {
            return _products;
        }

        public Product getProductById(string id)
        {
            var ids = Int32.Parse(id);
            var product = _products.Where(x => x.Id == ids).FirstOrDefault();
            return product;
        }

        public bool productExist(string id)
        {
            var ids = Int32.Parse(id);
            var product = _products.Where(x => x.Id == ids).FirstOrDefault();
            return product != null;
        }

        public bool productQuantityExist(string id, string quantity)
        {
            var ids = Int32.Parse(id);
            var quant = Int32.Parse(quantity);
            var product = _products.Where(x => x.Id == ids).FirstOrDefault();
            if (product != null)
            {
                if (product.Quantity < quant)
                {
                    return false;
                }
                return true;
            }
            return false;
        }

        public List<Product> updateProductList(Product prod, string quantity , string action )
        {
            var quant = Int32.Parse(quantity);
            if(action == "add")
            {
                _products.Single(x => x.Id == prod.Id).Quantity -= quant;
            }
            else {
                _products.Single(x => x.Id == prod.Id).Quantity += quant;
            }

            return _products;
        }
    }
}
