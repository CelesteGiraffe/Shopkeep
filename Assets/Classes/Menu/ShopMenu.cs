using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopMenu : MonoBehaviour {

    [SerializeField]
    public GameObject ShopMenuUI;

    public static bool isOpen { get; private set; }

    private void Awake() {
        isOpen = false;
        // find by tag
        ShopMenuUI = GameObject.FindGameObjectWithTag("ShopKeeperMenu");
    }

    public void OpenShopMenu() {
        isOpen = true;
        ShowShopMenu();
    }

    public void CloseShopMenu() {
        isOpen = false;
        HideShopMenu();
    }

    public void ShowShopMenu() {
        ShopMenuUI.SetActive(true);
    }

    public void HideShopMenu() {
        ShopMenuUI.SetActive(false);
    }
}

