using System;
using PaymentSpace;
using PayPalSpace;
using CreditCardSpace;

namespace PaymentSystem
{
   
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n \"The Payment System \"\n");

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
