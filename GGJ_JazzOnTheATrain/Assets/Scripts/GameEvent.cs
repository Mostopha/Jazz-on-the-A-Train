using UnityEngine;
using UnityEditor;

public class GameEvent
{

    public GameEvent(string type, string argument)
    {
        this.type = type;
        this.argument = argument;
    }

    public string type { get; }
    public string argument { get; }
}