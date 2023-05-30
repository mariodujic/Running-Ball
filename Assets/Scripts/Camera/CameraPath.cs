using PathCreation;
using UnityEngine;

public class CameraPath : MonoBehaviour
{
    public PathCreator pathCreator;
    public float speed = 5;
    private float ballOffsetDistance = 1.0f;
    public float verticalOffset = 10f;
    public float lookDownAngle = 45f;
    private float distanceTravelled;

    void Update()
    {
        distanceTravelled += speed * Time.deltaTime;
        Vector3 position = pathCreator.path.GetPointAtDistance(distanceTravelled - ballOffsetDistance);
        position.y += verticalOffset;
        transform.position = position;

        Quaternion lookRotation = Quaternion.LookRotation(pathCreator.path.GetDirectionAtDistance(distanceTravelled));
        float cameraXAngle = lookRotation.eulerAngles.x + lookDownAngle;
        transform.rotation = Quaternion.Euler(cameraXAngle, lookRotation.eulerAngles.y, lookRotation.eulerAngles.z);
    }
}