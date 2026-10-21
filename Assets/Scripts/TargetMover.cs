using System;
using System.Security.Cryptography;
using UnityEngine;

public class TargetMover : MonoBehaviour
{
    private Transform position;
    public int speed = 1;
    public float[] xyBounds = new float[] { -14, -32, 100, 72 };
    void Start()
    {
        position = GetComponent<Transform>();
    }
    void Update()
    {
        position.position += Vector3.back * (UnityEngine.Random.value - 0.2f) * speed;
        position.position += Vector3.right * (UnityEngine.Random.value - 0.2f) * speed;
        position.position += Vector3.forward * (UnityEngine.Random.value - 0.2f) * speed;
        position.position += Vector3.left * (UnityEngine.Random.value - 0.2f) * speed;

        if(position.position.x < xyBounds[0])
        {
            position.position = new Vector3(xyBounds[0], position.position.y, position.position.z);
        } 
        if(position.position.x > xyBounds[2])
        {
            position.position = new Vector3(xyBounds[2], position.position.y, position.position.z);
        }
        if(position.position.y < xyBounds[1])
        {
            position.position = new Vector3(position.position.x, position.position.y, xyBounds[1]);
        }
        if(position.position.y > xyBounds[3])
        {
            position.position = new Vector3(position.position.x, position.position.y, xyBounds[3]);
        }
    }
}
