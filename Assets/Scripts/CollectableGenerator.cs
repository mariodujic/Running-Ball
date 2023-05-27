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
            position.y += 0.1f;
            Instantiate(sphereCollectable, position, Quaternion.identity);
        }
        yield return null;
    }
}