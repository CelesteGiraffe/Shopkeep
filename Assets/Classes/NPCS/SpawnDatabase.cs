using System.Collections.Generic;
using UnityEngine;

public class SpawnDatabase : MonoBehaviour
{
    public static SpawnDatabase instance;

    [SerializeField]
    private List<NPCData> data;

    private Dictionary<int, NPCData> npcDictionary;

    private void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
            InitializeDatabase();
        }
        else {
            Destroy(gameObject);
        }
    }

    private void InitializeDatabase() {
        npcDictionary = new Dictionary<int, NPCData>();
        foreach (var npc in data)
        {
            if (!npcDictionary.ContainsKey(npc.ID))
            {
                npcDictionary.Add(npc.ID, npc);
            }
            else
            {
                Debug.LogWarning($"Duplicate NPC ID found: {npc.ID} for NPC {npc.npcName}");
            }
        }
    }

    public static NPCData GetNPC(int id) {
        if (instance.npcDictionary.TryGetValue(id, out var npc)) {
            return npc;
        }
        Debug.LogWarning($"NPC with ID {id} not found.");
        return null;
    }

    public static NPCData GetRandomNPC(List<NPCData> npcList) {
        return npcList[Random.Range(0, npcList.Count)];
    }
}
