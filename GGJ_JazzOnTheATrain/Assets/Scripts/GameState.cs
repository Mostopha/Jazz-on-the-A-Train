using UnityEngine;
using UnityEditor;

public class GameState
{
    public static GameState get()
    {
        if (gameState == null)
        {
            gameState = new GameState();
        }

        return GameState.gameState;
    }

    private static GameState gameState;
    public string previousSceneName;

    private GameState()
    {
        this.initialize();
    }

    public void initialize()
    {
        this.previousSceneName = "Opening Sequence";
    }

    public void trackEvent(GameEvent gameEvent)
    {
        switch (gameEvent.type)
        {
            case "Exit Scene":
                this.previousSceneName = gameEvent.sceneName;
                break;
            default:
                break;
        }
    }
}