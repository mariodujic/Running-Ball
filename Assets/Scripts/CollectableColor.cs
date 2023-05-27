using UnityEngine;

public class CollectableColor : MonoBehaviour
{

    public void SetSharedColor(BallColorType colorType)
    {
        MeshRenderer sphereRenderer = GetComponent<MeshRenderer>();
        if (sphereRenderer != null)
        {
            sphereRenderer.material.color = SharedColors.GetSelectedColor(colorType);
        }
    }
}