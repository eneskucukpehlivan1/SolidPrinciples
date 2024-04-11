using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples.SingleResponsibilityPrinciple
{
    public interface ILogger
    {
        void Info(string info);
        void Debug(string info);
        void Error(string message, Exception ex);
    }
    public class Logger : ILogger
    {
        public Logger()
        {
            //Init için gerekli kodlar
        }
        public void Info(string info)
        {
            //Info loglarının ErrorLog dosyasına yazması için gerekli kodlar
        }
        public void Debug(string info)
        {
            //Debug loglarının ErrorLog dosyasına yazması için gerekli kodlar
        }
        public void Error(string message, Exception ex)
        {
            //Error loglarının ErrorLog dosyasına yazması için gerekli kodlar
        }
    }
}
