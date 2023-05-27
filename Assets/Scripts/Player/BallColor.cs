using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallColor : MonoBehaviour
{
    public BallColorType selectedColor;
    public string trailObjectName = "Trail";
    public string glowObjectName = "Glow";
    
    private float originalEmissionRate;
    private float originalSizeMultiplier;

    private void Start()
    {
        Color ballColor = SharedColors.GetSelectedColor(selectedColor);
        SetSharedColor(ballColor);
        StoreStartGlowValues();
    }

    private void SetSharedColor(Color ballColor)
    {
        MeshRenderer sphereRenderer = GetComponent<MeshRenderer>();
        if (sphereRenderer != null)
        {
            sphereRenderer.material.color = ballColor;
        }

        Transform trailObject = transform.Find(trailObjectName);

        if (trailObject != null)
        {
            TrailRenderer trailRenderer = trailObject.GetComponent<TrailRenderer>();
            if (trailRenderer != null)
            {
                GradientColorKey[] colorKeys = new GradientColorKey[2];
                colorKeys[0].color = ballColor;
                colorKeys[0].time = 0f;
                colorKeys[1].color = ballColor;
                colorKeys[1].time = 1f;

                GradientAlphaKey[] alphaKeys = new GradientAlphaKey[2];
                alphaKeys[0].alpha = 1f;
                alphaKeys[0].time = 0f;
                alphaKeys[1].alpha = 0.0f;
                alphaKeys[1].time = 1f;

                Gradient newGradient = new Gradient();
                newGradient.SetKeys(colorKeys, alphaKeys);

                trailRenderer.colorGradient = newGradient;
            }
        }

        Transform glowObject = transform.Find(glowObjectName);

        if (glowObject != null)
        {
            ParticleSystem glowParticleSystem = glowObject.GetComponent<ParticleSystem>();
            if (glowParticleSystem != null)
            {
                GradientColorKey[] colorKeys = new GradientColorKey[2];
                colorKeys[0].color = ballColor;
                colorKeys[0].time = 0f;
                colorKeys[1].color = ballColor;
                colorKeys[1].time = 1f;

                GradientAlphaKey[] alphaKeys = new GradientAlphaKey[2];
                alphaKeys[0].alpha = 0f;
                alphaKeys[0].time = 0f;
                alphaKeys[1].alpha = 1f;
                alphaKeys[1].time = 1f;

                Gradient newGradient = new Gradient();
                newGradient.SetKeys(colorKeys, alphaKeys);

                var main = glowParticleSystem.main;
                main.startColor = new ParticleSystem.MinMaxGradient(newGradient);
            }
        }
    }

    private void StoreStartGlowValues()
    {
        Transform glowObject = transform.Find(glowObjectName);
        ParticleSystem glowParticleSystem = glowObject.GetComponent<ParticleSystem>();
        var emission = glowParticleSystem.emission;
        var main = glowParticleSystem.main;

        originalEmissionRate = emission.rateOverTimeMultiplier;
        originalSizeMultiplier = main.startSizeMultiplier;
    }
    
    public IEnumerator FlashGlow(float emissionRate, float sizeMultiplier, float duration)
    {
        Transform glowObject = transform.Find(glowObjectName);
        ParticleSystem glowParticleSystem = glowObject.GetComponent<ParticleSystem>();
        var emission = glowParticleSystem.emission;
        var main = glowParticleSystem.main;

        emission.rateOverTimeMultiplier = emissionRate;
        main.startSizeMultiplier = originalSizeMultiplier * sizeMultiplier;

        yield return new WaitForSeconds(duration);

        emission.rateOverTimeMultiplier = originalEmissionRate;
        main.startSizeMultiplier = originalSizeMultiplier;
    }
}