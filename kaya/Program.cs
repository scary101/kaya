using System.IO;
using System.Xml.Linq;

namespace kaya
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int finaly = 0;
            List< string> maintort = new List<string>() {"  1. Форма коржей", "  2.Цвет коржей", "  3.Вкус начинки", "  4.Декор", "  5.Цвет гллазури", "  Завершить заказ"};
            List<Tort> doptort = new List<Tort>();
            Tort forma = new Tort();
            forma.name.Add("  1.Круглая");
            forma.name.Add("  2.Квадратная");
            forma.name.Add("  3.Треугольная");
            forma.coast.Add(200);
            forma.coast.Add(150);
            forma.coast.Add(250);
            doptort.Add(forma);
            
            Tort colour = new Tort();
            colour.name.Add("  1.Белый");
            colour.name.Add("  2.Красный");
            colour.name.Add("  3.Серо-буро-малиновый");
            colour.coast.Add(100);
            colour.coast.Add(150);
            colour.coast.Add(1000);
            doptort.Add(colour);

            Tort vkus = new Tort();
            vkus.name.Add("  1.Банан-клубника");
            vkus.name.Add("  2.Карамельный БУМ");
            vkus.name.Add("  3.Радуга вкусов");
            vkus.coast.Add(450);
            vkus.coast.Add(300);
            vkus.coast.Add(600);
            doptort.Add(vkus);

            Tort decor = new Tort();
            decor.name.Add("  1.DOTA 2");
            decor.name.Add("  2.Brawl Stars");
            decor.name.Add("  3.Однотон");
            decor.coast.Add(10000);
            decor.coast.Add(15000);
            decor.coast.Add(250);
            doptort.Add(decor);

            Tort colourCream = new Tort();
            colourCream.name.Add("  1.Белый");
            colourCream.name.Add("  2.Синий");
            colourCream.name.Add("  3.Красный");
            colourCream.coast.Add(250);
            colourCream.coast.Add(320);
            colourCream.coast.Add(99);
            doptort.Add(colourCream);





            ConsoleKeyInfo key;
            KeyPos belka = new KeyPos();
            Zakaz ready = new Zakaz();
            List<string> gotovo = new List<string>();
            string cena;
            bool end = true;
            while (end != false)
            {
                Menu.MainMenu(maintort,finaly, gotovo);
                key = Console.ReadKey();
                belka = Strelka.arrow(key, maintort, 0, end);
                end = belka.end;

                key = belka.key;
                int poz = belka.poz - 1;
                ready = Zakaz.zakaz(key, doptort, poz, finaly, maintort);
                finaly = ready.finaly;
                cena = Convert.ToString(ready.cena);
                ready.gotovo = ready.gotovo[4..];
                ready.gotovo = ready.gotovo + " - " + cena + ",  ";
                gotovo.Add(ready.gotovo);

            }
            Zakaz.Save(gotovo, finaly);

        }
    }
}