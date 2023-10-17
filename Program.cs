using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace pekseg
{
    interface IArlap
    {
        double Mennyibekerul();
    }
    abstract class Peksutemeny: IArlap
    {
        private double alapAr;
        protected double mennyiseg;

        public Peksutemeny(double alapAr, double mennyiseg)
        {
            this.alapAr = alapAr;
            this.mennyiseg = mennyiseg;
        }
        public abstract void megkostol();

        public double Mennyibekerul()
        {
            return alapAr * mennyiseg;
        }
        public override string ToString()
        {
            return $"{mennyiseg} db - {Mennyibekerul()}";
        }
    }
    class Pogacsa : Peksutemeny
    {
        public Pogacsa(double alapAr, double mennyiseg) : base(alapAr, mennyiseg)
        {
        }

        public override void megkostol()
        {
            mennyiseg /= 2;
        }
        public override string ToString()
        {
            return $"Pogácsa"+base.ToString();
        }
    }
    class Kave : IArlap
    {
        private bool habosE;
        const int cseszekave = 180;
        public Kave(bool habosE)
        {
            this.habosE = habosE;
        }

        public double Mennyibekerul()
        {
            if (habosE)
            {
                return cseszekave * 1.5;
            }
            return cseszekave;
        }

        public override string ToString()
        {
            return $"{( habosE ? "Habos" : "Nem habos")}Kávé ára: {Mennyibekerul()}";
        }
    }

    internal class Program
    {
        static List<IArlap> arlap = new List<IArlap>();
        static void vasarlok(string path)
        {
            StreamReader sr=new StreamReader(path);
            while (!sr.EndOfStream)
            {
                string[] temp = sr.ReadLine().Split(' ');
                if (temp[0]=="Pogacsa")
                {
                    arlap.Add(new Pogacsa(double.Parse(temp[1]), double.Parse(temp[1])));
                }
                else
                {
                    arlap.Add(new Kave(temp[1]=="Habos"));
                }
            }
            sr.Close();
        }
        static void Main(string[] args)
        {
            vasarlok(@"C:\programozas\asztalialkalmazasok\pekseg\pekseg\pekseg\bin\Debug\Pekseg.txt");
            Console.ReadLine();
        }
    }
}
