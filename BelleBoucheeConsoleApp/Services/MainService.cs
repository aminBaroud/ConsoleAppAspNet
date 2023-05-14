using BelleBoucheeConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelleBoucheeConsoleApp.Services
{
    public class MainService : IMainService
    {
        private readonly IDisplayService _displayService;
        private readonly IProductService _productService;
        private readonly IClientService _clientService;
        private readonly IOrderService _orderService;
        private readonly IOrderHasProductsService _orderHasProductsService;
        public List<Product> _listProducts;
        public Order _order;
        public Client _client;
        public Product _product;
        

        public MainService(
            IDisplayService displayService,
            IProductService productService,
            IClientService clientService,
            IOrderService orderService,
            IOrderHasProductsService orderHasProductsService)
        {
            _displayService = displayService;
            _productService = productService;
            _clientService = clientService;
            _orderService = orderService;
            _orderHasProductsService = orderHasProductsService;
        }
        public void start()
        {

            _displayService.mainMenu();
            _listProducts = _productService.initProducts();
            _client = _clientService.initClient();
            _order = _orderService.initOrder(_client);
            _orderHasProductsService.initList();
            startSteps();
        }

        public void startSteps()
        {
            var loop = true;
            var level = 0;
            var action = "add";

            while (loop)
            {
                var data = Console.ReadLine();
               // Console.WriteLine("Current Level **********" + level);

                if (level == 0)
                {
                    // Traitement de Menu Priincipale
                    switch (data)
                    {
                        case "1":
                            _displayService.productsMenu(_listProducts);
                            break;
                        case "2":
                            _displayService.productsMenu(_listProducts);
                            _displayService.addProductToOrder();
                            level = 2;
                            action = "add";
                            break;
                        case "3":
                            _displayService.productsMenu(_listProducts);
                            _displayService.addProductToOrder();
                            level = 2;
                            action = "remove";
                            break;
                        case "4":
                            level = 3;
                            _displayService.displayFacturation(_orderHasProductsService.getOrderHasProductsList(),_order);
                            break;
                        case "5":
                            _displayService.displayOrderTotal(_order);
                            
                            break;
                        case "6":
                            _displayService.productsInventaire(_listProducts);
                            break;
                        case "7":
                            _displayService.displayHelp();
                            break;
                        case "8":
                            loop = false;
                            break;

                        case "00":
                            _displayService.mainMenu();
                            break;

                        default:
                           // level = 0;
                            break;

                    }
                }

                if (level == 1)
                {
                    switch (data)
                    {
                        case "00":
                            level = 0;
                            _displayService.mainMenu();
                            break;
                        default:
                            //level = 0;
                            break;

                    }
                }

                if (level == 2)
                {
                    
                    //Console.WriteLine("Current Level **********" + level);
                    var selectedProduct = Console.ReadLine();
                    var exist = _productService.productExist(selectedProduct);
                    if (exist)
                    {
                        _displayService.addProductToOrderQuantity();
                        var quantity = Console.ReadLine();
                        var existQuantity = _productService.productQuantityExist(selectedProduct, quantity);
                        if (existQuantity)
                        {
                            var prod = _productService.getProductById(selectedProduct);
                            _displayService.addProductToOrderSuccess();
                            _orderHasProductsService.updateProductOrder(_order, prod, quantity, action);
                            _productService.updateProductList(prod, quantity, action);

                        }
                        else
                        {
                            _displayService.addProductToOrderQuantityDoesntExist();
                        }
                    }
                    else
                    {
                        _displayService.addProductToOrderDoesntExist();
                    }
                    level = 0;
                    _displayService.mainMenu();

                }

                if (level == 3)
                {
                    _displayService.payOrder();
                    var payOrder = Console.ReadLine();
                    if (Int32.Parse(payOrder) == 1)
                    {
                        var canPay = _orderService.canPayOrder();
                        if (canPay)
                        {
                            _order =  _orderService.payOrder(_client);
                            _displayService.payOrderSuccess();
                             
                        }
                        else
                        {
                            _displayService.payOrderFail();
                        }

                        level = 0;
                        _displayService.mainMenu();

                    }

                }


                }
        }
    }
}
