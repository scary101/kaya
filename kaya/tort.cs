using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;

namespace kaya
{
    internal class Tort
    {
        public List<string> name = new List<string>();
        public List<int> coast = new List<int>();  
    }
    
    static class Strelka
    {
        private static int  poz = 1;
        public static KeyPos arrow(ConsoleKeyInfo key, List<string> main,  int min, bool end)
        {
            int max = main.Count() + 1;

            while (key.Key != ConsoleKey.Enter)
            {
                Console.SetCursorPosition(0, poz);
                Console.WriteLine("  ");
                if (key.Key == ConsoleKey.UpArrow)
                {
                    poz--;
                    if (poz <= min)
                    {
                        poz = max - 1;
                    }
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    poz++;
                    if (poz >= max)
                    {
                        poz = min + 1;
                    }

                }

                Console.SetCursorPosition(0, poz);
                Console.WriteLine("->");
                key = Console.ReadKey();
                if (key.Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    end = false;
                }

            }
            return new KeyPos { poz = poz, key = key, end = end };
        }
    }

    class Zakaz
    {
        public int finaly;
        public string gotovo;
        public int cena;
        
        public static Zakaz zakaz(ConsoleKeyInfo key, List<Tort> dop, int poz1, int finalyCoast, List<string> main)
        {
            bool a = true;
            Console.Clear();
            Menu.DopMenu(dop, poz1, main);
            KeyPos belka = new KeyPos();
            int poz = 0;
            while (belka.key.Key != ConsoleKey.Enter )
            {
                key = Console.ReadKey(); 
                belka = Strelka.arrow(key, dop[poz1].name, 0, a);
                key = belka.key;
                poz = belka.poz;
            }

            belka = Strelka.arrow(key, dop[poz1].name, 0, a);
            if (key.Key == ConsoleKey.Enter) { finalyCoast = finalyCoast + dop[poz1].coast[poz - 1]; }

            return new Zakaz { finaly = finalyCoast, gotovo = dop[poz1].name[poz - 1], cena = dop[poz1].coast[poz - 1] };

        }
        public static void Save(List<string> a, int b)
        {
            DateTime now = DateTime.Now;
            string time = Convert.ToString(now);
            string txt ="\n"+"\nЗаказ от: " + time +  "\nВаш заказ состоит из: " + string.Join(" ", a.ToArray()) + "\nИтоговая цена: " + Convert.ToString(b);
            File.AppendAllText("C:\\Users\\user\\Desktop\\Заказы\\Заказ.txt", txt);
        }

    }
    class Menu
    {
        public static void MainMenu(List<string> a, int finalyCoast, List<string> name)
        {
            Console.Clear();
            Console.WriteLine("Добро пожаловать в мою ПЕКАРНЮ!!! Заходи, не стесняйся");
            foreach (string s in a)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine("  " + finalyCoast);
            string concat = string.Join(" ", name.ToArray());
            Console.WriteLine("Ваш заказ:" + concat);
        }
        public static void DopMenu(List<Tort> a, int poz, List <string> main)
        {
            Console.WriteLine(main[poz] + ":");
            for (int i = 0; i < a[poz].coast.Count; i++)
            {
                Console.WriteLine(a[poz].name[i] + "  -  " + a[poz].coast[i]);
            }
        }
    }
    class KeyPos
    {
        public int poz;
        public ConsoleKeyInfo key;
        public bool end;
    }
}
