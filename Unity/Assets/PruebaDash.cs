using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruebaDash : MonoBehaviour
{
    public Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.E))
            rb.velocity = new Vector3(50, 0, 0);

    }
}