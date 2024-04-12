using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples.LiskovSubstitutionPrinciple
{
    #region LSP'ye uymayan örnek

    //IDataSource interface hem veri çekme hem kaydetme pointer'ı bulunduruyor.
    //Bu interface'in implemente edildiği tüm class'lar bu pointer'ları kullanmak zorunda ancak ileride eklenecek ve bu interface implemente edilecek bir class
    //Save işlemi yapmayacak olursa mecburen bu class'ın Save methodunun try catch ile veya başka bir şekilde kontrol edilmesi gerekiyor.
    //Bu durum LSP'ye aykırı. Üst sınıfı ya da interface'i kullanan tüm alt sınıflar imlepemente edilen interface'in tüm pointer'larını kullanmalıdır. 
    /*
    public interface IDataSource
    {
        void GetAllData();
        void Save();
    }

    public class DbSource : IDataSource
    {
        public void GetAllData()
        {
            //Tüm dataların alındığı method
        }

        public void Save()
        {
            //Tüm dataların kaydedildiği method
        }
    }

    public class XmlSource : IDataSource
    {
        public void GetAllData()
        {
            //Tüm dataların alındığı method
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
    */
    #endregion

    //İki ayrı interface yapıldığında yukarıdaki LSP'ye uymayan durum ortadan kalkmış oldu. 
    //Bu şekilde XmlSource class'ına içi boş bir Save methodu eklemek zorunda kalınmadı ve ekstra bir try catch ya da başka bir kontrole ihtiyaç kalmadı.
    //LSP bunu söylüyor. Ana kod'da sınıfa özel bir hata kontrolü istisna olmamalı.
    public interface IDataSource
    {
        void GetAllData();
    }

    public interface IRecordable
    {
        void Save();
    }

    public class DbSource : IDataSource, IRecordable
    {
        public void GetAllData()
        {
            //Tüm dataların alındığı method
        }

        public void Save()
        {
            //Tüm dataların kaydedildiği method
        }
    }

    public class XmlSource : IDataSource
    {
        public void GetAllData()
        {
            //Tüm dataların alındığı method
        }
    }
}
