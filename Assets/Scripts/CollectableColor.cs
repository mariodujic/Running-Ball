using UnityEngine;

public class CollectableColor : MonoBehaviour
{
    public BallColorType selectedColor;

    private void Start()
    {
        Color ballColor = SharedColors.GetSelectedColor(selectedColor);
        SetSharedColor(ballColor);
    }

    private void SetSharedColor(Color ballColor)
    {
        MeshRenderer sphereRenderer = GetComponent<MeshRenderer>();
        if (sphereRenderer != null)
        {
            sphereRenderer.material.color = ballColor;
        }
    }
}