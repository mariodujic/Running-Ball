using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BallCollision : MonoBehaviour
{

    public float increasedGlowEmissionRate = 50f;
    public float glowSizeMultiplier = 1.1f;
    public float glowFlashDuration = 0.01f;
    public GameObject scoreText;
    private TMP_Text textMesh;
    private int score = 0;

    private BallColor ballColor;
    
    private void Start()
    {
        ballColor = GetComponent<BallColor>();
        textMesh = scoreText.GetComponent<TMP_Text>();
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
                    IncrementScore();
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

    void IncrementScore()
    {
        score++;
        textMesh.text = score.ToString();
    }
}
