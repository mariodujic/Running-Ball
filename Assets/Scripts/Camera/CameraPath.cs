using PathCreation;
using UnityEngine;

public class CameraPath : MonoBehaviour
{
    public PathCreator pathCreator;
    public float speed = 5;
    float distanceTravelled;
    public float verticalOffset = 10f;
    public float lookDownAngle = 45f;

    void Update()
    {
        distanceTravelled += speed * Time.deltaTime;
        Vector3 position = pathCreator.path.GetPointAtDistance(distanceTravelled - 1.0f);
        position.y += verticalOffset;
        transform.position = position;

        Quaternion lookRotation = Quaternion.LookRotation(pathCreator.path.GetDirectionAtDistance(distanceTravelled));
        transform.rotation = Quaternion.Euler(lookDownAngle, lookRotation.eulerAngles.y, lookRotation.eulerAngles.z);
    }
}