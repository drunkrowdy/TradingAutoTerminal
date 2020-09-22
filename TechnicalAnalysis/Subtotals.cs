using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalAnalysis
{
    /// <summary>
    /// Базовый класс для хранения промежуточных итогов расчета индикатора
    /// </summary>
    abstract class Subtotals
    {
        /// <summary>
        /// Текущая цена 
        /// </summary>
        public double Price;
        /// <summary>
        /// Предыдущая цена 
        /// </summary>
        public double PreviousPrice;
        //public abstract object Value { get; set; }

        /// <summary>
        /// Обновляет текущую цену передаваемым значением
        /// </summary>
        /// <param name="price">Значение текущей цены</param>
        public void UpdatePrice(double price) => Price = price;
        public void UpdatePreviousPrice() => PreviousPrice = Price;
        public double GetDifferencePrices() => Price - PreviousPrice;
    }
}
