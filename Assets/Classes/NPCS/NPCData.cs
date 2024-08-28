using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class NPCData {
    public int ID;
    public GameObject npcPrefab;
    public string npcName;
    public int spawnMinute;
    public int spawnHour;
    public int spawnDay;
    public bool spawnEveryDay;
    public float spawnChance;
    public Vector3 spawnPosition;
}
