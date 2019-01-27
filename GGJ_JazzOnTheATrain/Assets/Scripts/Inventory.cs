using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    bool[] ingredients;
    public GameObject[] ingredientUI;
    public GameObject InventoryWindow;
    public Text ButtonText;
    public GameObject button;
    bool InventoryActive;

    public static bool NYVisited;
    public static bool CAVisited;

    // Start is called before the first frame update
    void Start()
    {
        ingredients = new bool[ingredientUI.Length];
       // ResetList();
    }

    // Update is called once per frame
    void Update()
    {
        if (InventoryActive)
        {
            ButtonText.text = "Close";
            for (int i = 0; i < ingredientUI.Length; i++)
            {
                ingredientUI[i].SetActive(ingredients[i]);
            }
        }
        else
        {
            ButtonText.text = "Inventory";
        }

        if (IsIntrusiveGuiOverlayVisible())
        {
            button.SetActive(false);
            InventoryWindow.SetActive(false);
        }
        else
        {
            button.SetActive(true);
            InventoryWindow.SetActive(InventoryActive);
        }

        /*if (Input.GetKeyDown(KeyCode.A))
        {
            GetItem("CoolJazz");
            GetItem("Bebop");
        }*/

    }

    private void ResetList()
    {
        for (int i = 0; i < ingredients.Length; i++)
        {
            ingredients[i] = false;
        }
    }

    [YarnCommand("Get")]
    public void GetItem(string item)
    {
        int index = 0;
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
    }

    public void ToggleInventory()
    {
        if (InventoryActive)
        {
            InventoryActive = false;
        }
        else
        {
            InventoryActive = true;
        }
    }

    bool IsIntrusiveGuiOverlayVisible()
    {

        DialogueRunner dialogRunner = FindObjectOfType<DialogueRunner>();
        if (dialogRunner != null && dialogRunner.isDialogueRunning == true)
        {
            return true;
        }

        IntrusiveGuiOverlay[] intrusiveOverlays = FindObjectsOfType<IntrusiveGuiOverlay>();
        foreach (IntrusiveGuiOverlay intrusiveGuiOverlay in intrusiveOverlays)
        {
            if (intrusiveGuiOverlay.isActiveAndEnabled)
            {
                return true;
            }
        }
        return false;
    }
}
