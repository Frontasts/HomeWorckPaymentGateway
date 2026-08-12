using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorckPaymentGateway
{
    public class Application
    {
        private PaymentProcessor[] _processors;
        private bool _running;

        public Application()
        {
            _running = true;
            _processors = new PaymentProcessor[3];
            _processors[0] = new CreditCardProcessor("Visa / Mastercard", 2.5m);
            _processors[1] = new PayPalProcessor("PayPal", 3.0m);
            _processors[2] = new CryptoProcessor("Bitcoin Gateway", 1.5m, "BTC", 65000m, 0.0001m);
        }

        public void Run()
        {

        }
    }
}