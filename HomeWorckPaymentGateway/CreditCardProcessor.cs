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

        public override bool ProcessPayment(decimal amount, string cardNumber, out string log)
        {
            if (string.IsNullOrEmpty(cardNumber) || cardNumber.Length != 16)
            {
                log = "Ошибка: номер карты должен содержать ровно 16 цифр.";
                return false;
            }

            decimal total = CalculateTotal(amount);
            string last4 = cardNumber.Substring(cardNumber.Length - 4);

            log = $"[CreditCard] Карта ****{last4}\n" +
                  $"             Сумма: {amount} USD\n" +
                  $"             Комиссия процессора: {GetFeePercent()}%\n" +
                  $"             Итого к списанию: {total} USD";
            return true;
        }
    }
}
