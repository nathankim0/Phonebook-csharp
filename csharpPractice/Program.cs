using System;
using System.Collections.Generic;

namespace Phonebook
{
    public class Program
    {
        public class Info
        {
            public string Name { get; set; }
            public string Number { get; set; }
        }
        public class Menu
        {
            public Menu()
            {
            }
            public void ShowMenu()
            {
                Console.WriteLine("---------");
                Console.WriteLine("1. Show List");
                Console.WriteLine("2. Add");
                Console.WriteLine("3. Delete");
                Console.WriteLine("4. Exit");
                Console.WriteLine("---------");
                Console.Write("Input>> ");

            }
            public string Input()
            {
                return Console.ReadLine();

            }
            public void StartLoop()
            {
                bool done = true;
                DoLogic doLogic = new DoLogic();
                while (done)
                {
                    ShowMenu();
                    switch (Input())
                    {
                        case "1":
                            doLogic.ShowList();
                            break;
                        case "2":
                            doLogic.Add();
                            break;
                        case "3":
                            doLogic.Delete();
                            break;
                        case "4":
                            done = false;
                            break;
                        default:
                            Console.WriteLine("please input again");
                            break;
                    }
                }
            }

        }
        public class DoLogic
        {
            private List<Info> info = new List<Info>();

            public void ShowList()
            {
                foreach (Info i in info)
                {
                    Console.WriteLine($"Name : {i.Name}, Number : {i.Number} \n");
                }
            }
            public void Add()
            {
                Info i = new Info();

                Console.Write("Input Name: ");
                i.Name = Console.ReadLine();

                Console.Write("Input Number: ");
                i.Number = Console.ReadLine();

                info.Add(i);
            }
            public void Delete()
            {
                Console.Write("Input Name: ");
                string name = Console.ReadLine();

                bool isThere = false;

                // 오류 코드
                /*
                foreach(Info i in info)
                {
                    if (i.Name == name)
                    {
                        info.Remove(i);
                        isThere = true;
                    }
                }
                */
               
                for (int ii = 0; ii < info.Count; ii++)
                {
                    if (info[ii].Name == name)
                    {
                        info.RemoveAt(ii);
                        isThere = true;
                    }
                }

                // 이런 방법도 있다.
                /* info.RemoveAll(x => x.Name == name); */

                if (isThere)
                {
                    Console.WriteLine("Delete Complete.");
                }
                else
                {
                    Console.WriteLine("No name.");
                }
            }
        }


        static void Main()
        {
            Menu menu = new Menu();
            menu.StartLoop();
        }
    }
}