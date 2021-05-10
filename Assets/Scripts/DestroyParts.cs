﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParts : MonoBehaviour
{

[SerializeField]
Vector2 forceDir;
[SerializeField]
int spin;
Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(forceDir);
        rb.AddTorque(spin);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
