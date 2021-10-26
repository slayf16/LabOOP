using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonLibrary
{
    /// <summary>
    /// список людей
    /// </summary>
    public class PersonList
    {
        /// <summary>
        /// статический массив людей
        /// </summary>
        private Person[] _people;

        /// <summary>
        /// конструктор при вызове списка
        /// создает изначальный массив длинной 0
        /// </summary>
        public PersonList()
        {
            _people = new Person[0];

        }

        /// <summary>
        /// Свойство для просмотра информации о количестве людей в списке
        /// </summary>        
        public int Count
        {
            get
            {
                return _people.Length;
            }
        }

        /// <summary>
        /// метод для добавления человека в список
        /// автоматически изменяет длину массива
        /// </summary>
        /// <param name="person">персона, которую вносим в список</param>
        public void Addition (Person person)
        {
            Array.Resize<Person>(ref _people, _people.Length + 1);
            _people[_people.Length - 1] = person;
        }

        /// <summary>
        /// метод для добавления человека в список
        /// автоматически изменяет длину массива
        /// </summary>
        /// <param name="person">персона, которую вносим в список</param>
        public void Addition(string name, string lastName, byte age, Sex sex)
        {
            Addition(new Person(name, lastName, age, sex));
        }

        /// <summary>
        /// удаление человека по индексу
        /// </summary>
        /// <param name="Index">номер человека в массиве</param>
        public void Delete(int Index)
        {
            Array.Clear(_people, Index, 1);
            for (int i = 0; i < _people.Length - 1; i++)
            {
                Person newPositionPerson;
                if (_people[i] == null)
                {
                    newPositionPerson = _people[i];
                    _people[i] = _people[i + 1];
                    _people[i + 1] = newPositionPerson;
                }
            }

            Array.Resize<Person>(ref _people, _people.Length - 1);
        }

        /// <summary>
        /// удаление человека в конце списка
        /// </summary>
        public void Remove()
        {
            Delete(_people.Length-1);
        }

        /// <summary>
        /// поиск индекса объекта
        /// </summary>
        /// <param name="person">искомый человек в списке</param>
        /// <returns>индекс объект</returns>
        public int Position(Person person)
        {
            int position = Array.IndexOf(_people, person);
            if (position == -1)
            {
                throw new Exception("Совпадений не найдено");
            }
            return position;
        }

        /// <summary>
        /// Полностью удаляет список людей
        /// </summary>
        public void DeleteList()
        {
            _people = new Person[0];
        }

        /// <summary>
        /// индексатор, для обращения к объекту по его номеру в списке
        /// </summary>
        /// <param name="index">индекс объекта</param>
        /// <returns>объект из списка</returns>
        public Person this[int index]
        {
            get
            {
                return _people[index];
            }
            set
            {
                _people[index] = value;
            }
        }        
    }
}
