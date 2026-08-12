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

        public bool CheckExchangeRate()
        {
            return _exchangeRate > 0;
        }

        public override bool ProcessPayment(decimal amount, string walletAddress, out string log)
        {
            if (CheckExchangeRate() == false)
            {
                log = "Ошибка: криптовалютный курс недоступен или некорректен.";
                return false;
            }

            if (string.IsNullOrEmpty(walletAddress) || walletAddress.Length < 10)
            {
                log = "Ошибка: неверный адрес кошелька.";
                return false;
            }

            decimal cryptoAmount = amount / _exchangeRate;

            if (cryptoAmount <= _networkFee)
            {
                log = $"Ошибка: сумма слишком мала для покрытия сетевой комиссии ({_networkFee} {_cryptoType}).";
                return false;
            }

            decimal finalCrypto = cryptoAmount - _networkFee;
            decimal totalFiat = CalculateTotal(amount);

            log = $"[Crypto] Кошелёк: {walletAddress}\n" +
                  $"         Сумма: {amount} USD -> {cryptoAmount:F6} {_cryptoType}\n" +
                  $"         Сетевая комиссия: {_networkFee} {_cryptoType}\n" +
                  $"         К получению: {finalCrypto:F6} {_cryptoType}\n" +
                  $"         Комиссия шлюза: {GetFeePercent()}% = {amount * GetFeePercent() / 100m} USD\n" +
                  $"         Всего к оплате: {totalFiat} USD";
            return true;
        }
    }
}