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
}

public enum BallColorType
{
    YELLOW,
    CYAN,
    MAGENTA
}