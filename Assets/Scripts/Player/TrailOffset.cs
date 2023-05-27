using UnityEngine;

public class TrailOffset : MonoBehaviour
{
    public float yOffSet = 1f;
    public float zOffset = 1f;

    void Start()
    {
        Transform trailTransform = transform.GetChild(0);
        trailTransform.localPosition = new Vector3(0, yOffSet, zOffset); 
    }
}