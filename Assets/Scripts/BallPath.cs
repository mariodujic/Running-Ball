using PathCreation;
using UnityEngine;

public class BallPath : MonoBehaviour
{

    public PathCreator pathCreator;
    public float speed = 5;
    float distanceTravelled;

    void Update()
    {
        distanceTravelled += speed * Time.deltaTime;
        Vector3 position = pathCreator.path.GetPointAtDistance(distanceTravelled);
        position.y += 0.1f;
        transform.position = position;
    }
}
