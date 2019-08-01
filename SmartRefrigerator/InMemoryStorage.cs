using SmartRefrigerator;
using System.Collections.Generic;

public class InMemoryStorage : IStorage
{
    private Dictionary<Vegetable, int> _vegetableQuantities = new Dictionary<Vegetable, int>();
    public int GetVegetableMinimumQuantity(Vegetable vegetable)
    {
        if (_vegetableQuantities.ContainsKey(vegetable))
        {
            return _vegetableQuantities[vegetable];
        }

        throw new VegetableNotFoundException();
    }

    public void SetVegetableMinimumQuantity(Vegetable vegetable, int quantity)
    {
        if (_vegetableQuantities.ContainsKey(vegetable))
        {
            _vegetableQuantities[vegetable] = quantity;
        }
        else
        {
            _vegetableQuantities.Add(vegetable, quantity);
        }
    }
}
