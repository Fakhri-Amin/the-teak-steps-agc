using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapManager : MonoBehaviour
{
    [SerializeField] private int maxTraps;
    [SerializeField] private float spawnDelay;
         
    [SerializeField] private GameObject trapPrefab;
    [SerializeField] private List<Transform> spawnPositions;

    private List<GameObject> trapPool;

    private void Start()
    {
        trapPool = new List<GameObject>();

        for (int i = 0; i < maxTraps; i++)
        {
            GameObject trap = Instantiate(trapPrefab, gameObject.transform, true);
            trap.SetActive(false);
            trapPool.Add(trap);
        }

        StartCoroutine(SpawnTraps());
    }

    private IEnumerator SpawnTraps()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnDelay);
            SpawnTrap();
        }
    }

    private void SpawnTrap()
    {
        for (int i = 0; i < trapPool.Count; i++)
        {
            if (!trapPool[i].activeInHierarchy)
            {
                Transform spawnPosition = GetRandomSpawnPosition();

                //Cek apakah spawn position sudah terpakai
                bool positionIsAvailable = true;
                for (int j = 0; j < trapPool.Count; j++)
                {
                    if (trapPool[j].activeInHierarchy &&
                        trapPool[j].transform.position == spawnPosition.position)
                    {
                        positionIsAvailable = false;
                        break;
                    }
                }

                if (positionIsAvailable)
                {
                    trapPool[i].transform.position = spawnPosition.position;
                    trapPool[i].SetActive(true);
                    
                    break;
                }
            }
        }
    }

    private Transform GetRandomSpawnPosition()
    {
        int randomIndex = Random.Range(0, spawnPositions.Count);
        return spawnPositions[randomIndex];
    }
}
