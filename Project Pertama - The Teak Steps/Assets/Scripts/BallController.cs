using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private float maxSpeed;
    private Rigidbody rb;
    private Vector3 startPosition;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        startPosition = transform.position;
    }

    private void FixedUpdate()
    {
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }

    public void ResetBallPosition()
    {
        transform.position = startPosition;
        rb.velocity = rb.velocity.normalized * 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BottomWall"))
        {
            ResetBallPosition();
        }

        if (other.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);
        }
    }
}
