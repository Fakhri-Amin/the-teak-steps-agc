using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] private float despawnDelay;
    
    private bool isDespawning;

    public bool IsDespawning()
    {
        return isDespawning;
    }

    public IEnumerator DespawnTrap()
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
        StartCoroutine(DespawnTrap());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            if (IsDespawning())
                StopCoroutine(DespawnTrap());
            
            gameObject.SetActive(false);
        }
    }
}
