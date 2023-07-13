using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherController : MonoBehaviour
{
    [SerializeField] private float maxForce;
    [SerializeField] private float maxTimeHold;

    private bool isHold;

    private void OnCollisionStay(Collision other)
    {

        if (Input.GetKey(KeyCode.Space) && !isHold)
        {
            StartCoroutine(StartHold(other));
        }
    }

    IEnumerator StartHold(Collision other)
    {
        isHold = true;

        float force = 0f;
        float timeHold = 0f;

        while (Input.GetKey(KeyCode.Space))
        {
            force = Mathf.Lerp(0, maxForce, timeHold / maxTimeHold);
            yield return new WaitForEndOfFrame();
            timeHold += Time.deltaTime;
        }

        Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
        rb.AddForce(Vector3.forward * force);
        isHold = false;
    }
}
