using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Object = UnityEngine.Object;

public class TrainMap : MonoBehaviour
{
    public GameObject TrainMapGui;
    public GameObject CollapsedMap;

    public void onClick(Button uiButton)
    {
        Text buttonText = uiButton.gameObject.GetComponentInChildren<Text>();
        string locationSceneName;
        switch (buttonText.text)
        {
            case "New Orleans":
                locationSceneName = "New Orleans 1";
                break;
            case "New York":
                locationSceneName = "New York 1";
                break;
            case "California":
                locationSceneName = "California 1";
                break;
            default:
                locationSceneName = buttonText.text;
                break;
        }

        this.SelectLocationFromMap(buttonText.text);
    }

    // Use this for initialization
    void Start()
    {
        TrainMapGui.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
//        CollapsedMap.transform.position.x
    }

    public void SelectLocationFromMap(string locationStartingSceneName)
    {
        Door trainDoor = null;
        Door[] doors = FindObjectsOfType<Door>();
        foreach (Door door in doors)
        {
            if (!door.ToSceneName.Contains("Train"))
            {
                trainDoor = door;
            }
        }

        trainDoor.ToSceneName = locationStartingSceneName;
    }


    private bool IsInRangeOfDoor(float playerX, Door door)
    {
        print("distance: " + Math.Abs(door.transform.position.x - playerX));
        return Math.Abs(door.transform.position.x - playerX) < 1.5;
    }
}