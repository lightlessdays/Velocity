﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRotateScript : MonoBehaviour
{
    public float rotationSpeed = 40.0f; 
 
    void Update() {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.Self);
    }
}
