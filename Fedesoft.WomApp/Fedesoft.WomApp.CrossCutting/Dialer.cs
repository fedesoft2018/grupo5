using Plugin.Messaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fedesoft.WomApp.CrossCutting
{
    public static class Dialer
    {
        public static void MakeCall(string number)
        {
            var phoneDialer = CrossMessaging.Current.PhoneDialer;
            if (phoneDialer.CanMakePhoneCall)
            {
                phoneDialer.MakePhoneCall(number);
            }
        }
    }
}
