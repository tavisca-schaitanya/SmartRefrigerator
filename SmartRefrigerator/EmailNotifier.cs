using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRefrigerator
{
    class EmailNotifier : IEmailNotification
    {
        public string Subject => "Insufficient Items in your refrigerator";

        public string SendNotification()
        {
            return "Sent notification to mail. " + Subject;
        }
    }
}
