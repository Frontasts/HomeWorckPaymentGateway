using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorckPaymentGateway
{
    public abstract class PaymentProcessor
    {
        private string _processorName;
        private decimal _feePercent;

        public PaymentProcessor(string name, decimal feePercent)
        {
            _processorName = name;
            _feePercent = feePercent;
        }

        public decimal CalculateTotal(decimal amount)
        {
            return amount + (amount * _feePercent / 100m);
        }

        public abstract bool ProcessPayment(decimal amount, string accountId, out string log);

        public string GetProcessorName()
        {
            return _processorName;
        }
        public decimal GetFeePercent()
        {
            return _feePercent;
        }
    }
}