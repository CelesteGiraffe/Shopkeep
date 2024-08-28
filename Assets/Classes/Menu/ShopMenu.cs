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

    private
    WholeSaler wholeSaler;
    OpenInv openInv;

    public static bool isOpen { get; private set; }

    private void Start()
    {
        isOpen = false;
        // find by tag
        ShopMenuUI = GameObject.FindGameObjectWithTag("ShopKeeperMenu");
        ShopMenuUI.SetActive(false);
        wholeSaler = FindObjectOfType<WholeSaler>();
        openInv = GameObject.FindGameObjectWithTag("Player").GetComponent<OpenInv>();

    }

    public void OpenShopMenu(List<ItemData> items)
    {
        isOpen = true;
        Debug.Log(ShopMenuUI);
        ShopMenuUI.SetActive(true);
        PopulateShopMenu(items);

        if (openInv != null)
        {
            openInv.CloseInventory();
        }
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
            //On click on the button call the BuyItem function
            button.GetComponent<Button>().onClick.AddListener(() => BuyItem(item));
            button.transform.Find("Title").GetComponent<TextMeshProUGUI>().text = item.name;
            button.transform.Find("Price").GetComponent<TextMeshProUGUI>().text = item.price.ToString();
            button.transform.Find("Sprite").GetComponent<Image>().sprite = item.itemIcon;
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

    private void BuyItem(ItemData item)
    {
        if(wholeSaler.PurchaseItem(item, item.price))
        {
            //openInv.AddItem(item);
            RemoveItem(item);
        }
    }

    //remove the item from the shop menu
    public void RemoveItem(ItemData item)
    {
        foreach (Transform child in ItemButtonContainer)
        {
            if (child.Find("Title").GetComponent<TextMeshProUGUI>().text == item.name)
            {
                Destroy(child.gameObject);
                break;
            }
        }
    }
}
