using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace PersonLibrary
{
    public class PassportTemplate
    {
        /// <summary>
        /// Шаблон для проверки серии паспорта.
        /// </summary>
        const string _seriesPattern = @"^[0-9]{4}$";

        /// <summary>
        /// Шаблон для проверки номера паспорта.
        /// </summary>
        const string _numberPattern = @"^[0-9]{6}$";

        /// <summary>
        /// Серия паспорта.
        /// </summary>
        private string _series;

        /// <summary>
        /// Номер паспорта.
        /// </summary>
        private string _number;

        /// <summary>
        /// Серия паспорта.
        /// </summary>
        public string Series
        {
            get
            {
                return _series;
            }
            set
            {
                IsCorrect(value, _seriesPattern);
                _series = value;
            }
        }

        /// <summary>
        /// Номер паспорта.
        /// </summary>
        public string Number
        {
            get
            {
                return _number;
            }
            set
            {
                IsCorrect(value, _numberPattern);
                _number = value;
            }
        }

        /// <summary>
        /// Конструктор класса Passport.
        /// </summary>
        /// <param name="series">Серия паспорта.</param>
        /// <param name="number">Номер паспорта.</param>
        public PassportTemplate(string series, string number)
        {
            Series = series;
            Number = number;
        }

        public PassportTemplate() { }

        /// <summary>
        /// Проверяет серию или номер паспорта на соответствие требованиям.
        /// </summary>
        /// <param name="param">Серия/номер паспорта.</param>
        /// <param name="pattern">Шаблон для проверки.</param>
        private void IsCorrect(string param, string pattern)
        {
            Regex regex = new Regex(pattern);

            if (!regex.IsMatch(param))
            {
                throw new ArgumentException("Некорректно заданы серия или номер паспорта.");
            }
        }

        public static PassportTemplate RandomisePassport()
        {
            
            Random rnd = new Random();
            string series = Convert.ToString(rnd.Next(1000, 9999));
            string number = Convert.ToString(rnd.Next(100000, 999999));
            return new PassportTemplate(series, number);
        }

    }
}
