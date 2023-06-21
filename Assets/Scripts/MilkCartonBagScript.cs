using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilkCartonBagScript : MonoBehaviour
{

    Rigidbody rb;
    public Transform controller;
    public Vector3 newPosition;
    //[Range(0.0f, 360.0f)] public float rotateBy = 200f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        newPosition = controller.position;
        //newPosition.z = newPosition.z + 0.5f;
        newPosition.y = newPosition.y - 1.5f;
        //newPosition.x = newPosition.x - 0.5f;
        rb.MovePosition(newPosition);
        //rb.MoveRotation(controller.rotation * Quaternion.Euler(rotateBy, 0,0));
        rb.MoveRotation(controller.rotation );

    }
}
