using SOLID_Examples.day2.ECommerceSystem_SOLID;
using System;

namespace SOLID_Examples.day2.DI_IOC
{
    public interface IOrderService
    {
        void ProcessOrder(Order order);
    }

    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public void ProcessOrder(Order order)
        {
            // Business logic to process the order
            orderRepository.SaveOrder(order);
        }
    }

    public interface IOrderRepository
    {
        void SaveOrder(Order order);
    }

    public class OrderRepository : IOrderRepository
    {
        public void SaveOrder(Order order)
        {
            // Database interaction to save the order
        }
    }

    public class OrderController
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        public void PlaceOrder(Order order)
        {
            orderService.ProcessOrder(order);
        }
    }
}
