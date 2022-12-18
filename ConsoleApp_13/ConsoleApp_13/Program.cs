using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_13
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Spravka[] spravkaDataBase = new Spravka[]
                                            {
                                                new Person("Попов", "г. Омск, 3-я ул. Белоконской, д. 4, кв. 70 ", "8 (900) 171-32-43"),
                                                new Person("Иванов", "г. Кострома, ул. Гагарина, д. 12, кв. 80 ", "89301628241"),
                                                new Organization("Кафе «Лосось и кофе»", "г. Владимир, ул. Большая Московская, д. 2", "+7 (4922) 45-17-05", 823052, "Денис Туркин"),
                                                new Organization("Кинотеатр «Киномакс Буревестник»", "г. Владимир, Проспект Ленина, д. 29", "+7 (4922) 40-00-04", 7527492, "Андрей Семенов"),
                                                new Friend("Заплаткин", "г. Владимир, ул. Горького, д.77, кв.22 ", "8 (915) 926-59-89", new DateTime(2004, 9, 9)),
                                                new Friend("Рябов", "г. Владимир, ул. Заречная, д.2, кв.34 ", "8 (906) 325-71-43", new DateTime(2004, 5, 1))
                                            };

            Console.WriteLine("Записив в телефонном справочнике:\n");

            Console.WriteLine("ПЕРСОНЫ:\n");
            foreach (var s in FindSurname1(spravkaDataBase, ""))
                s.PrintInfo();
            Console.WriteLine("ОРГАНИЗАЦИИ:\n");
            foreach (var s in FindSurname3(spravkaDataBase, ""))
                s.PrintInfo();
            Console.WriteLine("ДРУЗЬЯ:\n");
            foreach (var s in FindSurname2(spravkaDataBase, ""))
                s.PrintInfo();

            Console.Write("ПОИСК (введите фамилию): ");
            string familia = Console.ReadLine();

            Console.WriteLine("\nПЕРСОНЫ:\n");
            foreach (var s in FindSurname1(spravkaDataBase, familia))
                s.PrintInfo();
            Console.WriteLine("ОРГАНИЗАЦИИ:\n");
            foreach (var s in FindSurname3(spravkaDataBase, familia))
                s.PrintInfo();
            Console.WriteLine("ДРУЗЬЯ:\n");
            foreach (var s in FindSurname2(spravkaDataBase, familia))
                s.PrintInfo();

            Console.ReadLine();
        }
 
        private static IEnumerable<Person> FindSurname1(Spravka[] spravkaDataBase, string surnameSubstring)
        {
            foreach (var s in spravkaDataBase)
                if (s is Person)
                if ((s as Person).Surname.Contains(surnameSubstring))
                    yield return s as Person;
        }

        private static IEnumerable<Friend> FindSurname2(Spravka[] spravkaDataBase, string surnameSubstring)
        {
            foreach (var s in spravkaDataBase)
                if (s is Friend)
                    if ((s as Friend).Surname.Contains(surnameSubstring))
                        yield return s as Friend;
        }

        private static IEnumerable<Organization> FindSurname3(Spravka[] spravkaDataBase, string surnameSubstring)
        {
            foreach (var s in spravkaDataBase)
                if (s is Organization)
                    if ((s as Organization).Kontakt.Contains(surnameSubstring))
                        yield return s as Organization;
        }
    }
 
    public abstract class Spravka
    {
        public abstract void PrintInfo();
    }
 
    public class Person : Spravka
    {
        public string Surname { get; set; }
        public string Adres { get; set; }
        public string Telephone { get; set; }
 
        public Person(string surname, string adres, string telephone)
        {
            Surname = surname;
            Adres = adres;
            Telephone = telephone;
        }
 
        public override void PrintInfo()
        {
            Console.WriteLine("Фамилия: {0}", Surname);
            Console.WriteLine("Адрес: {0}", Adres);
            Console.WriteLine("Телефон: {0}\n", Telephone);
        }
    }
 
    public class Organization : Spravka
    {
        public string Name { get; set; }
        public string AdresOrg { get; set; }
        public string Number { get; set; }
        public int Faks { get; set; }
        public string Kontakt { get; set; }
 
 
 
        public Organization(string name, string adresOrg, string number, int faks, string kontakt)
        {
            Name = name;
            AdresOrg = adresOrg;
            Number = number;
            Faks = faks;
            Kontakt = kontakt;
        }
 
        public override void PrintInfo()
        {
            Console.WriteLine("Название организации: {0}", Name);
            Console.WriteLine("Адрес: {0}", AdresOrg);
            Console.WriteLine("Номер телефона: {0}", Number);
            Console.WriteLine("Факс: {0}", Faks);
            Console.WriteLine("Контактное лицо: {0}\n", Kontakt);
        }
    }
 
    public class Friend : Spravka
    {
        public string Surname { get; set; }
        public string Adres { get; set; }
        public string Telephone { get; set; }
        public DateTime BirthdayDate { get; set; }
 
        public Friend(string surname, string adres, string telephone, DateTime birthdayDate)
        {
            Surname = surname;
            Adres = adres;
            Telephone = telephone;
            BirthdayDate = birthdayDate;
        }
        public override void PrintInfo()
        {
            Console.WriteLine("Фамилия: {0}", Surname);
            Console.WriteLine("Адрес: {0}", Adres);
            Console.WriteLine("Телефон: {0}", Telephone);
            Console.WriteLine("День рождения: {0}\n", BirthdayDate.ToLongDateString());
        }
    }
}
