namespace SOLID_Examples.day1.PaymentProcessor_OCP
{
    internal class PaymentProcessor
    {
        #region Violate OCP
        //public void ProcessPayment(PaymentType type, double amount)
        //{

        //switch (type)
        //{
        //    case PaymentType.CreditCard:
        //        // Process credit card payment
        //        break;
        //    case PaymentType.PayPal:
        //        //  Process PayPal payment
        //        break;
        //    case PaymentType.BankTransfer:
        //        //  Process bank transfer payment
        //        break;
        //        // Add more cases for other payment types
        //}

        //}
        #endregion

        public void ProcessPayment(IPaymentType type, double amount)
        {
            type.processPayment(amount);
        }
    }
    //public enum PaymentType
    //{
    //    CreditCard,
    //    PayPal,
    //    BankTransfer
    //}
    public interface IPaymentType
    {
        void processPayment(double amount);
    }
    internal class CreditCardType : IPaymentType
    {
        public void processPayment(double amount)
        {
            //different Code
        }
    }
    internal class PayPalType : IPaymentType
    {
        public void processPayment(double amount)
        {
            //different Code
        }
    }
    internal class BankTransferType : IPaymentType
    {
        public void processPayment(double amount)
        {
            //different Code
        }
    }
    internal class VisaType : IPaymentType
    {
        public void processPayment(double amount)
        {
            //different Code
        }
    }

}
