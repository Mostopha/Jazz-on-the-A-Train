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
        this.gameObject.SetActive(false);
        Door[] doors = FindObjectsOfType<Door>();
        foreach (Door door in doors)
        {
            if (!door.ToSceneName.Contains("Train"))
            {
                trainDoor = door;
            }
        }

       Button[] cityButtons =  this.GetComponentsInChildren<Button>();
       foreach (Button cityButton in cityButtons)
       {
           cityButton.onClick.RemoveAllListeners();
           cityButton.onClick.AddListener(delegate()
           {
               onClick(cityButton);
           });
       }
    }


    public void SelectLocationFromMap(string locationStartingSceneName)
    {
        trainDoor.ToSceneName = locationStartingSceneName;
    }
}