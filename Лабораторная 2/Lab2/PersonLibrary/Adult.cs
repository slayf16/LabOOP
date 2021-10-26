using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonLibrary
{
    public class Adult : Person
    {
        /// <summary>
        /// Минимальный возраст взрослого 
        /// </summary>
        public const int MinAgeForAdult = 18;


        /// <summary>
        /// Данные паспорта
        /// </summary>
        public PassportTemplate Passport { get; set; }


        /// <summary>
        /// переменная для наименования работы
        /// </summary>
        public string NameJob { get; set; }

        /// <summary>
        /// переменная для супруга 
        /// </summary>
        public Adult Partner { get; set; }

        /// <summary>
        /// Семейное положение.
        /// </summary>
        public bool IsMarried
        {
            get
            {
               
                return (Partner != null);
            }
        }

        /// <summary>
        /// Ребенок 
        /// </summary>
        public Child Child { get; set; }

        /// <summary>
        /// реализация базового метода получения информации 
        /// для взрослого
        /// </summary>
        public override string Info
        {
            get
            {
                string child = Child != null
                    ? $"{Child.Name} {Child.LastName}, {Child.Age} лет"
                    : $"нет детей";
                string partner ="";
                if (Partner != null)
                {
                    partner = $"{Partner.Name} {Partner.LastName}";
                }
                else
                {
                    
                    switch (this.Sex)
                    {

                        case Sex.Male:
                            partner = "не женат";
                            break;
                        case Sex.Female:
                            partner = "не замужем";
                            break;                                                      

                    }
                }

                if(String.IsNullOrEmpty(NameJob))
                {
                    NameJob = "Безработный";
                }
                    

                return ($"{base.Info}\n"
                    + $"\tдети: {child}\n"
                    + $"\tработа: {NameJob}\n"
                    + $"\tСупруг(а): {partner}\n");
            }
        }
        


        /// <summary>
        /// Связывает узами брака двух персон.
        /// </summary>
        /// <remarks>
        /// Проверка полов не осуществляется.
        /// </remarks>
        /// <param name="_firstPartner"></param>
        /// <param name="_secondPartner"></param>
        public static void GetMarried(Adult _firstPartner, Adult _secondPartner)
        {
            _firstPartner.Partner = _secondPartner;
            _secondPartner.Partner = _firstPartner;
            _secondPartner.LastName = _firstPartner.LastName;
        }
        /// <summary>
        /// 
        /// </summary>
        private const int _ageMin = 18;
        private const int _ageMax = 99;
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
                        $"{_ageMin} до {_ageMax} лет для взрослого");
                }

            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="age"></param>
        /// <param name="sex"></param>
        /// <param name="passport"></param>
        public Adult(string firstName, string lastName, int age,
        Sex sex, PassportTemplate passport) : base(firstName, lastName, age, sex)
        {
            Passport = passport;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="age"></param>
        /// <param name="sex"></param>
        /// <param name="passport"></param>
        /// <param name="partner"></param>
        public Adult(string firstName, string lastName, int age,
        Sex sex, PassportTemplate passport, Adult partner) : this(firstName, lastName, age, sex, passport)
        {        
            Partner = partner;
        }
        /// <summary>
        /// пустой конструктор
        /// </summary>
        public Adult() { }


        public static string JobRandom ()
        {
            string[] Job = new string[] { "авиастроение", "рыболовство",
                "продажи", "Градоуправление","медицина" };


            Random random = new Random();


            return Job[random.Next(0, 4)];
        }

    }
}
