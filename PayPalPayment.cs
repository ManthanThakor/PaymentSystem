using System;
using PaymentSpace;

namespace PayPalSpace
{
   
    public class PayPalPayment : Payment
    {
        public string PayPalAccount;

        public PayPalPayment(string paypalAccount, double amount) : base("Paypal", amount)
        {
            PayPalAccount = paypalAccount;
        }

        public override bool ValidateSpecificPayment()
        {
            if (string.IsNullOrEmpty(PayPalAccount))
            {
                Console.WriteLine("Invalid Paypal account.");
                return false;
            }
            Console.WriteLine("Paypal Payment Validated.");
            return true;
        }

        public override void ProcessPayment()
        {
            Console.WriteLine($"Processing PayPal Payment of {Amount}$...");
            Console.WriteLine("Payment Successful (PayPal).");
        }
    }

    
}
