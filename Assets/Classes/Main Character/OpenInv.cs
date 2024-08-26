using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class OpenInv : MonoBehaviour
{
    public GameObject inventoryMenu;

    public GameObject player;

    [SerializeField] private List<FurnitureData> furnitureInventory = new List<FurnitureData>();
    [SerializeField] private List<ItemData> itemInventory = new List<ItemData>();

    [SerializeField] private List<Button> inventoryButtons = new List<Button>();

    private PlayerMovement pm;

    private int currentPage = 0;

    private bool showingFurniture = true;

    private float checkRadius = 1.0f;

    void Start()
    {
        if (inventoryMenu != null)
        {
            inventoryMenu.SetActive(false);
        }
        pm = player.GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (inventoryMenu != null)
            {
                inventoryMenu.SetActive(!inventoryMenu.activeSelf);
                if (inventoryMenu.activeSelf)
                {
                    DisplayInventory();
                }
            }
        }
    }

    void DisplayInventory()
    {
        if (showingFurniture)
        {
            Debug.Log("Displaying furniture inventory");
            DisplayFurniturePage(currentPage);
        }
        else
        {
            Debug.Log("Displaying item inventory");
            DisplayItemPage(currentPage);
        }
    }

    void DisplayFurniturePage(int page)
    {
        int startIndex = page * 6;
        for (int i = 0; i < inventoryButtons.Count; i++)
        {
            if (startIndex + i < furnitureInventory.Count)
            {
                var button = inventoryButtons[i];
                var buttonData = button.GetComponent<InventoryButtonData>() ?? button.gameObject.AddComponent<InventoryButtonData>();
                buttonData.furnitureData = furnitureInventory[startIndex + i];
                button.GetComponent<Image>().sprite = furnitureInventory[startIndex + i].furnitureIcon;
                button.gameObject.SetActive(true);
                button.onClick.RemoveAllListeners();
                button.onClick.AddListener(() => SpawnFurniture(buttonData.furnitureData));
            }
            else
            {
                inventoryButtons[i].gameObject.SetActive(false);
            }
        }
    }

    void DisplayItemPage(int page)
    {
        int startIndex = page * 6;
        for (int i = 0; i < inventoryButtons.Count; i++)
        {
            if (startIndex + i < itemInventory.Count)
            {
                var button = inventoryButtons[i];
                var buttonData = button.GetComponent<InventoryButtonData>() ?? button.gameObject.AddComponent<InventoryButtonData>();
                buttonData.itemData = itemInventory[startIndex + i];
                button.GetComponent<Image>().sprite = itemInventory[startIndex + i].itemIcon;
                button.gameObject.SetActive(true);
                button.onClick.RemoveAllListeners();
                button.onClick.AddListener(() => SpawnItem(buttonData.itemData));
            }
            else
            {
                inventoryButtons[i].gameObject.SetActive(false);
            }
        }
    }

    void SpawnFurniture(FurnitureData furniture)
    {
        Vector3 spawnPosition = pm.GetPositionInFront();
        spawnPosition.z = player.transform.position.z; 
        if (!Physics2D.OverlapCircle(spawnPosition, checkRadius))
        {
            Instantiate(furniture.furniturePrefab, spawnPosition, Quaternion.identity);
            furnitureInventory.Remove(furniture); 
            DisplayInventory(); 
        }
        else
        {
            Debug.Log("Cannot spawn furniture, area is occupied.");
        }
    }

    void SpawnItem(ItemData item)
    {
        Vector3 spawnPosition = pm.GetPositionInFront();
        spawnPosition.z = player.transform.position.z;
        if (!Physics2D.OverlapCircle(spawnPosition, checkRadius))
        {
            Instantiate(item.itemPrefab, spawnPosition, Quaternion.identity);
            itemInventory.Remove(item);
            DisplayInventory();
        }
        else
        {
            Debug.Log("Cannot spawn item, area is occupied.");
        }
    }

    public void AddFurniture(FurnitureData furniture)
    {
        furnitureInventory.Add(furniture);
    }

    public void AddItem(ItemData item)
    {
        itemInventory.Add(item);
    }

    public void NextPage()
    {
        int totalItems = showingFurniture ? furnitureInventory.Count : itemInventory.Count;
        int maxPage = (totalItems - 1) / inventoryButtons.Count;

        if (currentPage < maxPage)
        {
            currentPage++;
            DisplayInventory();
        }
    }

    public void PreviousPage()
    {
        if (currentPage > 0)
        {
            currentPage--;
            DisplayInventory();
        }
    }

    public void ShowFurnitureInventory()
    {
        showingFurniture = true;
        currentPage = 0;
        DisplayInventory();
    }

    public void ShowItemInventory()
    {
        showingFurniture = false;
        currentPage = 0;
        DisplayInventory();
    }
}