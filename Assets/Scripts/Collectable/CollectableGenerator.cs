using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class CollectableGenerator : MonoBehaviour
{
    public PathCreator pathCreator;
    public GameObject sphereCollectable;
    public int sphereCount = 10;
    public float sphereSpacing = 5f;
    public float offsetDistance = 1f;
    
    void Start()
    {
        StartCoroutine(GenerateObjects());
    }

    private IEnumerator GenerateObjects()
    {
        VertexPath vertexPath = pathCreator.path;
        float pathLength = vertexPath.length;
        float stepSize = pathLength / (sphereCount - 1);

        for (int i = 0; i < sphereCount; i++)
        {
            float distance = i * stepSize;
            Vector3 position = vertexPath.GetPointAtDistance(distance, PathCreation.EndOfPathInstruction.Stop);
            Vector3 pathDirection = pathCreator.path.GetDirectionAtDistance(distance);
            position.y += 0.1f;

            int currentPosition = UnityEngine.Random.Range(0, 3);
            print(currentPosition);
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
            GameObject instantiatedSphere = Instantiate(sphereCollectable, position, Quaternion.identity);
            CollectableColor collectableColor = instantiatedSphere.GetComponent<CollectableColor>();
            BallColorType colorType = SharedColors.GetRandomColorType();
            collectableColor.SetSharedColor(colorType);
        }
        yield return null;
    }

}