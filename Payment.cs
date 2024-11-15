using System;

namespace PaymentSpace
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
}
