using UnityEngine;

public class BallHorizontalPosition : MonoBehaviour
{
    public float moveAmount = 1.0f;
    private int currentPosition = 1; // 0: Left, 1: Middle, 2: Right

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && currentPosition > 0)
        {
            Vector3 newPosition = transform.position;
            newPosition.x -= moveAmount;
            transform.position = newPosition;
            currentPosition--;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && currentPosition < 2)
        {
            Vector3 newPosition = transform.position;
            newPosition.x += moveAmount;
            transform.position = newPosition;
            currentPosition++;
        }
    }
}