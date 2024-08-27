using System.Collections.Generic;
using UnityEngine;

public class FurnitureManager : MonoBehaviour
{
    private List<Furniture> furnitureList = new List<Furniture>();

    public void RegisterFurniture(Furniture furniture)
    {
        if (!furnitureList.Contains(furniture))
        {
            furnitureList.Add(furniture);
        }
    }

    public List<ItemData> GetItemsOnFurniture()
    {
        List<ItemData> items = new List<ItemData>();
        foreach (var furniture in furnitureList)
        {
            if (!furniture.IsEmpty())
            {
                items.Add(furniture.GetItem());
            }
        }
        return items;
    }
}
