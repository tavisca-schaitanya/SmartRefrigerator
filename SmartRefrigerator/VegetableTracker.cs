using System.Collections.Generic;

namespace SmartRefrigerator
{
    public class VegetableTracker
    {
        VegetableTray _vegetableTray;
        ConfigurationManager _configurationManager;
        public VegetableTracker(VegetableTray vegetableTray, ConfigurationManager configurationManager)
        {
            _vegetableTray = vegetableTray;
            _configurationManager = configurationManager;
        }
        public List<KeyValuePair<Vegetable, int>> GetInsufficientVegetableQuantity()
        {
            List<KeyValuePair<Vegetable, int>> insufficientVegetableQuantity = new List<KeyValuePair<Vegetable, int>>();

            try
            {
                var vegetableQuantity = _vegetableTray.GetVegetableQuantity();
                foreach (var item in vegetableQuantity)
                {
                    int minimumQuantity = _configurationManager.GetMinimumQuantity(item.Key);
                    if (item.Value < minimumQuantity)
                    {
                        insufficientVegetableQuantity.Add(new KeyValuePair<Vegetable, int>(item.Key, minimumQuantity - item.Value));
                    }
                }
            }
            catch(VegetableNotFoundException ex)
            {
                System.Console.WriteLine(ex.Message);
            }

            return insufficientVegetableQuantity;
        }
    }

}
