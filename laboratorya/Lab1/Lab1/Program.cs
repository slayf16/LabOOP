using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonLibrary;


namespace Lab1
{
    /// <summary>
    /// класс для тестирования библиотеки персоны
    /// </summary>
    public class Program
    {
        
        /// <summary>
        /// точка входа в программу
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            
            GetRandomPerson person = new GetRandomPerson();
            PersonList personMan = new PersonList();
            PersonList personWoman = new PersonList();
            for (int i = 0; i < 3; i++)
            {
                personWoman.Addition(person.RandomWoman());
                personMan.Addition(person.RandomMan());
            }

            Console.WriteLine("Создание списков: ");
            Console.ReadKey();

            Console.WriteLine("Список мальчиков");
            Print(personMan);
            Console.WriteLine(" ");
            Console.WriteLine("Список девочек");
            Print(personWoman);
            Console.WriteLine("добавление человека: ");
            Console.ReadKey();


            personMan.Addition("Andrey","Klimov",54,Sex.Male);
            Console.WriteLine("Список мальчиков");
            Print(personMan);
            Console.WriteLine(" ");
            Console.WriteLine("Список девочек");
            Print(personWoman);
            Console.WriteLine("копирование человека: ");
            Console.ReadKey();

            personWoman.Addition(personMan[1]);
            Console.WriteLine("Список мальчиков");
            Print(personMan);
            Console.WriteLine(" ");
            Console.WriteLine("Список девочек");
            Print(personWoman);
            Console.WriteLine("удаление человека: ");
            Console.ReadKey();

            personMan.Delete(1);
            Console.WriteLine("Список мальчиков");
            Print(personMan);
            Console.WriteLine(" ");
            Console.WriteLine("Список девочек");
            Print(personWoman);
            Console.WriteLine("Удаление списка: ");
            Console.ReadKey();

            personWoman.DeleteList();
            Console.WriteLine("Список мальчиков");
            Print(personMan);
            Console.WriteLine(" ");
            Console.WriteLine("Список девочек");
            Print(personWoman);
            Console.WriteLine(" ");
            Console.ReadKey();
            
           
            
            while(true)
            { 
                Console.WriteLine("{Хотите дописать человека? (да/нет) ");
                string enterPerson = Convert.ToString(Console.ReadLine());
                                                
                    //TODO: switch
                if (enterPerson == "да")
                {
                    Person kent = ReadPerson();
                    Console.WriteLine($"Ваш человек: {kent.Info}");                                       
                }
                else if (enterPerson=="нет")
                {
                    Console.WriteLine("Закрываем");
                    break;
                }
            }
        }
        /// <summary>
        /// вывод массива на консоль
        /// </summary>
        /// <param name="people">список людей, который нужно вывести</param>
        public static void Print(PersonList people)
        {
            for (int i = 0; i < people.Count; i++) 
            {
                Console.Write($"{people[i].Name} {people[i].LastName}\n" 
                                + $"\tвозраст: {people[i].Age}\n" 
                                + $"\tпол: {people[i].Sex}\n");
            }
        }


        /// <summary>
        /// мтод для работы с консолью 
        /// </summary>
        /// <returns>персона введенная с консоли</returns>
        private static Person ReadPerson()
        {
            Person personFromConsole = new Person();
            var validationActions = new List<Tuple<string, Action>>()
            {
                new Tuple<string, Action>
                (
                    "Введите имя: ",
                    () =>
                    {
                        personFromConsole.Name = Console.ReadLine();
                    }
                ),
                new Tuple<string, Action>
                (
                    "Введите фамилию: ",
                    () =>
                    {
                        personFromConsole.LastName = Console.ReadLine();
                    }
                ),
                new Tuple<string, Action>
                (
                    "Введите возраст: ",
                    () =>
                    {
                        //TODO: RSDN
                        var stringAge = Console.ReadLine();
                        if (!int.TryParse(stringAge, out int vos))
                        {
                            throw new ArgumentException("Возраст длжен быть числом");
                        }
                        personFromConsole.Age = vos;
                    }
                ),
                 new Tuple<string, Action>
                (
                    "Введите пол персоны (Male/Female): ",
                    () =>
                    {
                        string genderString = Console.ReadLine();
                        if (!Enum.IsDefined(typeof(Sex), genderString))
                        {
                            throw new ArgumentException("Некорректно введён пол.");
                        }
                        personFromConsole.Sex = (Sex)Enum.Parse(typeof(Sex),
                            genderString, true);
                    }
                ),

            };
            foreach (var actionItem in validationActions)
            {
                ValidateInput(actionItem.Item1, actionItem.Item2);
            }

            return personFromConsole;

        }
        /// <summary>
        /// Проверка корректности вводимых параметров.
        /// </summary>
        /// <param name="outputMessage">Параметр для проверки</param>
        /// <param name="validationAction">метод проверки</param>
        private static void ValidateInput(string outputMessage,
           Action validationAction)
        {
            while (true)
            {
                try
                {
                    Console.Write(outputMessage);
                    validationAction();
                    return;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}\nПопробуйте снова.");
                }
            }
        }
    }
}
