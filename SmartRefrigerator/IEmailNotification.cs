using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRefrigerator
{
    public interface IEmailNotification: INotifier
    {
        string Subject { get; }
    }
}
