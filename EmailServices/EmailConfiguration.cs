using System;
using System.Collections.Generic;
using System.Text;

namespace Resturant_RES_MVC_ITI_PRJ.Services
{
    public class EmailConfiguration
    {
        public string From { get; set; }
        public string SmtpServer { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
