using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(fileName = "NewItem", menuName = "Inventory/Item")]
public class ItemData : ScriptableObject
{
    public int ID;
    public string itemName;
    public Sprite itemIcon;
    public GameObject itemPrefab;
}
