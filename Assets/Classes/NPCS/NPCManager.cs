using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(TimeSystem))]

public class NPCManager : MonoBehaviour
{
    public SpawnDatabase spawnDatabase;
    private TimeSystem timeSystem;
    private Dictionary<int, NPCData> npcDictionary;
    private float checkCooldown = 10f;
    // Start is called before the first frame update
    void Start() {
        timeSystem = GetComponent<TimeSystem>();
        spawnDatabase = GetComponent<SpawnDatabase>();
        npcDictionary = spawnDatabase.GetNPCdict();
    }

    // Update is called once per frame
    void Update() {
        int[] currentTime = timeSystem.GetTime();
        if (timeSystem != null) {
            Debug.Log($"Current Time: {currentTime[2]}:{currentTime[1]}:{currentTime[0]} {currentTime[3]}/{currentTime[4]}/{currentTime[5]}");
        }
        checkCooldown -= Time.deltaTime;
        if (checkCooldown <= 0) {
            checkCooldown = 10f;
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
        if (npcData.spawnEveryDay) {
            return true;
        }
        int[] currentTime = timeSystem.GetTime();
        if (npcData.spawnDay == currentTime[3] && npcData.spawnHour == currentTime[2] && npcData.spawnMinute == currentTime[1]) {
            return true;
        }
        return false;
    }

    void SpawnNPC(NPCData npcData) {
        Instantiate(npcData.npcPrefab, npcData.spawnPosition, Quaternion.identity);
    }
}
