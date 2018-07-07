//-----------------------------------------------------------------------
// <copyright file="Dialer.cs" company="Fedesoft">
//     Copyright (c) Fedesoft. All rights reserved.
// </copyright>
// <author>Ricardo Linares Correa</author>
//-----------------------------------------------------------------------

namespace Fedesoft.WomApp.CrossCutting
{
    using Plugin.Messaging;

    /// <summary>
    /// Defines the <see cref="Dialer" />
    /// </summary>
    public static class Dialer
    {
        /// <summary>
        /// Makes the call.
        /// </summary>
        /// <param name="number">The number.</param>
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
