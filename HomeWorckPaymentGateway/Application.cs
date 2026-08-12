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
            const string ExitCommand = "0";

            Console.WriteLine("=== Платёжный шлюз ===");

            while (_running)
            {
                Console.WriteLine();
                Console.WriteLine("Доступные процессоры:");

                for (int i = 0; i < _processors.Length; i++)
                {
                    string name = _processors[i].GetProcessorName();
                    decimal fee = _processors[i].GetFeePercent();

                    Console.WriteLine($"{i + 1}. {name} (комиссия: {fee}%)");
                }

                Console.WriteLine($"{ExitCommand}. Выход");
                Console.Write("Выберите процессор: ");

                string input = Console.ReadLine();

                if (input == ExitCommand)
                {
                    _running = false;
                }
                else if (int.TryParse(input, out int choice) == false || choice < 1 || choice > _processors.Length)
                {
                    Console.WriteLine("Неверный выбор.");
                }
                else
                {
                    PaymentProcessor selected = _processors[choice - 1];

                    Console.Write("Введите идентификатор (карта / email / кошелёк): ");
                    string account = Console.ReadLine();

                    Console.Write("Введите сумму (USD): ");

                    if (decimal.TryParse(Console.ReadLine(), out decimal amount) == false || amount <= 0)
                    {
                        Console.WriteLine("Некорректная сумма.");
                    }
                    else
                    {
                        bool success = selected.ProcessPayment(amount, account, out string log);

                        Console.WriteLine(log);
                        Console.WriteLine(success ? ">>> Платёж успешно обработан." : ">>> Платёж отклонён.");
                    }
                }
            }
        }
    }
}