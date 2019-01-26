using UnityEngine;
using UnityEditor;

public class GameEvent
{

    public GameEvent(string type, string sceneName)
    {
        this.type = type;
        this.sceneName = sceneName;
    }

    public string type { get; }
    public string sceneName { get; }
}