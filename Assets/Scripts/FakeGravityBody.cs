using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeGravityBody : MonoBehaviour
{
    public FakeGravity attractor;

    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        rb.useGravity = false;
    }

    void FixedUpdate()
    {
        attractor.Attract(transform, rb);
    }
}
