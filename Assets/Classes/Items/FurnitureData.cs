using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "NewFurniture", menuName = "Inventory/Furniture")]
public class FurnitureData : ScriptableObject
{
    public string furnitureName;
    public Sprite furnitureIcon;
    public GameObject furniturePrefab;
}

