using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(UniqueId))]
[RequireComponent(typeof(ShopMenu))]

public class ShopKeeper : MonoBehaviour, IInteractable {
    [SerializeField] private ShopItemList L_shopItemsHeld;
    private ShopSystem L_shopSystem;
    private ShopMenu L_shopMenu;

    private void Awake() {
        L_shopSystem = new ShopSystem(L_shopItemsHeld.Items.Count, L_shopItemsHeld.BuyMarkUp);
        L_shopMenu = GetComponent<ShopMenu>();

        foreach (ShopItem item in L_shopItemsHeld.Items) {
            L_shopSystem.AddToShop(item.itemData, item.quantity);
        }
    }

    public void Interact() {
        if (L_shopMenu == null) {
            Debug.LogWarning("ShopMenu not found on ShopKeeper");
            return;
        }

        if (ShopMenu.isOpen == true) {
            L_shopMenu.CloseShopMenu();
            return;
        }

        else {
            L_shopMenu.OpenShopMenu();
        }
    }

    public void EndInteraction() {
        throw new System.NotImplementedException();
    }

}
