using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallCollision : MonoBehaviour
{

    public float increasedGlowEmissionRate = 50f;
    public float glowSizeMultiplier = 1.1f;
    public float glowFlashDuration = 0.01f;

    private BallColor ballColor;
    
    private void Start()
    {
        ballColor = GetComponent<BallColor>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        
        StartCoroutine(ballColor.FlashGlow(increasedGlowEmissionRate, glowSizeMultiplier, glowFlashDuration));
        if (collider.CompareTag("CollectableSphere"))
        {
   
            Renderer ballRenderer = gameObject.GetComponent<Renderer>();
            Renderer renderer = collider.gameObject.GetComponent<Renderer>();
            if (renderer != null)
            {
                Color color = renderer.material.color;
                Color ballColor = ballRenderer.material.color;
                if (color == ballColor)
                {
                    Destroy(collider.gameObject);
                }
                else
                {
                    string activeSceneName = SceneManager.GetActiveScene().name;
                    SceneManager.LoadScene(activeSceneName);
                }
            }
        }
    }
}
