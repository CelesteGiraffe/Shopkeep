using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public static ItemDatabase instance;

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
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            InitializeDatabase();
        }
        else
        {
            Destroy(gameObject);
        }
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

    public static ItemData GetItem(int id)
    {
        if (instance.itemDictionary.TryGetValue(id, out var item))
        {
            return item;
        }
        Debug.LogWarning($"Item with ID {id} not found.");
        return null;
    }

    public static ItemData GetRandomItem(List<ItemData> itemList)
    {
        if (itemList.Count == 0) return null;
        int index = Random.Range(0, itemList.Count);
        return itemList[index];
    }

    public static ItemData GetRandomEpicItem()
    {
        return GetRandomItem(instance.epicItems);
    }

    public static ItemData GetRandomRareItem()
    {
        return GetRandomItem(instance.rareItems);
    }

    public static ItemData GetRandomCommonItem()
    {
        return GetRandomItem(instance.items);
    }
}
