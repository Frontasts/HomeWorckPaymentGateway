using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorckPaymentGateway
{
    public class CryptoProcessor : PaymentProcessor
    {
        private string _cryptoType;
        private decimal _exchangeRate;
        private decimal _networkFee;

        public CryptoProcessor(string name, decimal feePercent, string cryptoType, decimal exchangeRate, decimal networkFee) : base(name, feePercent)
        {
            _cryptoType = cryptoType;
            _exchangeRate = exchangeRate;
            _networkFee = networkFee;
        }
    }
}