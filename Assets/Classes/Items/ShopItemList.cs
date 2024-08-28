using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShopItemList", menuName = "Shop/ShopItemList", order = 1)]
public class ShopItemList : ScriptableObject
{
    [SerializeField]
    private List<ShopItem> L_shopItems;
    [SerializeField]
    private float _buyMarkUp;
}

[System.Serializable]
public struct ShopItem {
    public ItemData itemData;
    public int price;
    public int quantity;
}