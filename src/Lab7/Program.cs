using System;

namespace Lab7
{
    /// <summary>
    /// Сервис расчёта цен и скидок для клиентов компании.
    /// </summary>
    public class DiscountCalculator
    {
        /// <summary>
        /// Фиксированный процент скидки для клиентов без заказов в прошлом месяце.
        /// </summary>
        public decimal DiscountRate { get; set; } = 0.25m;

        /// <summary>
        /// Проверяет, полагается ли клиенту скидка.
        /// </summary>
        /// <param name="hasOrdersLastMonth">Признак наличия заказов в прошлом месяце.</param>
        /// <returns>True, если заказов не было и скидка применяется; иначе False.</returns>
        public bool IsDiscountApplicable(bool hasOrdersLastMonth)
        {
            return !hasOrdersLastMonth;
        }

        /// <summary>
        /// Рассчитывает итоговую стоимость товара с учётом скидки.
        /// </summary>
        /// <param name="basePrice">Базовая стоимость товара.</param>
        /// <param name="hasOrdersLastMonth">Были ли заказы у покупателя в прошлом месяце.</param>
        /// <returns>Итоговая стоимость с учётом скидки 25% или базовая цена.</returns>
        public decimal GetDiscountedPrice(decimal basePrice, bool hasOrdersLastMonth)
        {
            if (hasOrdersLastMonth)
                return basePrice;

            return basePrice * (1.0m - DiscountRate);
        }

        /// <summary>
        /// Форматирует информацию о расчёте в читаемый строковый вид.
        /// </summary>
        /// <param name="basePrice">Исходная цена.</param>
        /// <param name="finalPrice">Итоговая цена.</param>
        /// <returns>Форматированная строка с отчётом по скидке.</returns>
        public string FormatSummary(decimal basePrice, decimal finalPrice)
        {
            return $"Базовая цена: {basePrice:C} | Итоговая со скидкой: {finalPrice:C}";
        }
    }

    /// <summary>
    /// Точка входа в программу.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Главный метод приложения, запускающий демонстрационный расчёт.
        /// </summary>
        /// <param name="args">Аргументы командной строки.</param>
        public static void Main(string[] args)
        {
            // Обязательное требование методички: вывод автора и группы
            Console.WriteLine("Выполнил: Кондаков А.Ю. И-42");

            var calculator = new DiscountCalculator();
            decimal basePrice = 1000m;
            bool hasOrders = false;

            decimal finalPrice = calculator.GetDiscountedPrice(basePrice, hasOrders);

            Console.WriteLine($"Базовая цена: {basePrice}");
            Console.WriteLine($"Наличие заказов в прошлом месяце: {hasOrders}");
            Console.WriteLine($"Цена со скидкой: {finalPrice}\n");
            Console.WriteLine(calculator.FormatSummary(basePrice, finalPrice));
        }
    }
}