using SmartRefrigerator;
using System.Collections.Generic;

namespace SmartRefrigerator
{
    public class Refrigerator
    {
        private VegetableTray _vegetableTray = new VegetableTray();

        private ConfigurationManager _configurationManager;

        private NotificationManager _notificationManager;

        private VegetableTracker _vegetableTracker;

        private StorageFactory _storageFactory;

        private NotificationFactory _notificationFactory;

        public Refrigerator()
        {
            _storageFactory = new StorageFactory();
            _notificationFactory = new NotificationFactory();
            _notificationManager = new NotificationManager(_notificationFactory.GetNotifier("refrigerator"));
            _configurationManager = new ConfigurationManager(_storageFactory.GetStorage("InMemory"));
            _vegetableTracker = new VegetableTracker(_vegetableTray, _configurationManager);
        }
        public void AddVegetable(Vegetable vegetable, int quantity)
        {
            _vegetableTray.Add(vegetable, quantity);
        }

        public void TakeOutVegetable(Vegetable vegetable, int quantity)
        {
            _vegetableTray.TakeOut(vegetable, quantity);
        }


        public List<KeyValuePair<Vegetable, int>> GetVegetableQuantity()
        {
            return _vegetableTray.GetVegetableQuantity();
        }


        public void SetMinimumQuantity(Vegetable vegetable, int quantity)
        {
            _configurationManager.SetMinimumQuantity(vegetable, quantity);
        }


        public int GetMinimumQuantity(Vegetable vegetable)
        {
            return _configurationManager.GetMinimumQuantity(vegetable);
        }


        public List<KeyValuePair<Vegetable, int>> GetAllInsufficientVegetables()
        {
            return _vegetableTracker.GetInsufficientVegetableQuantity();
        }


        public string SendNotification()
        {
            if(GetAllInsufficientVegetables().Count != 0)
            {
                return _notificationManager.SendNotification();
            }

            return "All items are sufficient";
        }


    }

}
