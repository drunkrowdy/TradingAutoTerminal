using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalAnalysis
{
    abstract class Indicator
    {
        public string Name;
        public string Type;
        /// <summary>
        /// Список исходных значений
        /// </summary>
        public List<double> Rates;
        /// <summary>
        /// Список итоговых значений индикатора, ранжированных в порядке соответственно списку исходных значений
        /// </summary>
        public List<double> Values;
        /// <summary>
        /// Хранит текстовое сообщение о результатах выполнения последней операции
        /// </summary>
        public string Error;
        bool ParametersAreOk;

        public Indicator(string type, string name)
        {
            Type = type;
            Name = name;
            Error = $"При создании индикатора {Name} возникла ошибка: ";
            ParametersAreOk = true;
        }
        public void ErrorOfInit(string errorMessage)
        {
            ParametersAreOk = false;
            Error = $"{Error}{errorMessage}";
            throw new Exception(Error);
        }

        public void EndOfInit()
        {
            Error = "Ok";
        }

        abstract public bool CreateIndicator();
        abstract public bool AddPoints();

    }
}
