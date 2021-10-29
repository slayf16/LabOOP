using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace PersonLibrary
{
    /// <summary>
    /// описание человека 
    /// </summary>
    public class Person
    {

        /// <summary>
        /// внутренняя переменная для имени, после проверок
        /// </summary>
        private string _name;

        /// <summary>
        /// Переменная Имени, значение которой записывает пользователь 
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                CheckName(value);
                _name = ChangeRegister(value);

            }
        }

        /// <summary>
        /// Внутренняя переменная для фамилии, после проверок
        /// </summary>
        private string _lastName;

        /// <summary>
        /// Переменная Фамилии, значение которой записывает пользователь 
        /// </summary>
        public string LastName
        {
            get
            {
                return _lastName;
            
            }
            set
            {
                CheckName(value);
                _lastName = ChangeRegister(value);
            }
        }

        /// <summary>
        /// внутренняя переменная для возраста, после проверок
        /// </summary>
        private int _age;

        /// <summary>
        /// Переменная Имени, значение которой записывает пользователь 
        /// </summary>
        public int Age
        {
            get
            {
                return _age; 
            }

            set
            {
                //TODO: const
                if (value > 0 && value < 100)
                {
                    _age = value;
                }
                else
                {
                    throw new ArgumentException("введите возраст от " +
                        "0 до 99 лет");
                }
            }
        }

        /// <summary>
        /// переменная "пол человека"
        /// </summary>
        public Sex Sex { get; set; }

        
        /// <summary>
        /// создание объекта
        /// </summary>
        /// <param name="name">имя</param>
        /// <param name="lastName">фамилия</param>
        /// <param name="age">возраст</param>
        /// <param name="sex">пол</param>
        public Person(string name, string lastName, int age, Sex sex) 
        {
            Name = name;
            LastName = lastName;
            Age = age; 
            this.Sex = sex;
        }

        /// <summary>
        /// Конструктор для создания дефолтной персоны
        /// </summary>
        public Person() : this("Неизвестно", "Неизвестно", 1, Sex.Male) { }
                   

        /// <summary>
        /// Возвращает полностью всю информацию о персоне
        /// </summary>
        public string Info
        {
            get
            {
                return $"{Name} {LastName}\n" +
                $"\tвозраст: {Age}\n" +
                $"\tпол: {Sex}";
            }
        }
       
        /// <summary>
        /// Переводит первый символ у слов в верхний регистр,
        /// а другие - в нижний регистр
        /// </summary>
        /// <param name="name">входная строка (имя, фамилия)</param>
        /// <returns>Возвращает строку с измненным регистром у первого смвола</returns>
        private static string ChangeRegister(string name)
        {
            string verifiedName;
            string[] arrayFName = name.Split();
            for (int i = 0; i < arrayFName.Length; i++)
            {
                string symbolName = arrayFName[i];
                if (!String.IsNullOrEmpty(symbolName))
                {
                    symbolName = Char.ToUpper(symbolName[0]) 
                        + symbolName.Substring(1);
                }
                arrayFName[i] = symbolName;
            }
            verifiedName = String.Join(" ", arrayFName);
            return verifiedName;
        }

        /// <summary>
        /// метод для проверки имени на корректность
        /// </summary>
        /// <param name="name">входная строка для проверки (имя, фамилия )</param>
        private void CheckName(string name)
        {
            string[] arrayFName = name.Split();

            string regex = @"[\W]|[0-9]";
            for (int i = 0; i < arrayFName.Length; i++)
            {
                string symbolName = arrayFName[i];
                char[] arraySymbolName = symbolName.ToCharArray();
                for (int j = 0; j < arraySymbolName.Length; j++)
                {
                    if (Regex.IsMatch(arraySymbolName[j].ToString(), regex) == true)
                    {
                        throw new ArgumentException("Имя и фамилия должны быть " +
                            "написаны только текстовыми символами");
                    }
                }
            }

        }
    }
}
