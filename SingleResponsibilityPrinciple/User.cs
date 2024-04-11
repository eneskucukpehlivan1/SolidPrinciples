using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples.SingleResponsibilityPrinciple
{
    public class User
    {
        public string userName { get; set; }
        public string password { get; set; }
        public string eMail { get; set; }

        private ILogger fileLogger;
        private MailSender emailSender;
        public User()
        {
            //User sınıfına tek bir sorumluluk verilmesi için log alma ve mail gönderme işlemleri başka bir class'ta yapılıyor
            fileLogger = new Logger();
            emailSender = new MailSender();
        }
        public void SignUp()
        {
            try
            {
                //Log işlemleri Logger sınıfı üzerinden yapılıyor. Log alınan dosya ve/veya log alma türü değişse bile User sınıfı bu değişiklikten etkilenmeyecek.
                fileLogger.Info("User kayıt olma işlemi başladı.");


                //Kullanıcı kayıt işlemleri bu kısımda yapılacak
                //Kullanıcıya Onay maili gönderilecek

                /*
                //User sınıfı sadece User ile ilgili işlemleri yapmalı User sınıfının Email ayarlamaları yapmamalı
                //Single Responsibility prensibine uymayan bölüm:
                MailMessage mailMessage = new MailMessage("EMailFrom", "EMailTo", "EMailSubject", "EMailBody");
                this.SendRegistirationMail(mailMessage);
                */

                //Mail gönderme işlemi MailSender class'ı üzerinden yapılıyor. Böylece mail ayarlarında herhangi bir şey değiştiğinde User sınıfı bu değişiklikten etkilenmeyecek.
                emailSender.EMailFrom = "emailfrom@xyz.com";
                emailSender.EMailTo = "emailto@xyz.com";
                emailSender.EMailSubject = "Single Responsibility Principle";
                emailSender.EMailBody = "Bir sınıfın değişmek için tek bir nedeni olmalıdır.";
                emailSender.SendEmail();
            }
            catch (Exception ex)
            {
                fileLogger.Error("Kullanıcı kayıt olma işlemi sırasında bir hata oluştu.", ex);

                //Hata kayıt logu User sınıfı içerisinde özelleştirilmemeli
                //Single Responsibility prensibine uymayan bölüm:
                //System.IO.File.WriteAllText(@"c:\ErrorLog.txt", ex.ToString());
            }
        }
        public void SignIn()
        {
            try
            {
                fileLogger.Info("Kullanıcı girişi oldu. Tarih: " + DateTime.Now);
                //Kayıtlı kullanıcı giriş işlemleri
            }
            catch (Exception ex)
            {
                fileLogger.Error("Kullanıcı girişi sırasında bir hata oluştu.", ex);

                //Hata kayıt logu User sınıfı içerisinde özelleştirilmemeli
                //Single Responsibility prensibine uymayan bölüm:
                //System.IO.File.WriteAllText(@"c:\ErrorLog.txt", ex.ToString());
            }
        }

        //User sınıfı içerisinde Mail için ayarlamalar yapıyor olsak bu Single Responsibility prensibine uyumlu olmazdı.
        //Single Responsibility prensibine uymayan metod:
        /*
        public void SendRegistirationMail(MailMessage mailMessage)
        {
            try
            {
                //Kayıt maili göndermek için yapılacak işlemler
            }
            catch (Exception ex)
            {
                //Hata kayıt logu User sınıfı içerisinde özelleştirilmemeli
                System.IO.File.WriteAllText(@"c:\ErrorLog.txt", ex.ToString());
            }
        }
        */
    }
}
