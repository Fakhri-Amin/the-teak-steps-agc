using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    [SerializeField] private KeyCode inputKeycode;
    [SerializeField] private float springForce;

    private float targetPressed;
    private float targetReleased;
    private JointSpring spring;
    private HingeJoint hinge;

    private void Awake()
    {
        hinge = GetComponent<HingeJoint>();
        spring = hinge.spring;
    }

    // Start is called before the first frame update
    void Start()
    {
        targetPressed = hinge.limits.max;
        targetReleased = hinge.limits.min;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ReadInput();
    }

    private void ReadInput()
    {
        if (Input.GetKey(inputKeycode))
        {
            spring.targetPosition = targetPressed;
        }
        else
        {
            spring.targetPosition = targetReleased;
        }
        hinge.spring = spring;
    }
}
