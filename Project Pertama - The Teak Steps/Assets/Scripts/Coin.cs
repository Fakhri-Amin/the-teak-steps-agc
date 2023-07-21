using System;
using System.Collections;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private float despawnDelay;
    
    private bool isDespawning;

    public bool IsDespawning()
    {
        return isDespawning;
    }

    public IEnumerator DespawnCoin()
    {
        isDespawning = true;
        yield return new WaitForSeconds(despawnDelay);

        if (gameObject.activeInHierarchy)
        {
            gameObject.SetActive(false);
        }

        isDespawning = false;
    }

    private void OnEnable()
    {
        StartCoroutine(DespawnCoin());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            if (IsDespawning())
                StopCoroutine(DespawnCoin());
            
            gameObject.SetActive(false);
        }
    }
}
