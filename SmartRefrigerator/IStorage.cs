using SmartRefrigerator;

namespace SmartRefrigerator
{
    public interface IStorage
    {
        void SetVegetableMinimumQuantity(Vegetable vegetable, int quantity);

        int GetVegetableMinimumQuantity(Vegetable vegetable);
    }

}
