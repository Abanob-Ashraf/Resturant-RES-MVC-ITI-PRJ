using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Resturant_RES_MVC_ITI_PRJ.Services
{
    public interface IEmailSender
    {
        void SendEmail(Message message);
        Task SendEmailAsync(Message message);
    }
}
