using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity.Example;
using Object = UnityEngine.Object;

public class SceneChanger : MonoBehaviour
{
    public static SceneChanger sceneChanger;


    // Start is called before the first frame update
    void Start()
    {
        print("current scene is now " + SceneManager.GetActiveScene().name);
        sceneChanger = this;
        print("Previous scene was: " + GameState.get().previousSceneName);
        MovePlayerToDoorTheyCameFrom();
    }

    private void MovePlayerToDoorTheyCameFrom()
    {
        PlayerCharacter player = FindObjectOfType<PlayerCharacter>();
        Door doorBack = FindDoorToScene(GameState.get().previousSceneName);
        if (doorBack != null)
        {
            print("positioning at door");
            print(doorBack.gameObject);
            print(player);
            player.moveTo(doorBack.gameObject.transform.position.x);
        }
        else
        {
            print("no door to go back through");
        }
    }

    private Door FindDoorToScene(string previousSceneName)
    {
        Door[] doors = Object.FindObjectsOfType<Door>();
        foreach (Door door in doors)
        {
            if (door.ToSceneName.Equals(previousSceneName))
            {
                return door;
            }
        }

        return null;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            int nextScene = (SceneManager.GetActiveScene().buildIndex + 2) % SceneManager.sceneCountInBuildSettings;
            print("switching to scene" + nextScene + " of " + SceneManager.sceneCountInBuildSettings);
            SceneManager.LoadScene(nextScene);
        }
    }

    public void SwitchToScene(string sceneName)
    {
        print("switching to scene" + sceneName);

        GameState.get().trackEvent(new GameEvent("Exit Scene", SceneManager.GetActiveScene().name));
        SceneManager.LoadScene(sceneName);
    }
}