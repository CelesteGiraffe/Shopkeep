using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSystem : MonoBehaviour
{
    private List<ShopSlot> _shopInventory;
    private int L_size;
    private float L_buyMarkUp;

    public ShopSystem(int size, float buyMarkUp) {
        L_size = size;
        L_buyMarkUp = buyMarkUp;

        SetShopSize(size);
    }

    private void SetShopSize(int size) {

    }   
}
