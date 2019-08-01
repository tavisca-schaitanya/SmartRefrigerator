using Newtonsoft.Json;
using SmartRefrigerator;
using System;
using System.Collections.Generic;
using System.IO;

public class FileBasedStorage : IStorage
{
    private Dictionary<Vegetable, int> _vegetableQuantities;
    public FileBasedStorage()
    {
        _vegetableQuantities = new Dictionary<Vegetable, int>();
        SerializeObject(_vegetableQuantities);
    }
    
    public int GetVegetableMinimumQuantity(Vegetable vegetable)
    {
        _vegetableQuantities = DeserializeObject();
        if (_vegetableQuantities.ContainsKey(vegetable))
        {
            return _vegetableQuantities[vegetable];
        }
        throw new VegetableNotFoundException();
    }

    public void SetVegetableMinimumQuantity(Vegetable vegetable, int quantity)
    {
        _vegetableQuantities = DeserializeObject();
        if (_vegetableQuantities.ContainsKey(vegetable))
        {
            _vegetableQuantities[vegetable] = quantity;
        }
        else
        {
            _vegetableQuantities.Add(vegetable, quantity);
        }
        SerializeObject(_vegetableQuantities);
    }

    public void SerializeObject(Dictionary<Vegetable, int> data)
    {
        Dictionary<string, int> storageDictionary = new Dictionary<string, int>();
        foreach(var pair in data)
        {
            string vegetableJson = JsonConvert.SerializeObject(pair.Key);
            storageDictionary.Add(vegetableJson, pair.Value);
        }
        string json = JsonConvert.SerializeObject(storageDictionary);
        File.WriteAllText(@"C:\Users\achaitanya\source\repos\SmartRefrigerator\SmartRefrigerator\VegetableQuantity.txt", json);
    }

    public Dictionary<Vegetable, int> DeserializeObject()
    {
        Dictionary<Vegetable, int> retrievedDictionary = new Dictionary<Vegetable, int>();
        var storageDictionary = JsonConvert.DeserializeObject<Dictionary<string, int>>(File.ReadAllText(@"C:\Users\achaitanya\source\repos\SmartRefrigerator\SmartRefrigerator\VegetableQuantity.txt"));
        foreach(var pair in storageDictionary)
        {
            Vegetable vegetable = JsonConvert.DeserializeObject<Vegetable>(pair.Key);
            retrievedDictionary.Add(vegetable, pair.Value);
        }
        return retrievedDictionary;
    }
}
