using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [SerializeField] private int maxCoins;
    [SerializeField] private float spawnDelay;
    [SerializeField] private float despawnDelay;

    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private List<Transform> spawnPositions;

    private List<GameObject> coinPool;

    private void Start()
    {
        coinPool = new List<GameObject>();

        for (int i = 0; i < maxCoins; i++)
        {
            var coin = Instantiate(coinPrefab, gameObject.transform, true);
            coin.SetActive(false);
            coinPool.Add(coin);
        }

        StartCoroutine(SpawnCoins());
    }

    private IEnumerator SpawnCoins()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnDelay);
            SpawnCoin();
        }
    }

    private void SpawnCoin()
    {
        for (int i = 0;i < coinPool.Count; i++)
        {
            if (!coinPool[i].activeInHierarchy)
            {
                Transform spawnPosition = GetRandomSpawnPosition();

                //Cek apakah spawn position sudah terpakai
                bool positionIsAvailable = true;
                for (int j = 0; j < coinPool.Count; j++)
                {
                    if (coinPool[j].activeInHierarchy && 
                        coinPool[j].transform.position == spawnPosition.position)
                    {
                        positionIsAvailable = false;
                        break;
                    }
                }

                if (positionIsAvailable)
                {
                    coinPool[i].transform.position = spawnPosition.position;
                    coinPool[i].SetActive(true);

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
