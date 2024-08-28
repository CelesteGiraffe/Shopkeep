using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopMenu : MonoBehaviour
{
    [SerializeField]
    public GameObject ShopMenuUI;

    [SerializeField]
    public GameObject ItemButtonPrefab;

    [SerializeField]
    public Transform ItemButtonContainer;

    public static bool isOpen { get; private set; }

    private void Awake()
    {
        isOpen = false;
        // find by tag
        ShopMenuUI = GameObject.FindGameObjectWithTag("ShopKeeperMenu");
    }

    public void OpenShopMenu(List<ItemData> items)
    {
        isOpen = true;
        ShowShopMenu();
        PopulateShopMenu(items);
    }

    public void CloseShopMenu()
    {
        isOpen = false;
        HideShopMenu();
        ClearShopMenu();
    }

    public void ShowShopMenu()
    {
        ShopMenuUI.SetActive(true);
    }

    public void HideShopMenu()
    {
        ShopMenuUI.SetActive(false);
    }

    private void PopulateShopMenu(List<ItemData> items)
    {
        foreach (var item in items)
        {
            GameObject button = Instantiate(ItemButtonPrefab, ItemButtonContainer);
            button.GetComponentInChildren<TextMeshProUGUI>().text = item.name;
            button.GetComponent<Image>().sprite = item.itemIcon;
        }
    }

    private void ClearShopMenu()
    {
        foreach (Transform child in ItemButtonContainer)
        {
            Destroy(child.gameObject);
        }
    }
}
