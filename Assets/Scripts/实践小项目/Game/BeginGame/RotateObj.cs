using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObj : MonoBehaviour
{
    public float rotatespeed;

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(Vector3.up, rotatespeed * Time.deltaTime);
    }
}
