using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples.DependencyInversionPrinciple
{
    #region DIP'ye uymayan örnek
    //Ödeme servisinin ödeme yapma metodunda direkt Manager class'ı beklendiği için ileride sadece Manager'a değil Worker'a da ödeme yapılacak olsa sistemin değişmesi gerekiyor.
    //Bu şekilde Payment Service class'ı Manager class'ına bağımlı hale gelmiş oluyor.
    //Yani yüksek modül olan PaymentService daha düşük modül olan Manager'a bağımlı halde.
    /*
    public class Manager
    {
        public void GetPay()
        {
            //Ödeme alma metodu
        }
    }
    public class PaymentService
    {
        public void Pay(Manager manager)
        {
            manager.GetPay();
        }
    }
    */
    #endregion

    //Bu kullanımda yüksek modül olan PaymentService herhangi bir düşük modüle bağımlı halde değil. 
    //PaymentService'in Pay methodu çağırılırken hangi class olduğundan bağımsız bir şekilde IWorker'ın implemente edildiği herhangi bir class gönderilebilir.
    public interface IWorker
    {
        void GetPay();
    }
    public class Manager : IWorker
    {
        public void GetPay()
        {
            //Manager için ödeme alma metodu
        }
    }

    public class Worker : IWorker
    {
        public void GetPay()
        {
            //Çalışan için ödeme alma metodu
        }
    }
    public class PaymentService
    {
        public void Pay(IWorker worker)
        {
            worker.GetPay();
        }
    }
}
