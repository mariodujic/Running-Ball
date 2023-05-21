using UnityEngine;

public class BallColor : MonoBehaviour
{
    public Color ballColor;
    public string trailObjectName = "Trail";
    public string glowObjectName = "Glow";

    private void Start()
    {
        SetSharedColor(ballColor);
    }

    public void SetSharedColor(Color ballColor)
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
}