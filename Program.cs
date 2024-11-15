using System;

namespace PaymentSystem
{
    
    public abstract class Payment
    {
        public string PaymentMethod;
        public double Amount;

        public Payment(string paymentMethod, double amount)
        {
            PaymentMethod = paymentMethod;
            Amount = amount;
        }

        public bool ValidatePayment()
        {
            if (Amount <= 0)
            {
                Console.WriteLine("Invalid payment amount.");
                return false;
            }
            return true;
        }

        public abstract bool ValidateSpecificPayment();

        public abstract void ProcessPayment();

    }
    public class CreditCardPayment : Payment
    {
        public string CardNumber;
        public string ExpirationDate;
        public string CVV;

        public CreditCardPayment(string cardNumber, string expirationDate, string cvv, double amount)
            : base("Credit Card", amount)
        {
            CardNumber = cardNumber;
            ExpirationDate = expirationDate;
            CVV = cvv;
        }

        public override bool ValidateSpecificPayment()
        {
            if (string.IsNullOrEmpty(CardNumber) || string.IsNullOrEmpty(ExpirationDate) || string.IsNullOrEmpty(CVV))
            {
                Console.WriteLine("Invalid credit card details.");
                return false;
            }
            Console.WriteLine("Credit Card Payment Validated.");
            return true;
        }

        public override void ProcessPayment()
        {
            Console.WriteLine($"Processing Credit Card Payment of {Amount:C}...");
            Console.WriteLine("Payment Successful (Credit Card).");
        }
    }

    public class PayPalPayment : Payment
    {
        public string PayPalAccount;

        public PayPalPayment(string paypalAccount, double amount): base("Paypal",amount)
        {
            PayPalAccount = paypalAccount;
        }

        public override bool ValidateSpecificPayment()
        {
            if(string.IsNullOrEmpty(PayPalAccount))
            {
                Console.WriteLine("Invalid Paypal account.");
                    return false;
            }
            Console.WriteLine("Paypal Payment Validated.");
            return true;
        }

        public override void ProcessPayment()
        {
            Console.WriteLine($"Processing PayPal Payment of {Amount:C}...");

            Console.WriteLine("Payment Successful (PayPal).");
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n \"The Payment System \"\n");

            //var payment = new Payment();

            var creditCardPayment = new CreditCardPayment("132131232", "12/23", "123", 200);
            var payPalPayment = new PayPalPayment("user@paypal.com", 75.00);

        
            if (creditCardPayment.ValidatePayment() && creditCardPayment.ValidateSpecificPayment())
            {
                creditCardPayment.ProcessPayment();
            }

            if (payPalPayment.ValidatePayment() && payPalPayment.ValidateSpecificPayment())
            {
                payPalPayment.ProcessPayment();
            }

            Console.ReadLine();
        }
    }

}