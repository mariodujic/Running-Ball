using UnityEngine;

public class BallVerticalMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update() {
        float moveAmount = moveSpeed * Time.deltaTime;
        transform.position += transform.forward * moveAmount;
    }
}