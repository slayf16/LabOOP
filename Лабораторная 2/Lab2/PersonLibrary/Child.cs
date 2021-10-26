using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonLibrary
{
    public class Child : Person
    {
        /// <summary>
        /// Максимальный возраст ребенка
        /// </summary>
        public const int MaxAageChilde = 17;

        /// <summary>
        /// переменная для названия школы/сада
        /// </summary>
        public string NameEducationalInstitution { get; set; }

        /// <summary>
        /// первый родитель 
        /// </summary>
        public Adult FirstParent { get; set; }

        /// <summary>
        /// Второй родитель
        /// </summary>
        public Adult SecondParent { get; set; }

        /// <summary>
        /// реализация базового метода получения информации 
        /// для ребенка
        /// </summary>
        public override string Info
        {
            get
            {
                string _firstParent = FirstParent != null
                    ? $"{FirstParent.Name} {FirstParent.LastName}"
                    : $"Отсутствует";
                string _secondParent = SecondParent != null
                 ? $"{SecondParent.Name} {SecondParent.LastName}"
                 : $"Отсутствует";



                return ($"{base.Info}\n"
                    + $"\tпервый родитель: {_firstParent}\n"
                    + $"\tвторой родитель: {_secondParent}\n"
                    + $"\tдетский сад/школа: {NameEducationalInstitution}\n");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private const int _ageMin = 0;
        private const int _ageMax = 18;
        /// <summary>
        /// 
        /// </summary>
        public override int Age 
        { 
            get
            {
                return _age;
            }
            
            
            set
            {
                if (value > _ageMin && value < _ageMax)
                {
                    _age = value;
                }
                else
                {
                    throw new ArgumentException("введите возраст от " +
                        $"{_ageMin} до {_ageMax} лет для ребенка");
                }

            }
        }
        /// <summary>
        /// 
        /// </summary>
        public Child() { }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="age"></param>
        /// <param name="sex"></param>
        /// <param name="firstParent"></param>
        public Child(string firstName, string lastName, int age, 
            Sex sex, Adult firstParent) : base(firstName,lastName,age,sex)
        {
            FirstParent = firstParent;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="age"></param>
        /// <param name="sex"></param>
        /// <param name="firstParent"></param>
        /// <param name="secondParent"></param>
        public Child(string firstName, string lastName, int age,
          Sex sex, Adult firstParent, Adult secondParent) : this(firstName, lastName, age, sex, firstParent)
        {
            SecondParent = secondParent;
        }
        public void gotoscool(string school)
        {
            NameEducationalInstitution = school;
        }
    }
}
