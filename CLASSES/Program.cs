using System;

namespace CLASSES
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 1;
            while (a != 0)
            {
                try
                {
                    Console.WriteLine("Кто-то приложил пропуск к турникету! Представьтесь:");
                    Console.WriteLine("1 - старший Go-разработчик\n2 - менеджер по продажам\n3 - постоянный клиент\n4 - новый клиент\n0 - выйти из здания (выход из программы)\n");
                    a = int.Parse(Console.ReadLine());

                    if (a < 0 || a > 4) { Console.WriteLine("\nТакого варианта нет! Попробуйте ещё раз!\n"); }
                    switch (a)
                    {
                        case 0: break;
                        case 1: Visitor visitor_1 = new Employee(101010, "старший Go-разработчик"); visitor_1.Show(); break;
                        case 2: Visitor visitor_2 = new Employee(101111, "менеджер по продажам"); visitor_2.Show(); break;
                        case 3: Visitor visitor_3 = new Client("многоразовый", "+7 (925) 173-64-09", 4412); visitor_3.Show(); break;
                        case 4: Visitor visitor_4 = new Client("одноразовый", "+7 (977) 654-04-23", 2308); visitor_4.Show(); break;
                    }
                }
                catch (Exception) { Console.WriteLine("\nТакого варианта нет! Попробуйте ещё раз.\n"); }
                Console.WriteLine("Нажмите любую клавишу, чтобы продолжить ");
                Console.ReadKey();
                Console.Clear();
            }
        }

        abstract class Visitor
        {
            public abstract string Type();
            public abstract string Access();
            public string Time()
            {
                return DateTime.Now.ToString();
            }
            public abstract void Show();
        }

        class Employee : Visitor
        {
            int id;
            string position;
            public Employee(int id, string position)
            {
                this.id = id;
                this.position = position;
            }
            public override string Access()
            {
                return "постоянный";
            }

            public override string Type()
            {
                return "работник";
            }

            public override void Show()
            {
                Console.WriteLine($"\nТип посетителя: {Type()}\nВремя посещения: {Time()}\nТип доступа: {Access()}\nДолжность: {Position()}\nID работника: {Id()}\n");
            }

            public int Id()
            {
                return id;
            }

            public string Position()
            {
                return position;
            }
        }

        class Client : Visitor
        {
            string number;
            string pass;
            int meetingRoom;

            public Client(string pass, string number, int meetingRoom)
            {
                this.pass = pass;
                this.number = number;
                this.meetingRoom = meetingRoom;
            }

            public override string Access()
            {
                return pass;
            }

            public override void Show()
            {
                Console.WriteLine($"\nТип посетителя: {Type()}\nВремя посещения: {Time()}\nТип доступа: {Access()}\nКонтактный номер: {PhoneNumber()}\nНомер гостевой комнаты: {MeetingRoom()}\n");
            }

            public override string Type()
            {
                return "клиент";
            }

            public string PhoneNumber()
            {
                return number;
            }

            public int MeetingRoom()
            {
                return meetingRoom;
            }
        }
    }
}