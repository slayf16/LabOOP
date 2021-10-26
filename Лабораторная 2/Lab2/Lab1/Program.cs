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

            try
            {
                Random rnd = new Random();
                int x;
                GetRandomPerson person = new GetRandomPerson();
                PersonList personList = new PersonList();

                for (int i = 0; i < 7; i++)
                {
                    x = rnd.Next(1, 4);

                    switch (x)
                    {
                        case 1:
                            personList.Addition(person.RandomAdultMan());
                            break;
                        case 2:
                            personList.Addition(person.RandomAdultWoman());
                            break;
                        case 3:
                            personList.Addition(person.RandomChild());
                            break;
                    }
                    Console.WriteLine($"{i+1} {personList[i].Info}");  
                    
                }




                switch (personList[3])
                {
                    case Adult adult:
                        {
                            Console.WriteLine("Тип четвёртого человека в списке - Adult");
                            adult.NameJob = Adult.JobRandom();
                            Console.WriteLine($"работает в сфере {adult.NameJob}");

                           
                            break;
                        }
                    case Child child:
                        {
                            Console.WriteLine("Тип четвёртого человека в списке - Child");
                            child.gotoscool("Шахматный кружок");
                            Console.WriteLine($"поступил в {child.NameEducationalInstitution}");
                            break;
                        }
                }


                Console.ReadKey();


            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }

    }
}
