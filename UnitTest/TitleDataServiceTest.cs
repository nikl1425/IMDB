using System;
using System.Linq;
using Xunit;


namespace PortFolio2.Tests
{
    public class TitleDataServiceTest
    {
        public void GetOrders()
        {
            var service = new DataService();
            var orders = service.GetOrders();
            Assert.Equal(830, orders.Count);
        }
    }
}