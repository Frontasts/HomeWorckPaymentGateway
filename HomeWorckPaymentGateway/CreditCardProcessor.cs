using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorckPaymentGateway
{
    public class CreditCardProcessor : PaymentProcessor
    {
        public CreditCardProcessor(string name, decimal feePercent): base(name, feePercent)
        {
        }
    }
}
