using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples.OpenClosedPrinciple
{

    #region OCP'ye uymayan örnek.
    //Bu örnek OCP'ye uymayan örnektir.

    /*
    public enum CustomerType
    {
        Regular,
        Premium,
        Newbie
    }
    public class DiscountCalculator
    {
        //CalculateDiscount metodunda kullanılan switch case yapısı şu an için yeterli olsa da ileriki bir tarihte farklı bir kullanıcı tipi sisteme dahil edildiğinde
        //bu classın değiştirilmesini zorunlu kılıyor. Bu sebeple bu class OCP'ye uygun bir class değil.
        public double CalculateDiscount(double price, CustomerType customerType)
        {
            switch (customerType)
            {
                case CustomerType.Regular:
                    return price * 0.1;  // Regular müşteriler için %10 indirim
                case CustomerType.Premium:
                    return price * 0.3;  // Premium müşteriler için %30 indirim
                case CustomerType.Newbie:
                    return price * 0.05; // Yeni müşteriler için %5 indirim
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
    */
    #endregion

    //OCP'ye uyması için önce ana bir interface oluşturuldu. Tüm indirim class'larına bu interface implemente edilecek.
    public interface IDiscountStrategy
    {
        double CalculateDiscount(double price);
    }
    //Her indirim tipi için bu interface implemente ediliyor. Böylece ileride yeni bir indirim tipi geldiğinde DiscountCalculator class'ında herhangi bir değişiklik 
    //yapılmasına gerek kalmadan yeni gelen indirim tipi için bir class oluşturulup interface implemente edilecek ve kod yapısında herhangi bir değişiklik olmayacak.
    public class RegularDiscount : IDiscountStrategy
    {
        public double CalculateDiscount(double price)
        {
            return price * 0.1;
        }
    }
    public class PremiumDiscount : IDiscountStrategy
    {
        public double CalculateDiscount(double price)
        {
            return price * 0.3;
        }
    }
    public class NewbieDiscount : IDiscountStrategy
    {
        public double CalculateDiscount(double price)
        {
            return price * 0.05;
        }
    }
    //DiscountCalculator class'ının constructor'ına hangi indirip tipi için hesaplanacağı gönderilecek ve o indirim tipi için indirim hesaplanacak. 
    //DiscountCalculator class'ı IDiscountStrategy beklediği için IDiscountStrategy'nin implemente edildiği tüm class'lar DiscountCalculator'a gönderilebilir.
    //Bu şekilde ileride ne kadar indirim tipi eklenirse eklensin DiscountCalculator için hiçbir değişiklik yapmaya gerek kalmayacak yani değişikliğe kapalı olmuş olacak.
    public class DiscountCalculator
    {
        private readonly IDiscountStrategy _discountStrategy;
        public DiscountCalculator(IDiscountStrategy discountStrategy)
        {
            _discountStrategy = discountStrategy;
        }
        public double CalculateDiscount(double price)
        {
            return _discountStrategy.CalculateDiscount(price);
        }
    }
}
