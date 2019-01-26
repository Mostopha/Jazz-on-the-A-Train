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

    private Room room;

    public SceneChanger()
    {
        if (sceneChanger == null)
        {
            sceneChanger = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
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

    public void CheckForSceneChange(PlayerCharacter player)
    {
        if (player.IsInteracting())
        {
            float playerX = player.transform.position.x;
            Door[] doors = Object.FindObjectsOfType<Door>();
            foreach (Door door in doors)
            {
                if (IsInRangeOfDoor(playerX, door))
                {
                    EnterDoor(door);
                }
            }
        }
    }

    private void EnterDoor(Door door)
    {
        //        SceneManager.MoveGameObjectToScene();
        print("switching to scene" + door.ToSceneName);
        SceneManager.LoadScene(door.ToSceneName);
        print("current scene is now " + SceneManager.GetActiveScene().name);
    }

    private bool IsInRangeOfDoor(float playerX, Door door)
    {
        print("distance: " + Math.Abs(door.transform.position.x - playerX));
        return Math.Abs(door.transform.position.x - playerX) < 1.5;
    }

    private bool IsExitingSceneRight(float position, float movement)
    {
//        Object.FindObjectOfType(typeof(Door));
//        SceneManager.GetActiveScene().
//        return position 
        return false;
    }
}