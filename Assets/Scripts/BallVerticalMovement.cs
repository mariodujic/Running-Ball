using UnityEngine;

public class BallVerticalMovement : MonoBehaviour
{
    public float speed = 1f;
    public float rotationSpeed = 1f;
    public float groundCheckDistance = 0.5f;

    void Update()
    {
        // Check if the player is on the ground.
        if (Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, LayerMask.GetMask("Ground")))
        {
            // Move the player forward.
            transform.Translate(0, 0, speed * Time.deltaTime);
            // Rotate the player.
            transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        }
        else
        {
            // The player is not on the ground, so apply gravity.
            transform.GetComponent<Rigidbody>().AddForce(new Vector3(0, -9.81f, 20));
        }
    }
}