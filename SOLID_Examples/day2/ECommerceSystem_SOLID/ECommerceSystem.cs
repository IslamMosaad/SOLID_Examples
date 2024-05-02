namespace SOLID_Examples.day2.ECommerceSystem_SOLID
{
    public interface IECommerceSystem
    {
        List<IProduct> products { get; set; }
        List<IOrder> orders { get; set; }
    }
    public class ECommerceSystem : IECommerceSystem
    {
        public List<IProduct> products { get; set; }
        public List<IOrder> orders { get; set; }

        public ECommerceSystem(List<IProduct> _products, List<IOrder> _orders)
        {
            this.products = _products;
            this.orders = _orders;
        }


    }
    public class ProductService
    {
        public void AddProduct(IECommerceSystem eCommerceSystem, IProduct product)
        {
            eCommerceSystem.products.Add(product);
        }
    }

    public class OrderService
    {
        private readonly IECommerceSystem ECSystem;
        private readonly IPaymentProcess paymentProcess;
        private readonly IConfirmationEmailSender emailSender;
        public OrderService(IECommerceSystem _ECSystem, IPaymentProcess _paymentProcess, IConfirmationEmailSender _emailSender)
        {
           paymentProcess = _paymentProcess;
           ECSystem = _ECSystem;
           emailSender= _emailSender;  
        }
        
        private List<IProduct> CreateOrderedProducts( List<int> productIds, out decimal totalCost)
        {
            totalCost = 0;
            List<IProduct> orderedProducts = new List<IProduct>();
            foreach (int productId in productIds)
            {
                IProduct product = ECSystem.products.Find(p => p.Id == productId);
                if (product != null && product.Quantity > 0)
                {
                    orderedProducts.Add(product);
                    totalCost += product.Price;
                    product.Quantity--;
                }
            }
            return orderedProducts;


        }
        public void PlaceOrder(  List<int> productIds, string customerName)
        {
            decimal totalCost = 0;

            List<IProduct> orderedProducts = CreateOrderedProducts( productIds, out totalCost);
            if (orderedProducts.Count > 0)
            {
                paymentProcess.ProcessPayment(totalCost);
                Order order = new Order { CustomerName = customerName, Products = orderedProducts, TotalCost = totalCost };
                ECSystem.orders.Add(order);
                emailSender.SendOrderConfirmationEmail(order);
            }
        }
    }


    public interface IConfirmationEmailSender
    {
        void SendOrderConfirmationEmail(IOrder order);
    }
    public class ConfirmationEmailSender : IConfirmationEmailSender
    {
        public void SendOrderConfirmationEmail(IOrder order)
        {
            string message = $"Order confirmation for {order.CustomerName}:\n";
            message += $"Total Cost: ${order.TotalCost}\n";
            message += "Products:\n";
            foreach (IProduct product in order.Products)
            {
                message += $"- {product.Name} (${product.Price})\n";
            }
            //Send email
            Console.WriteLine(message);
        }
    }


    public interface IPaymentProcess
    {
        void ProcessPayment(decimal amount);
    }
    public class CreditCardPaymentMethod : IPaymentProcess
    {
        public void ProcessPayment(decimal amount)
        {
            //Process credit card payment
            Console.WriteLine($"Processing credit card payment of ${amount}");
        }
    }
    public class PayPalPaymentMethod : IPaymentProcess
    {
        public void ProcessPayment(decimal amount)
        {
            //Process PayPal payment
            Console.WriteLine($"Processing PayPal payment of ${amount}");
        }
    }




    public interface IProduct
    {
        int Id { get; set; }
        string Name { get; set; }
        decimal Price { get; set; }
        int Quantity { get; set; }
    }
    public interface IOrder
    {
        string CustomerName { get; set; }
        List<IProduct> Products { get; set; }
        decimal TotalCost { get; set; }
    }
    public class Product : IProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
    public class Order : IOrder
    {
        public string CustomerName { get; set; }
        public List<IProduct> Products { get; set; }
        public decimal TotalCost { get; set; }
        public Order()
        {

        }
        public Order(List<IProduct> _Products)
        {
            this.Products = _Products;
        }
    }


}
