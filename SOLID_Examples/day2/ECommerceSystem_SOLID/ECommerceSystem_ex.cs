namespace SOLID_Examples.day2.ECommerceSystem_SOLID
{
    public class ECommerceSystem_ex
    {
        private List<Product_ex> products = new List<Product_ex>();
        private List<Order_ex> orders = new List<Order_ex>();
        public void AddProduct(string name, decimal price, int quantity)
        {
            products.Add(new Product_ex
            {
                Name = name,
                Price = price,
                Quantity = quantity

            });
        }
        public void PlaceOrder(string customerName, List<int> productIds, string paymentMethod)
        {
            decimal totalCost = 0;
            List<Product_ex> orderedProducts = new List<Product_ex>();
            foreach (int productId in productIds)
            {
                Product_ex product = products.Find(p => p.Id == productId);
                if (product != null && product.Quantity > 0)
                {
                    {
                        orderedProducts.Add(product);
                        totalCost += product.Price;
                        product.Quantity--;
                    }
                }
                if (orderedProducts.Count > 0)
                {
                    if (paymentMethod == "CreditCard")
                    {
                        ProcessCreditCardPayment(totalCost);
                    }
                    else if (paymentMethod == "PayPal")
                    {
                        ProcessPayPalPayment(totalCost);
                    }
                    Order_ex order = new Order_ex
                    {
                        CustomerName = customerName,
                        Products = orderedProducts,
                        TotalCost = totalCost
                    };
                    orders.Add(order);
                    SendOrderConfirmationEmail(order);
                }
            }

        }
        private void ProcessCreditCardPayment(decimal amount)
        {
            //Process credit card payment
            Console.WriteLine($"Processing credit card payment of ${amount}");
        }
        private void ProcessPayPalPayment(decimal amount)
        {
            //Process PayPal payment
            Console.WriteLine($"Processing PayPal payment of ${amount}");
        }
        private void SendOrderConfirmationEmail(Order_ex order)
        {
            string message = $"Order confirmation for {order.CustomerName}:\n";
            message += $"Total Cost: ${order.TotalCost}\n";
            message += "Products:\n";
            foreach (Product_ex product in order.Products)
            {
                message += $"- {product.Name} (${product.Price})\n";
            }
            //Send email
            Console.WriteLine(message);
        }

    }
    public class Product_ex
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
    public class Order_ex
    {
        public string CustomerName { get; set; }
        public List<Product_ex> Products { get; set; }
        public decimal TotalCost { get; set; }
    }

}
