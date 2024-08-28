using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemSlot : ISerializationCallbackReceiver
{
    [NonSerialized]
    protected ItemData itemData;
    [SerializeField] 
    protected int L_itemID;
    [SerializeField]
    protected int L_quantity;

    public void ClearSlot() {
        itemData = null;
        L_itemID = -1;
        L_quantity = 0;
    }

    public void AssignItem(ItemData itemData, int quantity) {
        this.itemData = itemData;
        L_itemID = itemData.ID;
        L_quantity = quantity;
    }

    public void AddToStack(int amount) {
        L_quantity += amount;
    }

    public void RemoveFromStack(int amount) {
        L_quantity -= amount;
    }

    public void OnBeforeSerialize() {
        
    }

    public void OnAfterDeserialize() {
        if (L_itemID != -1) {
            var db = Resources.Load<ItemDatabase>("ItemDatabase");
            itemData = ItemDatabase.GetItem(L_itemID);
        }
        else return;
    }
}
