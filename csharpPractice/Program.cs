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

        static void Main()
        {
            Menu menu = new Menu();
            menu.Start();
        }

        public class Menu
        {
            public void ShowMenu() // 메뉴창 출력
            {
                Console.WriteLine("");
                Console.WriteLine("---------");
                Console.WriteLine("1. Show List");
                Console.WriteLine("2. Add");
                Console.WriteLine("3. Delete");
                Console.WriteLine("4. Update");
                Console.WriteLine("5. Exit");
                Console.WriteLine("---------");
                Console.Write("Input>> ");
            }

            public void Start()
            {
                bool done = true;
                DoLogic doLogic = new DoLogic();
                while (done)
                {
                    ShowMenu();
                    switch (Console.ReadLine())
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
                            doLogic.Update();
                            break;
                        case "5":
                            done = false;
                            break;
                        default:
                            Console.WriteLine("please input again");
                            break;
                    }
                    Console.WriteLine("");
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
                Console.Write("Find Name: ");
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

            public void Update()
            {
                Console.Write("Find Name: ");
                string name = Console.ReadLine();

                bool isThere = false;

                for (int ii = 0; ii < info.Count; ii++)
                {
                    if (info[ii].Name == name)
                    {
                        Console.Write("Update Name: ");
                        info[ii].Name = Console.ReadLine();

                        Console.Write("Update Number: ");
                        info[ii].Number = Console.ReadLine();

                        isThere = true;
                    }
                }

                if (isThere)
                {
                    Console.WriteLine("----------------");
                    Console.WriteLine("Update Complete.");
                }
                else
                {
                    Console.WriteLine("No name.");
                }
            }
        }
    }
}