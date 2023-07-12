using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private Material hitMaterial;

    private Animator animator;
    private MeshRenderer meshRenderer;
    private Material startMaterial;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        startMaterial = meshRenderer.material;
    }

    private void OnCollisionEnter(Collision other)
    {
        Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
        if (rb)
        {
            // Multiply velociti bola dengan moveSpeed
            rb.velocity *= moveSpeed;

            // Trigger animation hit
            animator.SetTrigger("Hit");

            // Merubah warna material ke hit material
            meshRenderer.material = hitMaterial;

            // Memulai timer untuk merubah kembali warna material menjadi warna material awal
            StartCoroutine(GetHit());
        }
    }

    IEnumerator GetHit()
    {
        yield return new WaitForSeconds(.1f);
        meshRenderer.material = startMaterial;
    }
}
