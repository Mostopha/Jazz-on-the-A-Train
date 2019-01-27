using System;
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
    public bool[] ingredients;

    private GameState()
    {
        this.initialize();
    }

    public void initialize()
    {
        this.previousSceneName = "Opening Sequence";
        this.ingredients = new bool[10];
    }

    public void trackEvent(GameEvent gameEvent)
    {
        switch (gameEvent.type)
        {
            case "Exit Scene":
                this.previousSceneName = gameEvent.argument;
                break;
            case "Item Received":
                int index = 0;
                string item = gameEvent.argument;
                switch (item)
                {
                    case "CoolJazz":
                        index = 0;
                        break;
                    case "Bebop":
                        index = 1;
                        break;
                    case "Swing":
                        index = 2;
                        break;
                    case "NewOrleans":
                        index = 3;
                        break;
                }

                ingredients[index] = true;
                break;
            default:
                break;
        }
    }
}