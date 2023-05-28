using UnityEngine;

public class RoadMaterialColors : MonoBehaviour
{

    public GameObject ball;
    private Renderer roadRenderer;
    void Start()
    {
        roadRenderer = GetComponent<Renderer>();
        BallColor ballColor = ball.GetComponent<BallColor>();
        roadRenderer.material.color = SharedColors.GetSelectedColor(ballColor.selectedColor);
    }
}
