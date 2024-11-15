using System;
using PaymentSpace;

namespace CreditCardSpace
{
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
            Console.WriteLine($"Processing Credit Card Payment of {Amount}$...");
            Console.WriteLine("Payment Successful (Credit Card).");
        }
    }
}
