using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TimeSystem))]

public class NPCManager : MonoBehaviour
{
    public List<NPCData> npcDataList = new List<NPCData>();
    private TimeSystem timeSystem;
    // Start is called before the first frame update
    void Start() {
        timeSystem = GetComponent<TimeSystem>();
    }

    // Update is called once per frame
    void Update() {
        CheckForNPCSpawn();
    }

    void CheckForNPCSpawn() {
        foreach (NPCData npcData in npcDataList) {
            if (ShouldSpawnNPC(npcData)) {
                if (Random.value <= npcData.spawnChance) {
                    SpawnNPC(npcData);
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
