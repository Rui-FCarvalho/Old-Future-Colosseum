﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraCenter : MonoBehaviour {

 float margin = 10f; // space between screen border and nearest fighter

public GameObject p1;
public GameObject p2;

 private float z0 = 0; // coord z of the fighters plane
 private float zCam; // camera distance to the fighters plane
 private float wScene; // scene width
 private Transform f1; // fighter1 transform
 private Transform f2; // fighter2 transform
 private float xL; // left screen X coordinate
 private float xR; // right screen X coordinate
 
 void calcScreen(Transform p1, Transform p2)
    {
        // Calculates the xL and xR screen coordinates 
        if (p1.position.x < p2.position.x)
        {
            xL = p1.position.x - margin;
            xR = p2.position.x + margin;
        }
        else
        {
            xL = p2.position.x - margin;
            xR = p1.position.x + margin;
        }
    }

   void Start()
    {
        // find references to the fighters
        f1 = p1.transform;
        f2 = p2.transform;
        // initializes scene size and camera distance
        calcScreen(f1, f2);
        wScene = xR - xL;
        zCam = transform.position.z - z0;
    }

  void Update()
    {

        calcScreen(f1, f2);
         float width = xR - xL;
        if (width > wScene)
        { // if fighters too far adjust camera distance
            transform.position = new Vector3(transform.position.x, transform.position.y, zCam * width / wScene + z0);
        }
        // centers the camera
        transform.position = new Vector3((xR + xL) / 2, transform.position.y, transform.position.z);

    }
}
