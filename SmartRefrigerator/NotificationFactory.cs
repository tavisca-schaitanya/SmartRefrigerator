namespace SmartRefrigerator
{
    public class NotificationFactory
    {
        public INotifier GetNotifier(string notifierType)
        {
            switch (notifierType.ToLower())
            {
                case "refrigerator":
                    return new RefrigeratorNotifier();

                case "mobile":
                    return new MobileNotifier();

                case "email":
                    return new EmailNotifier();

                default:
                    break;
            }
            return null;
        }
    }

}
