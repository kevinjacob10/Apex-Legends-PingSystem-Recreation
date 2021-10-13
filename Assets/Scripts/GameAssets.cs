using UnityEngine;
using System.Reflection;

public class GameAssets : MonoBehaviour
{
    private static GameAssets _i;

    public static GameAssets i
    {
        get
        {
            if (_i == null) _i = Instantiate(Resources.Load<GameAssets>("GameAssets"));
            return _i;
        }
    }

    public Transform PingWorld;
    public Transform PingUI;

    public Color pingMoveColour;
    public Color pingEnemyColour;

    public Sprite pingMoveSprite;
    public Sprite pingEnemySprite;
}
