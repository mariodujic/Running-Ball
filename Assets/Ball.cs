using System;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update() {
        // Move the sphere forward
        float moveAmount = moveSpeed * Time.deltaTime;
        transform.position += transform.forward * moveAmount;
    }
}