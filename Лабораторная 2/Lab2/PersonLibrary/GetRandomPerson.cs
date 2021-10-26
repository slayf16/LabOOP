using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonLibrary
{
    /// <summary>
    /// класс, для создания случайного человека
    /// </summary>
    public class GetRandomPerson
    {

        /// <summary>
        /// Список мужских имен для генерации человека
        /// </summary>
        private List<string> _nameMans = new List<string>()
        {
            "Andrey", "Alexey", "Victor", "Vladimir", "Anton",
            "German", "Dmitriy", "Roman", "Vasiliy","Valentin",
            "Nikolay","Gardey", "Boris", "Nikita", "Mark"
        };

        /// <summary>
        /// Список женских имен для генерации чловека
        /// </summary>
        private List<string> _nameWomans = new List<string>()
        {
            "Anna", "Sophia","Diana","Nastya","Natasha",
            "Lera","Alla","Elena","Tanya","Nina",
            "Marina","Arina","July","Alena","Polina",
            "Ekaterina"

        };

        /// <summary>
        /// список женских фамилий для генерации человека
        /// </summary>
        private List<string> _lastNameWomans = new List<string>()
        {
            "Krivova","Frolova","Klin","Kotina",
            "Tributova","Sonina","Trast","Sinicina",
            "Bochenkova","Vodyanova"
        };

        /// <summary>
        /// список мужских фамилий для генерации человека
        /// </summary>
        private List<string> _lastNameMans = new List<string>()
        {
            "Volkov","Katz","Fedotov","Krunin","Ham",
            "Kotov","Varenkov","Kudrin","Zadorov","Maksimov"
        };
        Random random = new Random();
        /// <summary>
        /// метод, формирующий мужчину
        /// </summary>
        /// <returns>случайный мужик</returns>
        public Person RandomMan()
        {
            
            byte age = Convert.ToByte(random.Next(1, 99));       
            return new Person(_nameMans[random.Next(0, _nameMans.Count)],
                _lastNameMans[random.Next(0, _lastNameMans.Count)], age, Sex.Male);
        }

        /// <summary>
        /// метод формирующий случайную девушку
        /// </summary>
        /// <returns>случайная девушка</returns>
        public Person RandomWoman()
        {
            
            byte age = Convert.ToByte(random.Next(1, 99));
            return new Person(_nameWomans[random.Next(0, _nameWomans.Count)],
                _lastNameWomans[random.Next(0, _lastNameWomans.Count)], age, Sex.Female);
        }


        /// <summary>
        /// рандомный взрослый чувак
        /// </summary>
        /// <returns>рандомный взрослый чувак, холостяк</returns>
        public Adult RandomAdultMan()
        {
            
            PassportTemplate passport = PassportTemplate.RandomisePassport();
            byte age = Convert.ToByte(random.Next(18, 99));
            return new Adult(_nameMans[random.Next(0, _nameMans.Count)],
                _lastNameMans[random.Next(0, _lastNameMans.Count)], age, Sex.Male, passport);

        }

        /// <summary>
        /// Рандомная взрослая чувиха
        /// </summary>
        /// <returns>Рандомная взрослая чувиха, свободная</returns>
        public Adult RandomAdultWoman()
        {

            PassportTemplate passport = PassportTemplate.RandomisePassport();
            byte age = Convert.ToByte(random.Next(18, 99));
            return new Adult(_nameWomans[random.Next(0, _nameWomans.Count)],
                _lastNameWomans[random.Next(0, _lastNameWomans.Count)], age, Sex.Female, passport);

        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Child RandomChild()
        {
            GetRandomPerson person = new GetRandomPerson();

            Adult _firstParent = person.RandomAdultMan();
            Adult _secondParent = person.RandomAdultWoman();
            Adult.GetMarried(_firstParent, _secondParent);
            
            
            
            Child child = new Child();

            Random rnd = new Random();
            byte age = Convert.ToByte(rnd.Next(1, 18));

            int _randomManWomanMassiv = rnd.Next(1, 3);
            switch (_randomManWomanMassiv)
            {

                case 1:
                   
                    child.Name = _nameWomans[random.Next(0, _nameWomans.Count)];
                    child.Sex = Sex.Female;
                    break;
                case 2:
                    child.Name = _nameMans[random.Next(0, _nameMans.Count)];
                    child.Sex = Sex.Male;
                    break;
            }
            return new Child(child.Name, _firstParent.LastName,
                     age, child.Sex, _firstParent, _secondParent);
        }




    }
}
