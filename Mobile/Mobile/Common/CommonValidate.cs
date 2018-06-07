using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace Mobile.Common
{
    public class CommonValidate
    {
        public static bool IsValidEmail(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
