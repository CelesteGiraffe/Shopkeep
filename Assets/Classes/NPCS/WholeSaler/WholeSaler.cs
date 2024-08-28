using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

[RequireComponent(typeof(UniqueId))]
[RequireComponent(typeof(ShopMenu))]
public class WholeSaler : MonoBehaviour, IInteractable
{
    private ShopSystem L_shopSystem;
    private ShopMenu L_shopMenu;

    public int NumOfSlots = 10;

    private void Awake()
    {
        L_shopSystem = new ShopSystem(NumOfSlots, 0);
        L_shopMenu = GetComponent<ShopMenu>();

        PopulateShopItems();
    }

    private void PopulateShopItems()
    {
        for (int i = 0; i < NumOfSlots; i++)
        {
            int roll = Random.Range(0, 100);
            ItemData itemData;

            if (roll < 10) //10%
            {
                itemData = ItemDatabase.GetRandomEpicItem();
            }
            else if (roll < 30) //20%
            {
                itemData = ItemDatabase.GetRandomRareItem();
            }
            else //70%
            {
                itemData = ItemDatabase.GetRandomCommonItem();
            }

            if (itemData != null)
            {
                L_shopSystem.AddToShop(itemData, Random.Range(1, 10)); // Random quantity
            }
        }
    }

    public void Interact()
    {
        if (L_shopMenu == null)
        {
            Debug.LogWarning("ShopMenu not found on ShopKeeper");
            return;
        }

        if (ShopMenu.isOpen == true)
        {
            L_shopMenu.CloseShopMenu();
            return;
        }
        else
        {
            List<ItemData> items = L_shopSystem.GetShopItems();
            L_shopMenu.OpenShopMenu(items);
        }
    }

    public void EndInteraction()
    {
        throw new System.NotImplementedException();
    }
}