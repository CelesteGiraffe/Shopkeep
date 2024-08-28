using System.Collections.Generic;
using UnityEngine;

public class WholeSaler : MonoBehaviour, IInteractable
{
    private ShopSystem L_shopSystem;
    private ShopMenu L_shopMenu;
    private ItemDatabase itemDatabase;
    private PlayerManager playerManager; // Reference to PlayerManager

    public int NumOfSlots = 10;

    private void Awake()
    {
        L_shopSystem = new ShopSystem(NumOfSlots, 0);
        L_shopMenu = GetComponent<ShopMenu>();
        itemDatabase = FindObjectOfType<ItemDatabase>();
        playerManager = FindObjectOfType<PlayerManager>(); // Find PlayerManager in the scene

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

    // Method to handle item purchase
    public void PurchaseItem(ItemData item, int price)
    {
        if (playerManager.SubtractMoney(price))
        {
            OpenInv openInv = playerManager.GetComponent<OpenInv>();
            if (openInv != null)
            {
                openInv.AddItem(item);
                Debug.Log("Item purchased and added to inventory.");
            }
        }
        else
        {
            Debug.Log("Not enough money to purchase the item.");
        }
    }

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