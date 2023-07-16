using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperController : MonoBehaviour
{
    [SerializeField] private float forceMultiplier = 3f;
    [SerializeField] private Material[] materials;

    private Animator animator;
    private Renderer bumperRenderer;
    private int materialIndex;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        bumperRenderer = GetComponent<Renderer>();
    }

    private void Start()
    {
        materialIndex = 0;
        bumperRenderer.material = materials[materialIndex];
    }

    private void OnCollisionEnter(Collision other)
    {
        Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
        if (rb)
        {
            // Multiply velociti bola dengan moveSpeed
            rb.velocity *= forceMultiplier;

            // Trigger animation hit
            animator.SetTrigger("Hit");

            /*// Merubah warna material ke hit material
            meshRenderer.material = hitMaterial;

            // Memulai timer untuk merubah kembali warna material menjadi warna material awal
            StartCoroutine(GetHit());*/

            ChangeMaterial();
        }
    }

    private void ChangeMaterial()
    {
        materialIndex = (materialIndex + 1) % materials.Length;
        bumperRenderer.material = materials[materialIndex];
    }

    /*
   IEnumerator GetHit()
   {
       yield return new WaitForSeconds(.1f);
       meshRenderer.material = startMaterial;
   }*/
}
