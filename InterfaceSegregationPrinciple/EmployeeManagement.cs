using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples.InterfaceSegregationPrinciple
{
    #region ISP'ye uymayan örnek
    //ISP'ye aykırı olan durum implemente edilen interface'te bulunan pointer'ların implemente edildiği sınıfın ihtiyacı olmadığı için dummy code şeklinde o sınıfta bulunmasıdır.
    //Class'lar içerisinde dummy code bulunmamalıdır.
    /*
    public interface IEmployee
    {
        void Eat();
        void Work();
        void Hire();
    }
    public class Manager : IEmployee
    {
        public void Eat()
        {
            //Müdür yemek yer
        }

        public void Work()
        {
            //Müdür çalışır
        }

        public void Hire()
        {
            //Müdür işe eleman alır
        }
    }

    public class Worker : IEmployee
    {
        public void Eat()
        {
            //Çalışan yemek yer
        }

        public void Work()
        {
            //Çalışan çalışır
        }

        public void Hire()
        {
            //Çalışan işe eleman alamaz bu sebeple burda dummy code bulunur
            throw new NotImplementedException();
        }
    }

    public class Robot : IEmployee
    {
        public void Eat()
        {
            //Robot yemek yemez
            throw new NotImplementedException();
        }

        public void Work()
        {
            //Robot çalışır
        }

        public void Hire()
        {
            //Robot işe eleman alamaz
            throw new NotImplementedException();
        }
    }
    */
    #endregion

    //Bu şekilde ilgili metodları farklı interface'lere alıp implemente edilecek olan sınıfın ihtiyaçlarına göre interface'leri implemente ederek dummy code kullanımının
    //veya NotImplementedException throw edilmesinin önüne geçilmiş oldu.
    public interface IEat
    {
        void Eat();
    }
    public interface IWork
    {
        void Work();
    }
    public interface IHire
    {
        void Hire();
    }
    public class Manager : IEat, IWork, IHire
    {
        public void Eat()
        {
            //Müdür yemek yer
        }

        public void Work()
        {
            //Müdür çalışır
        }

        public void Hire()
        {
            //Müdür işe eleman alır
        }
    }

    public class Worker : IEat, IWork
    {
        public void Eat()
        {
            //Çalışan yemek yer
        }

        public void Work()
        {
            //Çalışan çalışır
        }
    }

    public class Robot : IWork
    {
        public void Work()
        {
            //Robot çalışır
        }
    }
}
