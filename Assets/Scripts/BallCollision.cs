using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BallCollision : MonoBehaviour
{


    private void OnTriggerEnter(Collider collider)
    {
        
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
            }
        }
    }
}
