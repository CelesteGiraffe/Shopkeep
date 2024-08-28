using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSystem
{
    private List<ShopSlot> L_shopInventory;
    private int L_size;
    private float L_buyMarkUp;

    public ShopSystem(int size, float buyMarkUp)
    {
        L_size = size;
        L_buyMarkUp = buyMarkUp;

        SetShopSize(size);
    }

    private void SetShopSize(int size)
    {
        L_shopInventory = new List<ShopSlot>(size);

        for (int i = 0; i < size; i++)
        {
            L_shopInventory.Add(new ShopSlot());
        }
    }

    public void AddToShop(ItemData itemData, int quantity)
    {
        if (ContainsItem(itemData, out ShopSlot shopSlot))
        {
            shopSlot.AddToStack(quantity);
        }
        else
        {
            var freeSlot = GetFreeSlot();
            if (freeSlot != null)
            {
                freeSlot.SetItemData(itemData, quantity);
            }
        }
    }

    private ShopSlot GetFreeSlot()
    {
        var freeSlot = L_shopInventory.Find(slot => slot.GetItemData() == null);

        if (freeSlot == null)
        {
            Debug.LogWarning("No free slots in shop inventory");
            return null;
        }

        return freeSlot;
    }

    public bool ContainsItem(ItemData itemToAdd, out ShopSlot shopSlot)
    {
        shopSlot = L_shopInventory.Find(slot => slot.GetItemData() == itemToAdd);
        return shopSlot != null;
    }

    public List<ItemData> GetShopItems()
    {
        List<ItemData> items = new List<ItemData>();
        foreach (var slot in L_shopInventory)
        {
            if (slot.GetItemData() != null)
            {
                items.Add(slot.GetItemData());
            }
        }
        return items;
    }
}
