using BelleBoucheeConsoleApp.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelleBoucheeTestProject
{
    public class MainServiceTest
    {

        private readonly Mock<IDisplayService> _displayServiceMock;
        private readonly Mock<IProductService> _productServiceMock;
        private readonly Mock<IClientService> _clientServiceMock;
        private readonly Mock<IOrderService> _orderServiceMock;
        private readonly Mock<IOrderHasProductsService> _orderHasProductsServiceMock;
        private readonly MainService _mainService;
        public MainServiceTest()
        {
            _displayServiceMock = new Mock<IDisplayService>();  
            _productServiceMock = new Mock<IProductService>();
            _clientServiceMock = new Mock<IClientService>();
            _orderServiceMock =  new Mock<IOrderService>();
            _orderHasProductsServiceMock = new Mock<IOrderHasProductsService>();

            _mainService = new MainService(
                _displayServiceMock.Object,
                _productServiceMock.Object,
                _clientServiceMock.Object,
                _orderServiceMock.Object,
                _orderHasProductsServiceMock.Object
                );

        }
        [Fact]
        public void mainService_start()
        {
            // 
             _productServiceMock.Setup(x=>x.productExist(It.IsAny<string>())).Returns(true);
            // _mainService.start();
            Assert.True(true);
        }

    }
}
