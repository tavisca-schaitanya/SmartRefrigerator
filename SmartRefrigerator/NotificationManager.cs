namespace SmartRefrigerator
{
    public class NotificationManager
    {
        INotifier _notifier;
        public NotificationManager(INotifier notifier)
        {
            _notifier = notifier;
        }

        public string SendNotification()
        {
            return _notifier.SendNotification();
        }
    }

}
