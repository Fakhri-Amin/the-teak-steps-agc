using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    [SerializeField] private int blinkTimes = 20;
    [SerializeField] private Material onMaterial;

    private MeshRenderer meshRenderer;
    private Material startMaterial;
    private bool isOn;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        startMaterial = meshRenderer.material;
    }

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
        if (rb)
        {
            StartCoroutine(Blink(blinkTimes));
            SwitchMaterial();
        }
    }

    private void SwitchMaterial()
    {
        isOn = !isOn;
        meshRenderer.material = isOn ? onMaterial : startMaterial;
    }

    IEnumerator Blink(int times)
    {
        for (int i = 0; i < times * 2; i++)
        {
            SwitchMaterial();
            yield return new WaitForSeconds(0.1f);
        }
    }

}
