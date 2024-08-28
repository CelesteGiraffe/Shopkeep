using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopMenu : MonoBehaviour
{
    
    private GameObject ShopMenuUI;

    [SerializeField]
    public GameObject ItemButtonPrefab;

    [SerializeField]
    public Transform ItemButtonContainer;

    public static bool isOpen { get; private set; }

    private void Start()
    {
        isOpen = false;
        // find by tag
        ShopMenuUI = GameObject.FindGameObjectWithTag("ShopKeeperMenu");
        ShopMenuUI.SetActive(false);
    }

    public void OpenShopMenu(List<ItemData> items)
    {
        isOpen = true;
        Debug.Log(ShopMenuUI);
        ShopMenuUI.SetActive(true);
        PopulateShopMenu(items);
    }

    public void CloseShopMenu()
    {
        isOpen = false;
        ShopMenuUI.SetActive(false);
        ClearShopMenu();
    }


    private void PopulateShopMenu(List<ItemData> items)
    {
        foreach (var item in items)
        {
            GameObject button = Instantiate(ItemButtonPrefab, ItemButtonContainer);
            button.transform.Find("Title").GetComponent<TextMeshProUGUI>().text = item.name;
            button.transform.Find("Price").GetComponent<TextMeshProUGUI>().text = item.price.ToString();
            button.GetComponent<Image>().sprite = item.itemIcon;
        }

        // Ensure the layout is updated
        LayoutRebuilder.ForceRebuildLayoutImmediate(ItemButtonContainer.GetComponent<RectTransform>());
    }

    private void ClearShopMenu()
    {
        foreach (Transform child in ItemButtonContainer)
        {
            Destroy(child.gameObject);
        }

        // Ensure the layout is updated
        LayoutRebuilder.ForceRebuildLayoutImmediate(ItemButtonContainer.GetComponent<RectTransform>());
    }
}
