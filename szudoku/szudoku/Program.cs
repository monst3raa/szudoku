using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace szudoku
{
    class Feladvany
    {
        public string Kezdo { get; private set; }
        public int Meret { get; private set; }

        public Feladvany(string sor)
        {
            Kezdo = sor;
            Meret = Convert.ToInt32(Math.Sqrt(sor.Length));
        }

        public void Kirajzol()
        {
            for (int i = 0; i < Kezdo.Length; i++)
            {
                if (Kezdo[i] == '0')
                {
                    Console.Write(".");
                }
                else
                {
                    Console.Write(Kezdo[i]);
                }
                if (i % Meret == Meret - 1)
                {
                    Console.WriteLine();
                }
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                
                List<Feladvany> feladvanyok = new List<Feladvany>();
                foreach (string Seged in File.ReadAllLines("feladvanyok.txt"))
                {
                    feladvanyok.Add(new Feladvany(Seged));
                }
                Console.WriteLine("3. feladat: {0} feladvány", feladvanyok.Count);

                int meret;
                do
                {
                    Console.Write("\n4. feladat: Kérem a méretét [4..9]: ");
                    meret = Convert.ToInt32(Console.ReadLine());
                } while (meret < 4 || meret > 9);
                int meretDb = 0;
                foreach (var Seged in feladvanyok)
                {
                    if (Seged.Meret == meret)
                    {
                        meretDb++;
                    }
                }
                Console.WriteLine("{0}x{0} méretű feladványból {1} darab van tárolva", meret, meretDb);



            }
        }
    }
}
