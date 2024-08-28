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
        Vector3 L_SpawnVariance;
        foreach (var npc in npcDictionary) {
            if (ShouldSpawnNPC(npc.Value)) {
                if (Random.value <= npc.Value.spawnChance) {
                    L_SpawnVariance = npc.Value.spawnPosition;
                    int maxAttempts = 10;
                    int attempts = 0;

                    while (IsSpawnPositionBlocked(L_SpawnVariance) && attempts < maxAttempts) {
                        Debug.Log("Spawn position blocked, trying new position");
                        L_SpawnVariance.x = npc.Value.spawnPosition.x + Random.Range(-2, 2);
                        L_SpawnVariance.y = npc.Value.spawnPosition.y + Random.Range(0, 2);
                        attempts++;
                    }
                    if (attempts < maxAttempts) {
                        SpawnNPC(npc.Value, L_SpawnVariance);
                    }
                    else {
                        Debug.Log("Failed to spawn NPC after 10 attempts");
                    }
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

    private bool IsSpawnPositionBlocked(Vector3 spawnPosition) {
        float radius = 0.5f;
        LayerMask layerMask = LayerMask.GetMask("Obstacle");

        bool isBlocked = Physics2D.OverlapCircle(spawnPosition, radius, layerMask);
        Debug.Log($"Checking spawn position {spawnPosition} for obstacles. Is blocked: {isBlocked}");
        return isBlocked;
    }

    void SpawnNPC(NPCData npcData, Vector3 spawnVariance) {
        int[] currentTime = timeSystem.GetTime();
        if (spawnVariance == null) {
            spawnVariance = npcData.spawnPosition;
        }
        Instantiate(npcData.npcPrefab, spawnVariance, Quaternion.identity);
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
