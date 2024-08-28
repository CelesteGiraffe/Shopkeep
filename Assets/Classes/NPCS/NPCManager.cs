using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(TimeSystem))]

public class NPCManager : MonoBehaviour
{
    public SpawnDatabase spawnDatabase;
    private TimeSystem timeSystem;
    private Dictionary<int, NPCData> npcDictionary;
    private float checkCooldown = 1f;
    private List<NPCData> spawnedNPCList;

    void Start() {
        timeSystem = GetComponent<TimeSystem>();
        spawnDatabase = GetComponent<SpawnDatabase>();
        npcDictionary = spawnDatabase.GetNPCdict();
        spawnedNPCList = new List<NPCData>();
    }

    void Update() {
        checkCooldown -= Time.deltaTime;
        if (checkCooldown <= 0) {
            checkCooldown = 1f;
            CheckForNPCSpawn();
        }

    }

    void CheckForNPCSpawn() {
        foreach (var npc in npcDictionary) {
            if (ShouldSpawnNPC(npc.Value)) {
                if (Random.value <= npc.Value.spawnChance) {
                    SpawnNPC(npc.Value);
                }
            }
        }
    }

    bool ShouldSpawnNPC(NPCData npcData) {
        if (npcData == null) {
            return false;
        }
        else if (spawnedNPCList.Any(npc => npc.ID == npcData.ID)) {
            return false;
        }
        int[] currentTime = timeSystem.GetTime();
        if (npcData.spawnEveryDay && npcData.spawnHour == currentTime[2] ) {
            return true;
        }
        else if (npcData.spawnDay == currentTime[3] && npcData.spawnHour == currentTime[2]) {
            return true;
        }
        return false;
    }

    void SpawnNPC(NPCData npcData) {
        int[] currentTime = timeSystem.GetTime();
        Instantiate(npcData.npcPrefab, npcData.spawnPosition, Quaternion.identity);
        spawnedNPCList.Add(npcData);
        Debug.Log($"Current Time: {currentTime[2]}:{currentTime[1]}:{currentTime[0]} {currentTime[3]}/{currentTime[4]}/{currentTime[5]}");
    }

    public void DespawnNPC(NPCData npcData) {
        if (spawnedNPCList.Contains(npcData)) {
            spawnedNPCList.Remove(npcData);
            Destroy(npcData.npcPrefab);
        }
    }
}
