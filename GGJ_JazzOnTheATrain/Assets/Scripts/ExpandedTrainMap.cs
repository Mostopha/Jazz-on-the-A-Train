using System;
using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.UI;
using Object = UnityEngine.Object;

public class ExpandedTrainMap : IntrusiveGuiOverlay
{
    Door trainDoor = null;

    public void onClick(Button uiButton)
    {
        Text buttonText = uiButton.gameObject.GetComponentInChildren<Text>();
        string locationSceneName;
        switch (buttonText.text)
        {
            case "New Orleans":
                locationSceneName = "NewOrleans1";
                break;
            case "New York":
                locationSceneName = "NewYork1";
                break;
            case "Los Angeles":
                locationSceneName = "California1";
                break;
            default:
                locationSceneName = buttonText.text;
                break;
        }

        this.SelectLocationFromMap(locationSceneName);
    }

    private Door GetTrainDoor()
    {
        if (trainDoor == null)
        {
            Door[] doors = FindObjectsOfType<Door>();
            foreach (Door door in doors)
            {
                if (!door.ToSceneName.Contains("Train"))
                {
                    trainDoor = door;
                }
            }
        }

        return trainDoor;
    }

    // Use this for initialization
    void Start()
    {
        this.gameObject.SetActive(false);


        Button[] cityButtons = this.GetComponentsInChildren<Button>();
        foreach (Button cityButton in cityButtons)
        {
            cityButton.onClick.RemoveAllListeners();
            cityButton.onClick.AddListener(delegate() { onClick(cityButton); });
        }
    }


    public void SelectLocationFromMap(string locationStartingSceneName)
    {
        GetTrainDoor().ToSceneName = locationStartingSceneName;
        this.gameObject.SetActive(false);
    }
}