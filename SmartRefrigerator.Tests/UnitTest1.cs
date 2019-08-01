using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SmartRefrigerator.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void TestInMemoryStorage()
        {
            StorageFactory storageFactory = new StorageFactory();
            ConfigurationManager configurationManager = new ConfigurationManager(storageFactory.GetStorage("inmemory"));
            Tomato tomato = new Tomato();
            configurationManager.SetMinimumQuantity(tomato, 8);

            Assert.Equal(configurationManager.GetMinimumQuantity(tomato), 8);
        }

        
        public void TestFileBasedMemory()
        {
            StorageFactory storageFactory = new StorageFactory();
            ConfigurationManager configurationManager = new ConfigurationManager(storageFactory.GetStorage("filebased"));
            Tomato tomato = new Tomato();
            configurationManager.SetMinimumQuantity(tomato, 8);

            Assert.Equal(configurationManager.GetMinimumQuantity(tomato), 8);
        }


        [Fact]
        public void TestVegetableQuantity()
        {
            Refrigerator refrigerator = new Refrigerator();
            Cabbage cabbage = new Cabbage();
            Tomato tomato = new Tomato();

            refrigerator.AddVegetable(cabbage, 10);
            refrigerator.AddVegetable(tomato, 20);

            var expectedVegetableQuantity = new List<KeyValuePair<Vegetable, int>>();
            expectedVegetableQuantity.Add(new KeyValuePair<Vegetable, int>(cabbage, 10));
            expectedVegetableQuantity.Add(new KeyValuePair<Vegetable, int>(tomato, 20));
            var actualVegetableQuantity = refrigerator.GetVegetableQuantity();

            Assert.Equal(expectedVegetableQuantity.OrderBy(x => x.Key.Name).ToList(), actualVegetableQuantity.OrderBy(x => x.Key.Name).ToList());
        }


        [Fact]
        public void TestInsufficientVegetableQuantity()
        {
            Refrigerator refrigerator = new Refrigerator();
            Tomato tomato = new Tomato();

            refrigerator.AddVegetable(tomato, 20);
            refrigerator.SetMinimumQuantity(tomato, 8);
            refrigerator.TakeOutVegetable(tomato, 15);

            var expectedInsufficientVegetableQuantity = new List<KeyValuePair<Vegetable, int>>();
            expectedInsufficientVegetableQuantity.Add(new KeyValuePair<Vegetable, int>(tomato, 3));
            var actualInsufficientVegetableQuantity = refrigerator.GetAllInsufficientVegetables();

            Assert.Equal(expectedInsufficientVegetableQuantity.OrderBy(x => x.Key.Name), actualInsufficientVegetableQuantity.OrderBy(x => x.Key.Name));
        }


        [Fact]
        public void TestSufficiencyNotification()
        {
            Refrigerator refrigerator = new Refrigerator();
            Tomato tomato = new Tomato();

            refrigerator.AddVegetable(tomato, 20);
            refrigerator.SetMinimumQuantity(tomato, 8);
            refrigerator.TakeOutVegetable(tomato, 10);

            Assert.Equal("All items are sufficient", refrigerator.SendNotification());
        }


        [Fact]
        public void TestInsufficiencyNotification()
        {
            Refrigerator refrigerator = new Refrigerator();
            Tomato tomato = new Tomato();

            refrigerator.AddVegetable(tomato, 20);
            refrigerator.SetMinimumQuantity(tomato, 8);
            refrigerator.TakeOutVegetable(tomato, 15);

            Assert.Equal("Sent notification to refrigerator", refrigerator.SendNotification());
        }


        [Fact]
        public void TestMobileNotification()
        {
            NotificationFactory notificationFactory = new NotificationFactory();
            NotificationManager notificationManager = new NotificationManager(notificationFactory.GetNotifier("mobile"));

            Assert.Equal("Sent notification to mobile", notificationManager.SendNotification());
        }


        [Fact]
        public void TestEmailNotification()
        {
            NotificationFactory notificationFactory = new NotificationFactory();
            NotificationManager notificationManager = new NotificationManager(notificationFactory.GetNotifier("email"));

            Assert.Equal("Sent notification to mail. Insufficient Items in your refrigerator", notificationManager.SendNotification());
        }
    }
}
