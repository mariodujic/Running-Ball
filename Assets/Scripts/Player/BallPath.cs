using PathCreation;
using UnityEngine;

public class BallPath : MonoBehaviour
{
    public PathCreator pathCreator;
    public float speed = 5;
    private float distanceTravelled;
    private int currentPosition = 1; // 0: Left, 1: Middle, 2: Right
    public float offsetDistance = 1f;

    void Update()
    {
        distanceTravelled += speed * Time.deltaTime;
        Vector3 position = pathCreator.path.GetPointAtDistance(distanceTravelled);
        Vector3 pathDirection = pathCreator.path.GetDirectionAtDistance(distanceTravelled);
        position.y += 0.1f;

        if (Input.GetKeyDown(KeyCode.LeftArrow) && currentPosition > 0)
        {
            currentPosition--;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && currentPosition < 2)
        {
            currentPosition++;
        }

        switch (currentPosition)
        {
            case 0:
                position += Vector3.Cross(pathDirection, Vector3.up) * offsetDistance;
                break;
            case 2:
                position -= Vector3.Cross(pathDirection, Vector3.up) * offsetDistance;
                break;
            default:
                break;
        }

        transform.position = position;
    }
}