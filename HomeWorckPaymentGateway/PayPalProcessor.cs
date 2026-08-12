using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorckPaymentGateway
{
    public class PayPalProcessor : PaymentProcessor
    {
        public PayPalProcessor(string name, decimal feePercent): base(name, feePercent)
        {
        }

        public override bool ProcessPayment(decimal amount, string email, out string log)
        {
            if (string.IsNullOrEmpty(email) || email.Contains("@") == false)
            {
                log = "Ошибка: некорректный email PayPal.";
                return false;
            }

            decimal total = CalculateTotal(amount);

            log = $"[PayPal] Аккаунт: {email}\n" +
                  $"         Сумма: {amount} USD\n" +
                  $"         Комиссия процессора: {GetFeePercent()}%\n" +
                  $"         Итого к списанию: {total} USD";
            return true;
        }
    }
}