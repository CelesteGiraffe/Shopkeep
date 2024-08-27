using UnityEngine;

public class Furniture : MonoBehaviour, IInteractable
{
    public string furnitureName;
    public Sprite furnitureIcon;
    private ItemData itemOnFurniture = null;
    public Dialogue dialogue;
    private OpenInv openInv;
    public Transform itemLoc; 
    private SpriteRenderer itemSpriteRenderer;

    private void Start()
    {
        dialogue = GameObject.FindGameObjectWithTag("Player").GetComponent<Dialogue>();
        openInv = GameObject.FindGameObjectWithTag("Player").GetComponent<OpenInv>();
        itemSpriteRenderer = itemLoc.GetComponent<SpriteRenderer>();
    }

    public void Interact()
    {
        if (IsEmpty())
        {
            Debug.Log("The furniture is empty.");
            dialogue.StartDialogue(new string[] { "The furniture is empty." });
        }
        else
        {
            dialogue.StartDialogue(new string[] { "You Took: " + itemOnFurniture.itemName });
            RemoveItem();
        }
    }

    public bool IsEmpty()
    {
        return itemOnFurniture == null;
    }

    public void PlaceItem(ItemData item)
    {
        if (IsEmpty())
        {
            itemOnFurniture = item;
            Debug.Log(item.itemName + " placed on " + furnitureName);
            itemSpriteRenderer.sprite = item.itemIcon; 
            itemSpriteRenderer.enabled = true; 
        }
        else
        {
            dialogue.StartDialogue(new string[] { "Furniture already has an item: " + itemOnFurniture.itemName });
        }
    }

    public void RemoveItem()
    {
        if (!IsEmpty())
        {
            Debug.Log(itemOnFurniture.itemName + " removed from " + furnitureName);
            ItemData itemInstance = Instantiate(itemOnFurniture); 
            openInv.AddItem(itemInstance); 
            itemOnFurniture = null;
            itemSpriteRenderer.enabled = false; 
        }
        else
        {
            dialogue.StartDialogue(new string[] { "No item to remove from " + furnitureName });
        }
    }
}