using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    [SerializeField]
    private List<ItemData> items;

    [SerializeField]
    private List<ItemData> epicItems;
    [SerializeField]
    private List<ItemData> rareItems;
    [SerializeField]
    private List<ItemData> commonItems;

    private Dictionary<int, ItemData> itemDictionary;

    private void Awake()
    {
        InitializeDatabase();
    }

    private void InitializeDatabase()
    {
        itemDictionary = new Dictionary<int, ItemData>();
        foreach (var item in items)
        {
            if (!itemDictionary.ContainsKey(item.ID))
            {
                itemDictionary.Add(item.ID, item);
            }
            else
            {
                Debug.LogWarning($"Duplicate item ID found: {item.ID} for item {item.itemName}");
            }
        }
    }

    public ItemData GetItem(int id)
    {
        if (itemDictionary.TryGetValue(id, out var item))
        {
            return item;
        }
        Debug.LogWarning($"Item with ID {id} not found.");
        return null;
    }

    public ItemData GetRandomItem(List<ItemData> itemList)
    {
        if (itemList.Count == 0) return null;
        int index = Random.Range(0, itemList.Count);
        return itemList[index];
    }

    public ItemData GetRandomEpicItem()
    {
        if (epicItems == null)
        {
            Debug.LogError("epicItems list is null.");
            return null;
        }

        return GetRandomItem(epicItems);
    }

    public ItemData GetRandomRareItem()
    {
        return GetRandomItem(rareItems);
    }

    public ItemData GetRandomCommonItem()
    {
        return GetRandomItem(items);
    }
}
