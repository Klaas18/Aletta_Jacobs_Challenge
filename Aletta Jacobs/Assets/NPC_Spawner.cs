using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NPC_Spawner : MonoBehaviour
{
    public GameObject npcPrefab;
    public GameObject[] spawnerLocations;

    // Start is called before the first frame update
    void Start()
    {
        GetSpawners();
    }

    public void GetSpawners()
    {
        spawnerLocations = GameObject.FindGameObjectsWithTag("spawners");
        
        //foreach (GameObject spawner in spawners)
        //{
        //    spawnerLocations.ToList().Add(spawner.GetComponent<Transform>());
        //}
        SpawnNPC();
    }
    public void SpawnNPC()
    {
        foreach (GameObject spawnPoint in spawnerLocations)
        {
            if (npcPrefab != null)
            {
                // Spawn two NPCs at each spawner location
                Instantiate(npcPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
                Instantiate(npcPrefab, spawnPoint.transform.position + new Vector3(1f, 0, 0), spawnPoint.transform.rotation);
            }
        }
    }
// Update is called once per frame

}
