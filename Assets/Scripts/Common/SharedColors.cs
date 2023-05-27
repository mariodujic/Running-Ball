using System;
using UnityEngine;

public class SharedColors : MonoBehaviour
{
    public static Color yellow = Color.yellow;
    public static Color cyan = Color.cyan;
    public static Color magenta = Color.magenta;

    public static Color GetSelectedColor(BallColorType selectedColor)
    {
        switch (selectedColor)
        {
            case BallColorType.YELLOW:
                return SharedColors.yellow;
            case BallColorType.CYAN:
                return SharedColors.cyan;
            case BallColorType.MAGENTA:
                return SharedColors.magenta;
            default:
                return SharedColors.yellow;
        }
    }

    public static BallColorType GetRandomColorType()
    {
        int randomIndex = UnityEngine.Random.Range(0, Enum.GetValues(typeof(BallColorType)).Length); 
        return (BallColorType)randomIndex;
    }
}

public enum BallColorType
{
    YELLOW,
    CYAN,
    MAGENTA
}