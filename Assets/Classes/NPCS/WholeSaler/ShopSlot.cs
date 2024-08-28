public class ShopSlot
{
    private ItemData itemData;
    private int quantity;

    public ItemData GetItemData()
    {
        return itemData;
    }

    public void SetItemData(ItemData itemData, int quantity)
    {
        this.itemData = itemData;
        this.quantity = quantity;
    }

    public void AddToStack(int quantity)
    {
        this.quantity += quantity;
    }
}