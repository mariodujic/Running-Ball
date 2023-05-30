using PathCreation;
using UnityEngine;

public class BallPath : MonoBehaviour
{
    public PathCreator pathCreator;
    public float speed = 5;
    public float lateralSpeed = 5f;
    private Vector3 velocity = Vector3.zero;
    private float distanceTravelled;
    private HorizontalPosition currentPosition = HorizontalPosition.Center;

    void Update()
    {
        distanceTravelled += speed * Time.deltaTime;
        Vector3 position = pathCreator.path.GetPointAtDistance(distanceTravelled);
        Vector3 pathDirection = pathCreator.path.GetDirectionAtDistance(distanceTravelled);
        position.y += 0.1f;

        if (Input.GetKeyDown(KeyCode.LeftArrow) && currentPosition > HorizontalPosition.Left)
        {
            currentPosition--;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && currentPosition < HorizontalPosition.Right)
        {
            currentPosition++;
        }

        Vector3 targetPosition = position;

        switch (currentPosition)
        {
            case HorizontalPosition.Left:
                targetPosition -= Vector3.Cross(pathDirection, Vector3.up) * HorizontalPositionOffset.Left;
                break;
            case HorizontalPosition.Right:
                targetPosition -= Vector3.Cross(pathDirection, Vector3.up) * HorizontalPositionOffset.Right;
                break;
            default:
                break;
        }

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, lateralSpeed * Time.deltaTime);
    }
}