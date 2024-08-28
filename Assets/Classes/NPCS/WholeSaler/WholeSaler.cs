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

    private ItemDatabase itemDatabase;

    public int NumOfSlots = 10;

    private void Awake()
    {
        L_shopSystem = new ShopSystem(NumOfSlots, 0);
        L_shopMenu = GetComponent<ShopMenu>();

        itemDatabase = FindObjectOfType<ItemDatabase>();

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
                itemData = itemDatabase.GetRandomEpicItem();
            }
            else if (roll < 30) //20%
            {
                itemData = itemDatabase.GetRandomRareItem();
            }
            else //70%
            {
                itemData = itemDatabase.GetRandomCommonItem();
            }

            if (itemData != null)
            {
                L_shopSystem.AddToShop(itemData, Random.Range(1, 10)); // Random quantity
            }
        }
    }

    public void Interact()
    {
        Debug.Log("Interacting with WholeSaler");
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

    //If Esc is pressed, close the shop menu if it's open
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (ShopMenu.isOpen == true)
            {
                L_shopMenu.CloseShopMenu();
            }
        }
    }

    public void EndInteraction()
    {
        throw new System.NotImplementedException();
    }
}